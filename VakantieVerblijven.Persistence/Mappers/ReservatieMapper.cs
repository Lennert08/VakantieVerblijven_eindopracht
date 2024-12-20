using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.Repositories;

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
    }
}
