using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VakantieVerblijven.Domain.Model;
using VakantieVerblijven.Domain.Repositories;

namespace VakantieVerblijven.Persistence.Mappers
{
    public class HuisMapper : IHuisRepository
    {
        private string _tableName = "Huizen";
        private SqlConnection _connection;
        private const string _connectionString = DbInfo.ConnectionString;

        public List<Huis> GetAllHuizen()
        {
            List<Huis> huizen = new List<Huis>();

            string query = @"
                SELECT 
                h.Id AS HuisId,
                h.Straat,
                h.Nummer,
                h.Aantal_Personen AS AantalPersonen,
                h.Actief,
                p.Id AS ParkId,
                p.Naam AS ParkNaam,
                p.Locatie AS ParkLocatie
                FROM 
                Huizen h
                INNER JOIN 
                Park_Huizen ph ON h.Id = ph.huis_id
                INNER JOIN 
                Parken p ON ph.park_id = p.Id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Lees huisgegevens
                                int huisId = (int)reader["HuisId"];
                                string straat = reader["Straat"].ToString();
                                int nummer = (int)reader["Nummer"];
                                int aantalPersonen = (int)reader["AantalPersonen"];
                                bool actief = (bool)reader["Actief"];

                                // Lees parkgegevens
                                int parkId = (int)reader["ParkId"];
                                string parkNaam = reader["ParkNaam"].ToString();
                                string parkLocatie = reader["ParkLocatie"].ToString();

                                // Maak Park-object
                                Park park = new Park(parkId, parkNaam, parkLocatie);

                                // Maak Huis-object en voeg toe aan lijst
                                Huis huis = new Huis(huisId, straat, nummer, actief, aantalPersonen, park);
                                huizen.Add(huis);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van huizen: {ex.Message}");
            }

            return huizen;
        }

        public List<string> GetPersonenOpties()
        {
            List<string> opties = new List<string>();

            string query = "SELECT MAX(aantal_personen) AS MaxAantalPersonen FROM Huizen;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int maxAantalPersonen))
                        {
                            for (int i = 1; i <= maxAantalPersonen; i++)
                            {
                                string optie = i == 1 ? $"{i} persoon" : $"{i} personen";
                                opties.Add(optie);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van opties: {ex.Message}");
            }

            return opties;
        }

        public List<Huis> GetBeschikbareHuizen(int parkId, int aantalPersonen, DateTime beginDatum, DateTime eindDatum)
        {
            List<Huis> beschikbareHuizen = new List<Huis>();

            string query = @"
            SELECT h.Id, h.Straat, h.Nummer, h.Aantal_Personen, h.Actief, p.Id AS ParkId, p.Naam AS ParkNaam, p.Locatie AS ParkLocatie
            FROM Huizen h
            INNER JOIN Park_Huizen ph ON h.Id = ph.huis_id
            INNER JOIN Parken p ON ph.park_id = p.Id
            WHERE 
            p.Id = @ParkId
            AND h.Aantal_Personen >= @AantalPersonen
            AND h.Actief = 1
            AND h.Id NOT IN (
            SELECT hr.huis_id
            FROM Huis_Reservaties hr
            INNER JOIN Reservaties r ON hr.reservatie_id = r.Id
            WHERE 
            r.StartDatum < @EindDatum
            AND r.EindDatum > @BeginDatum
            )
            ORDER BY h.Id;";

            try
            {
                using (SqlConnection connection = new SqlConnection(DbInfo.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ParkId", parkId);
                        command.Parameters.AddWithValue("@AantalPersonen", aantalPersonen);
                        command.Parameters.AddWithValue("@BeginDatum", beginDatum);
                        command.Parameters.AddWithValue("@EindDatum", eindDatum);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["Id"];
                                string straat = reader["Straat"].ToString();
                                int nummer = (int)reader["Nummer"];
                                int maxPersonen = (int)reader["Aantal_Personen"];
                                bool actief = (bool)reader["Actief"];
                                int parkIdResult = (int)reader["ParkId"];
                                string parkNaam = reader["ParkNaam"].ToString();
                                string parkLocatie = reader["ParkLocatie"].ToString();

                                Park park = new Park(parkIdResult, parkNaam, parkLocatie);
                                Huis huis = new Huis(id, straat, nummer, actief, maxPersonen, park);

                                beschikbareHuizen.Add(huis);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van beschikbare huizen: {ex.Message}");
            }

            return beschikbareHuizen;
        }
    }
}
