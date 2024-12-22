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
    public class FaciliteitMapper : IFaciliteitRepository
    {
        private string _tableName = "Reservaties";
        private SqlConnection _connection;
        private const string _connectionString = DbInfo.ConnectionString;

        public List<Faciliteit> GetAlleFaciliteiten()
        {
            List<Faciliteit> faciliteiten = new List<Faciliteit>();

            string query = "SELECT Id, Beschrijving FROM Faciliteiten;";

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
                                string beschrijving = reader["Beschrijving"].ToString();

                                Faciliteit faciliteit = new Faciliteit(id, beschrijving);
                                faciliteiten.Add(faciliteit);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van faciliteiten: {ex.Message}");
            }

            return faciliteiten;
        }
    }
}
