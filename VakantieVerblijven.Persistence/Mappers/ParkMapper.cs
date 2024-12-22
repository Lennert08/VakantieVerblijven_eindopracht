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
    public class ParkMapper : IParkRepository
    {
        private string _tableName = "Parken";
        private SqlConnection _connection;
        private const string _connectionString = DbInfo.ConnectionString;

        public List<Park> GetAllParks()
        {
            List<Park> result = new List<Park>();

            string query = $"SELECT Id, Naam, Locatie FROM {_tableName} ORDER BY Naam;";
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
                                int id = (int)reader["Id"];
                                string naam = reader["Naam"].ToString();
                                string locatie = reader["Locatie"].ToString();

                                Park park = new Park(id, naam, locatie);
                                result.Add(park);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van parken: {ex.Message}");
            }
            return result;
        }


        public List<Park> GetParksByFacilities(List<Faciliteit> faciliteiten)
        {
            List<Park> result = new List<Park>();

            // Haal de faciliteit-IDs op uit de lijst met faciliteiten
            List<int> faciliteitIds = faciliteiten.Select(f => f.Id).ToList();

            // Bouw de IN-clausule dynamisch op
            string inClause = string.Join(", ", faciliteitIds.Select((id, index) => $"@Faciliteit{index}"));

            // Query aanpassen om alleen parken te vinden die ALLE faciliteiten bevatten
            string query = $@"
            SELECT p.Id, p.Naam, p.Locatie
            FROM Parken p
            INNER JOIN Parken_Faciliteiten pf ON p.Id = pf.park_id
            WHERE pf.faciliteit_id IN ({inClause})
            GROUP BY p.Id, p.Naam, p.Locatie
            HAVING COUNT(DISTINCT pf.faciliteit_id) = @AantalFaciliteiten;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Voeg de faciliteit-parameters toe
                        for (int i = 0; i < faciliteitIds.Count; i++)
                        {
                            command.Parameters.AddWithValue($"@Faciliteit{i}", faciliteitIds[i]);
                        }

                        // Voeg het aantal faciliteiten toe voor de HAVING-clausule
                        command.Parameters.AddWithValue("@AantalFaciliteiten", faciliteitIds.Count);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["Id"];
                                string naam = reader["Naam"].ToString();
                                string locatie = reader["Locatie"].ToString();

                                Park park = new Park(id, naam, locatie);
                                result.Add(park);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van parken: {ex.Message}");
            }

            return result;
        }
    }
}
