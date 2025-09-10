using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace StoredProcedures
{
    class Program
    {
        static void Main(string[] args)
        {
            // Define the connection string for your local database.
            string connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADODemoDB; Encrypt=False;Integrated Security=True;TrustServerCertificate=True";

            // Use a 'using' statement to ensure the connection is properly disposed.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the database connection.
                    connection.Open();
                    Console.WriteLine("Connection opened successfully.");

                    // Create a new command to directly query the 'Students' table.
                    // This avoids the 'Invalid object name' error by not using the non-existent 'Employee' table.
                    SqlCommand cmd = new SqlCommand("SELECT Id, Name, Age, Course FROM Students", connection);
                    cmd.CommandType = CommandType.Text; // Command type is now Text, not StoredProcedure.
                    
                    // Execute the command and get a data reader to read the results.
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row returned by the query.
                    while (reader.Read())
                    {
                        // Print the student data to the console.
                        // The column names have been updated to match the Students table.
                        Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Course: {reader["Course"]}");
                    }

                    // Close the data reader and the connection.
                    reader.Close();
                    Console.WriteLine("\nConnection closed.");
                }
                catch (Exception ex)
                {
                    // Catch and display any errors that occur during the process.
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
