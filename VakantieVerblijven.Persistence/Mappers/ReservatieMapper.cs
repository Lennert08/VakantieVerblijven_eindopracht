using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.Repositories;
using VakantieVerblijven.Domain.ValueObject;

namespace VakantieVerblijven.Persistence.Mappers
{
    public class ReservatieMapper : IReservatieRepository
    {
        private string _tableName = "Reservaties";
        private SqlConnection _connection;
        private const string _connectionString = DbInfo.ConnectionString;

        public List<Reservatie> GetReservatiesByMonth(DateTime date)
        {
            List<Reservatie> reservaties = new List<Reservatie>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Haal de eerste en laatste dag van de maand op basis van de meegegeven DateTime
                    int month = date.Month;
                    int year = date.Year;
                    DateTime eersteDagVanMaand = new DateTime(year, month, 1);
                    DateTime laatsteDagVanMaand = eersteDagVanMaand.AddMonths(1).AddDays(-1);

                    // Query om reserveringen op te halen binnen de opgegeven maand en jaar
                    string query = @"
                    SELECT 
                    r.Id AS ReservatieId, 
                    r.StartDatum, 
                    r.EindDatum, 
                    k.Id AS KlantId, 
                    k.Naam AS KlantNaam, 
                    k.Adres AS KlantAdres, 
                    h.Id AS HuisId, 
                    h.Straat AS HuisStraat, 
                    h.Nummer AS HuisNummer, 
                    h.Aantal_Personen AS HuisAantalPersonen, 
                    h.Actief AS HuisActief
                    FROM 
                    Reservaties r
                    INNER JOIN 
                    Klanten k ON r.klant_nummer = k.Id
                    INNER JOIN 
                    Huis_Reservaties hr ON r.Id = hr.reservatie_id
                    INNER JOIN 
                    Huizen h ON hr.huis_id = h.Id
                    WHERE 
                    r.StartDatum >= @EersteDagVanMaand 
                    AND r.StartDatum <= @LaatsteDagVanMaand
                    ORDER BY 
                    r.StartDatum;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EersteDagVanMaand", eersteDagVanMaand);
                        command.Parameters.AddWithValue("@LaatsteDagVanMaand", laatsteDagVanMaand);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Gebruik aliasnamen uit de query
                                int reservatieId = (int)reader["ReservatieId"];
                                DateTime startDatum = (DateTime)reader["StartDatum"];
                                DateTime eindDatum = (DateTime)reader["EindDatum"];
                                int klantId = (int)reader["KlantId"];
                                string klantNaam = reader["KlantNaam"].ToString();
                                string klantAdres = reader["KlantAdres"].ToString();
                                int huisId = (int)reader["HuisId"];
                                string huisStraat = reader["HuisStraat"].ToString();
                                int huisNummer = (int)reader["HuisNummer"];
                                int huisAantalPersonen = (int)reader["HuisAantalPersonen"];
                                bool huisActief = (bool)reader["HuisActief"];

                                // Maak Klant en Huis objecten aan
                                Klant klant = new Klant(klantId, klantNaam, klantAdres);
                                Huis huis = new Huis(huisId, huisStraat, huisNummer, huisActief, huisAantalPersonen);

                                // Maak de Reservatie aan
                                Reservatie reservatie = new Reservatie(reservatieId, startDatum, eindDatum, klant, huis);
                                reservaties.Add(reservatie);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van reserveringen: {ex.Message}");
            }

            return reservaties;
        }

        public List<Reservatie> GetProbleemReservaties()
        {
            List<Reservatie> reservaties = new List<Reservatie>();

            string query = @"
        SELECT 
        r.Id AS ReservatieId,
        r.StartDatum,
        r.EindDatum,
        r.klant_nummer AS KlantNummer,
        k.Id AS KlantId,
        k.Naam AS KlantNaam,
        k.Adres AS KlantAdres,
        h.Id AS HuisId,
        h.Straat,
        h.Nummer,
        h.Aantal_Personen AS AantalPersonen,
        h.Actief AS HuisActief
        FROM 
        Reservaties r
        INNER JOIN 
        Klanten k ON r.klant_nummer = k.Id
        INNER JOIN 
        Huis_Reservaties hr ON r.Id = hr.reservatie_id
        INNER JOIN 
        Huizen h ON hr.huis_id = h.Id
        WHERE 
        h.Actief = 0
        AND r.StartDatum >= @Vandaag
        ORDER BY 
        r.StartDatum;";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Voeg de parameter voor vandaag toe
                    command.Parameters.AddWithValue("@Vandaag", DateTime.Today);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Haal reservatiegegevens op
                            int reservatieId = (int)reader["ReservatieId"];
                            DateTime startDatum = (DateTime)reader["StartDatum"];
                            DateTime eindDatum = (DateTime)reader["EindDatum"];
                            int klantNummer = (int)reader["KlantNummer"];

                            // Haal klantgegevens op
                            int klantId = (int)reader["KlantId"];
                            string klantNaam = reader["KlantNaam"].ToString();
                            string klantAdres = reader["KlantAdres"].ToString();

                            // Haal huisgegevens op
                            int huisId = (int)reader["HuisId"];
                            string straat = reader["Straat"].ToString();
                            int nummer = (int)reader["Nummer"];
                            int aantalPersonen = (int)reader["AantalPersonen"];
                            bool huisActief = (bool)reader["HuisActief"];

                            // Maak Klant en Huis objecten
                            Klant klant = new Klant(klantId, klantNaam, klantAdres);
                            Huis huis = new Huis(huisId, straat, nummer, huisActief, aantalPersonen);

                            // Maak Reservatie object en voeg toe aan lijst
                            Reservatie reservatie = new Reservatie(reservatieId, startDatum, eindDatum, klant, huis);
                            reservaties.Add(reservatie);
                        }
                    }
                }
            }

            return reservaties;
        }

        public bool VoegReservatieToe(KlantVO gekozenKlant, ParkVO gekozenPark, int aantalPersonen, DateTime startDatum, DateTime eindDatum, HuisVO gekozenHuis)
        {
            string insertReservatieQuery = @"
            INSERT INTO Reservaties (klant_nummer, startdatum, einddatum)
            OUTPUT INSERTED.Id 
            VALUES (@KlantNummer, @StartDatum, @EindDatum);";
            //output zorgt ervoor dat we deze id die gegeneert zal worden in reservaties kunnen opvragen zodat we deze in huis_reservaties kunnen stoppen

            string insertHuisReservatieQuery = @"
            INSERT INTO Huis_Reservaties (huis_id, reservatie_id)
            VALUES (@HuisId, @ReservatieId);";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbInfo.ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int nieuweReservatieId;

                            // Voeg de reservatie toe en haal het gegenereerde ID op
                            using (SqlCommand reservatieCommand = new SqlCommand(insertReservatieQuery, connection, transaction))
                            {
                                reservatieCommand.Parameters.AddWithValue("@KlantNummer", gekozenKlant.Id);
                                reservatieCommand.Parameters.AddWithValue("@StartDatum", startDatum);
                                reservatieCommand.Parameters.AddWithValue("@EindDatum", eindDatum);

                                nieuweReservatieId = (int)reservatieCommand.ExecuteScalar(); //hier krijgen we de id die gegeneert is mee en gebruiken we die in onze volgende insert
                            }

                            // Voeg de relatie tussen huis en reservatie toe in de tussentabel
                            using (SqlCommand huisReservatieCommand = new SqlCommand(insertHuisReservatieQuery, connection, transaction))
                            {
                                huisReservatieCommand.Parameters.AddWithValue("@HuisId", gekozenHuis.Id);
                                huisReservatieCommand.Parameters.AddWithValue("@ReservatieId", nieuweReservatieId);

                                huisReservatieCommand.ExecuteNonQuery();
                            }

                            // Bevestig de transactie
                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            // Rol de transactie terug bij een fout
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het toevoegen van de reservering: {ex.Message}");
            }
        }

        public List<Reservatie> ZoekReservaties(string klantZoekTerm, int parkId)
        {
            List<Reservatie> reservaties = new List<Reservatie>();

            // De SQL-query
            string query = @"
            SELECT 
            r.Id AS ReservatieId,
            r.StartDatum,
            r.EindDatum,
            k.Id AS KlantId,
            k.Naam AS KlantNaam,
            k.Adres AS KlantAdres,
            h.Id AS HuisId,
            h.Straat,
            h.Nummer,
            h.Aantal_Personen AS AantalPersonen,
            h.Actief AS HuisActief,
            p.Id AS ParkId,
            p.Naam AS ParkNaam,
            p.Locatie AS ParkLocatie
            FROM Reservaties r
            INNER JOIN Klanten k ON r.klant_nummer = k.Id
            INNER JOIN Huis_Reservaties hr ON r.Id = hr.reservatie_id
            INNER JOIN Huizen h ON hr.huis_id = h.Id
            INNER JOIN Park_Huizen ph ON h.Id = ph.huis_id
            INNER JOIN Parken p ON ph.park_id = p.Id
            WHERE 
            -- Als @ParkId = 0, toon alle parken, anders filter op het opgegeven park
            (@ParkId = 0 OR ph.park_id = @ParkId)
        
            -- Als @KlantZoekTerm NULL is, toon alle klanten, anders filter op de opgegeven zoekterm
             AND (@KlantZoekTerm IS NULL OR k.Naam LIKE '%' + @KlantZoekTerm + '%')
            ORDER BY r.StartDatum;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbInfo.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Voeg parameters toe aan de query
                        command.Parameters.AddWithValue("@ParkId", parkId);
                        command.Parameters.AddWithValue("@KlantZoekTerm", string.IsNullOrWhiteSpace(klantZoekTerm) ? DBNull.Value : klantZoekTerm);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Haal gegevens op uit de database
                                int reservatieId = (int)reader["ReservatieId"];
                                DateTime startDatum = (DateTime)reader["StartDatum"];
                                DateTime eindDatum = (DateTime)reader["EindDatum"];
                                int klantId = (int)reader["KlantId"];
                                string klantNaam = reader["KlantNaam"].ToString();
                                string klantAdres = reader["KlantAdres"].ToString();
                                int huisId = (int)reader["HuisId"];
                                string straat = reader["Straat"].ToString();
                                int nummer = (int)reader["Nummer"];
                                int aantalPersonen = (int)reader["AantalPersonen"];
                                bool huisActief = (bool)reader["HuisActief"];
                                int parkIdResult = (int)reader["ParkId"];
                                string parkNaam = reader["ParkNaam"].ToString();
                                string parkLocatie = reader["ParkLocatie"].ToString();

                                // Maak objecten aan
                                Klant klant = new Klant(klantId, klantNaam, klantAdres);
                                Park park = new Park(parkIdResult, parkNaam, parkLocatie);
                                Huis huis = new Huis(huisId, straat, nummer, huisActief, aantalPersonen, park);
                                Reservatie reservatie = new Reservatie(reservatieId, startDatum, eindDatum, klant, huis);

                                // Voeg toe aan de lijst
                                reservaties.Add(reservatie);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het zoeken naar reservaties: {ex.Message}");
            }

            return reservaties;
        }

        public List<Reservatie> ZoekReservatiesMetPeriode(string klantZoekTerm, int parkId, DateTime? startDatum, DateTime? eindDatum)
        {
            List<Reservatie> reservaties = new List<Reservatie>();

            // SQL-query
            string query = @"
            SELECT 
            r.Id AS ReservatieId,
            r.StartDatum,
            r.EindDatum,
            k.Id AS KlantId,
            k.Naam AS KlantNaam,
            k.Adres AS KlantAdres,
            h.Id AS HuisId,
            h.Straat,
            h.Nummer,
            h.Aantal_Personen AS AantalPersonen,
            h.Actief AS HuisActief,
            p.Id AS ParkId,
            p.Naam AS ParkNaam,
            p.Locatie AS ParkLocatie
            FROM Reservaties r
            INNER JOIN Klanten k ON r.klant_nummer = k.Id
            INNER JOIN Huis_Reservaties hr ON r.Id = hr.reservatie_id
            INNER JOIN Huizen h ON hr.huis_id = h.Id
            INNER JOIN Park_Huizen ph ON h.Id = ph.huis_id
            INNER JOIN Parken p ON ph.park_id = p.Id
            WHERE 
            -- Als @ParkId = 0, toon alle parken, anders filter op het opgegeven park
            (@ParkId = 0 OR ph.park_id = @ParkId)
        
            -- Als @KlantZoekTerm NULL is, toon alle klanten, anders filter op de opgegeven zoekterm
            AND (@KlantZoekTerm IS NULL OR k.Naam LIKE '%' + @KlantZoekTerm + '%')

            -- Filter op periode als beide datums aanwezig zijn
            AND (@StartDatum IS NULL OR r.StartDatum >= @StartDatum)
            AND (@EindDatum IS NULL OR r.EindDatum <= @EindDatum)
            ORDER BY r.StartDatum;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbInfo.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Voeg parameters toe
                        command.Parameters.AddWithValue("@ParkId", parkId);
                        command.Parameters.AddWithValue("@KlantZoekTerm", string.IsNullOrWhiteSpace(klantZoekTerm) ? DBNull.Value : klantZoekTerm);
                        command.Parameters.AddWithValue("@StartDatum", startDatum ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EindDatum", eindDatum ?? (object)DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Haal gegevens op uit de database
                                int reservatieId = (int)reader["ReservatieId"];
                                DateTime startDatumResult = (DateTime)reader["StartDatum"];
                                DateTime eindDatumResult = (DateTime)reader["EindDatum"];
                                int klantId = (int)reader["KlantId"];
                                string klantNaam = reader["KlantNaam"].ToString();
                                string klantAdres = reader["KlantAdres"].ToString();
                                int huisId = (int)reader["HuisId"];
                                string straat = reader["Straat"].ToString();
                                int nummer = (int)reader["Nummer"];
                                int aantalPersonen = (int)reader["AantalPersonen"];
                                bool huisActief = (bool)reader["HuisActief"];
                                int parkIdResult = (int)reader["ParkId"];
                                string parkNaam = reader["ParkNaam"].ToString();
                                string parkLocatie = reader["ParkLocatie"].ToString();

                                // Maak objecten aan
                                Klant klant = new Klant(klantId, klantNaam, klantAdres);
                                Park park = new Park(parkIdResult, parkNaam, parkLocatie);
                                Huis huis = new Huis(huisId, straat, nummer, huisActief, aantalPersonen, park);
                                Reservatie reservatie = new Reservatie(reservatieId, startDatumResult, eindDatumResult, klant, huis);

                                // Voeg toe aan de lijst
                                reservaties.Add(reservatie);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het zoeken naar reservaties met periode: {ex.Message}");
            }

            return reservaties;
        }

    }
}
