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
        private string _tableName = "Reservaties";
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
    }
}
