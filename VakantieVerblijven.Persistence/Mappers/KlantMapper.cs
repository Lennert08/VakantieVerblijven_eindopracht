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
    public class KlantMapper : IKlantRepository
    {
        private string _tableName = "Klanten";
        private SqlConnection _connection;
        private const string _connectionString = DbInfo.ConnectionString;


        public List<Klant> ZoekKlant(string zoekterm)
        {
            List<Klant> gevondenKlanten = new List<Klant>();

            string query = $@"
                SELECT Id, Naam, Adres
                FROM {_tableName}
                WHERE Naam LIKE @Zoekterm
                ORDER BY Naam;";

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Voeg parameter toe met wildcard voor LIKE-zoekopdracht
                        command.Parameters.AddWithValue("@Zoekterm", $"%{zoekterm}%");

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["Id"];
                                string naam = reader["Naam"].ToString();
                                string adres = reader["Adres"].ToString();

                                // Maak Klant object en voeg toe aan de lijst
                                gevondenKlanten.Add(new Klant(id, naam, adres));
                            }
                        }
                    }
                }

                return gevondenKlanten;
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het zoeken naar klanten: {ex.Message}");
            }
        }
    }
}
