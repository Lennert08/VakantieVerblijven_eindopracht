using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VakantieVerblijven.DatalLoader
{
    using Microsoft.Data.SqlClient;
    using System;
    using System.Data.SqlClient;
    using System.IO;

    namespace VakantieVerblijven
    {
        class DataLoader
        {
            private string _connectionString = DbInfo._connectionString;
            private SqlConnection _connection;
            private string _tableName = "movies";

            public DataLoader()
            {
                _connection = new SqlConnection(_connectionString);
            }

            public void DeleteAllData()
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        // Zet de volgorde correct om FK-problemen te vermijden
                        string[] deleteStatements = new string[]
                        {
                            "DELETE FROM Huis_Reservaties",
                            "DELETE FROM Park_Huizen",
                            "DELETE FROM Parken_Faciliteiten",
                            "DELETE FROM Reservaties",
                            "DELETE FROM Huizen",
                            "DELETE FROM Faciliteiten",
                            "DELETE FROM Parken",
                            "DELETE FROM Klanten"
                        };

                        foreach (string query in deleteStatements)
                        {
                            using (SqlCommand cmd = new SqlCommand(query, connection))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        Console.WriteLine("Alle data is succesvol verwijderd.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Er is een fout opgetreden bij het verwijderen van de data.");
                    Console.WriteLine(e.Message);
                }
            }

            public void ImportData()
            {
                try
                {
                    // Paden naar de bestanden
                    string basePath = @"C:\non_ondrive_map\Vakken_sem3\Eindopdracht_gevorderd\VakantieVerblijven\parkdata\";

                    string faciliteitenPath = Path.Combine(basePath, "faciliteiten.txt");
                    string parkenPath = Path.Combine(basePath, "parken.txt");
                    string parkenFaciliteitenPath = Path.Combine(basePath, "parken_faciliteiten.txt");
                    string huizenPath = Path.Combine(basePath, "huizen.txt");
                    string parkHuizenPath = Path.Combine(basePath, "park_huizen.txt");
                    string klantenParkPath = Path.Combine(basePath, "klanten_park.txt");
                    string reservatiesPath = Path.Combine(basePath, "reservaties.txt");
                    string huisReservatiesPath = Path.Combine(basePath, "huis_reservaties.txt");

                    // Voer import-methodes uit
                    Console.WriteLine("Data inladen...");
                    ImportFaciliteiten(faciliteitenPath);
                    ImportParken(parkenPath);
                    ImportParkenFaciliteiten(parkenFaciliteitenPath);
                    ImportHuizen(huizenPath);
                    ImportParkHuizen(parkHuizenPath);
                    ImportKlantenPark(klantenParkPath);
                    ImportReservaties(reservatiesPath); // Toegevoegd!
                    ImportHuisReservaties(huisReservatiesPath);

                    Console.WriteLine("Alle data is succesvol toegevoegd.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Er is een fout opgetreden bij het importeren van de data.");
                    Console.WriteLine(e.Message);
                }
            }

            private void ImportReservaties(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Zet IDENTITY_INSERT aan voor de tabel Reservaties
                    string setIdentityInsertQuery = "SET IDENTITY_INSERT Reservaties ON";
                    using (SqlCommand cmd = new SqlCommand(setIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');

                        // Zorg dat data correct wordt gelezen
                        int reservatieId = int.Parse(data[0]);
                        DateTime startDatum = DateTime.Parse(data[1]);
                        DateTime eindDatum = DateTime.Parse(data[2]);
                        int klantNummer = int.Parse(data[3]);

                        // Query om data in te voegen
                        string query = @"INSERT INTO Reservaties (Id, klant_nummer, startdatum, einddatum) 
                             VALUES (@Id, @KlantNummer, @StartDatum, @EindDatum)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", reservatieId);
                            cmd.Parameters.AddWithValue("@KlantNummer", klantNummer);
                            cmd.Parameters.AddWithValue("@StartDatum", startDatum);
                            cmd.Parameters.AddWithValue("@EindDatum", eindDatum);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Zet IDENTITY_INSERT weer uit voor de tabel Reservaties
                    string resetIdentityInsertQuery = "SET IDENTITY_INSERT Reservaties OFF";
                    using (SqlCommand cmd = new SqlCommand(resetIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }



            private void ImportFaciliteiten(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Zet IDENTITY_INSERT aan voor de tabel Faciliteiten
                    string setIdentityInsertQuery = "SET IDENTITY_INSERT Faciliteiten ON";
                    using (SqlCommand cmd = new SqlCommand(setIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');
                        string query = "INSERT INTO Faciliteiten (Id, beschrijving) VALUES (@Id, @Beschrijving)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", data[0]);
                            cmd.Parameters.AddWithValue("@Beschrijving", data[1]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Zet IDENTITY_INSERT weer uit voor de tabel Faciliteiten
                    string resetIdentityInsertQuery = "SET IDENTITY_INSERT Faciliteiten OFF";
                    using (SqlCommand cmd = new SqlCommand(resetIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            private void ImportParken(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Zet IDENTITY_INSERT aan voor de tabel Parken
                    string setIdentityInsertQuery = "SET IDENTITY_INSERT Parken ON";
                    using (SqlCommand cmd = new SqlCommand(setIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');
                        string query = "INSERT INTO Parken (Id, naam, locatie) VALUES (@Id, @Naam, @Locatie)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", data[0]);
                            cmd.Parameters.AddWithValue("@Naam", data[1]);
                            cmd.Parameters.AddWithValue("@Locatie", data[2]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Zet IDENTITY_INSERT weer uit voor de tabel Parken
                    string resetIdentityInsertQuery = "SET IDENTITY_INSERT Parken OFF";
                    using (SqlCommand cmd = new SqlCommand(resetIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            private void ImportParkenFaciliteiten(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');
                        string query = "INSERT INTO Parken_Faciliteiten (park_id, faciliteit_id) VALUES (@ParkId, @FaciliteitId)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ParkId", data[0]);
                            cmd.Parameters.AddWithValue("@FaciliteitId", data[1]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            private void ImportHuizen(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Zet IDENTITY_INSERT aan voor de tabel Huizen
                    string setIdentityInsertQuery = "SET IDENTITY_INSERT Huizen ON";
                    using (SqlCommand cmd = new SqlCommand(setIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');
                        string query = @"INSERT INTO Huizen (Id, straat, nummer, actief, aantal_personen) 
                             VALUES (@Id, @Straat, @Nummer, @Actief, @AantalPersonen)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", data[0]);
                            cmd.Parameters.AddWithValue("@Straat", data[1]);
                            cmd.Parameters.AddWithValue("@Nummer", data[2]);
                            cmd.Parameters.AddWithValue("@Actief", bool.Parse(data[3]));
                            cmd.Parameters.AddWithValue("@AantalPersonen", data[4]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Zet IDENTITY_INSERT weer uit voor de tabel Huizen
                    string resetIdentityInsertQuery = "SET IDENTITY_INSERT Huizen OFF";
                    using (SqlCommand cmd = new SqlCommand(resetIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            private void ImportParkHuizen(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');
                        string query = "INSERT INTO Park_Huizen (park_id, huis_id) VALUES (@ParkId, @HuisId)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@ParkId", data[0]);
                            cmd.Parameters.AddWithValue("@HuisId", data[1]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }

            private void ImportKlantenPark(string filePath)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Zet IDENTITY_INSERT aan voor de tabel Klanten
                    string setIdentityInsertQuery = "SET IDENTITY_INSERT Klanten ON";
                    using (SqlCommand cmd = new SqlCommand(setIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split('|');
                        string query = "INSERT INTO Klanten (Id, naam, adres) VALUES (@Id, @Naam, @Adres)";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@Id", data[0]);
                            cmd.Parameters.AddWithValue("@Naam", data[1]);
                            cmd.Parameters.AddWithValue("@Adres", data[2]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Zet IDENTITY_INSERT weer uit voor de tabel Klanten
                    string resetIdentityInsertQuery = "SET IDENTITY_INSERT Klanten OFF";
                    using (SqlCommand cmd = new SqlCommand(resetIdentityInsertQuery, connection))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            private void ImportHuisReservaties(string filePath)
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    foreach (string line in File.ReadAllLines(filePath))
                    {
                        string[] data = line.Split(',');
                        string query = "INSERT INTO Huis_Reservaties (huis_id, reservatie_id) VALUES (@HuisId, @ReservatieId)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@HuisId", data[0]);
                            cmd.Parameters.AddWithValue("@ReservatieId", data[1]);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}