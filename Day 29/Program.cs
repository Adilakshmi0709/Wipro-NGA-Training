// // using System;
// // using Microsoft.Data.SqlClient;

// // class Program
// // {
// //     static void Main(string[] args)
// //     {
// //         string connectionString = 
// //             "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADODemoDB; Encrypt=False;Integrated Security=True";

// //         using (SqlConnection connection = new SqlConnection(connectionString))
// //         {
// //             try
// //             {
// //                 connection.Open();
// //                 Console.WriteLine("Connection opened successfully.");
                
// //                 // --- Task 1: Insert a new student into the Students table ---
// //                 Console.WriteLine("\n--- Inserting a new student using ExecuteNonQuery() ---");
                
// //                 // SQL query with parameters to insert a new student.
// //                 string sqlInsertQuery = "INSERT INTO Students (Name, Age, Course) VALUES (@Name, @Age, @Course)";
                
// //                 // Create a SqlCommand object with the query and connection.
// //                 SqlCommand cmdInsert = new SqlCommand(sqlInsertQuery, connection);
                
// //                 // Add parameters for each value. This is the recommended secure approach.
// //                 // Adapting values from your image for the 'Students' table.
// //                 cmdInsert.Parameters.AddWithValue("@Name", "Ravi");
// //                 cmdInsert.Parameters.AddWithValue("@Age", 24); // An example age for Ravi
// //                 cmdInsert.Parameters.AddWithValue("@Course", "IT"); // An example course for Ravi

// //                 // ExecuteNonQuery is used for commands that do not return any data,
// //                 // such as INSERT, UPDATE, or DELETE. It returns the number of rows affected.
// //                 int rowsAffected = cmdInsert.ExecuteNonQuery();

// //                 Console.WriteLine($"{rowsAffected} row(s) inserted successfully.");


// //                 // --- Task 2: Read all records from the Students table ---
// //                 Console.WriteLine("\n--- All Students after insertion ---");
                
// //                 SqlCommand cmdSelectAll = new SqlCommand("SELECT Id, Name, Age, Course FROM Students", connection);
// //                 SqlDataReader readerAll = cmdSelectAll.ExecuteReader();

// //                 while (readerAll.Read())
// //                 {
// //                     Console.WriteLine($"ID: {readerAll["Id"]}, Name: {readerAll["Name"]}, Age: {readerAll["Age"]}, Course: {readerAll["Course"]}");
// //                 }
                
// //                 readerAll.Close();


// //                 // --- Task 3: Call the GetStudentsByCourse stored procedure ---
// //                 Console.WriteLine("\n--- Students in Computer Science Course ---");
                
// //                 SqlCommand cmdSP = new SqlCommand("GetStudentsByCourse", connection);
// //                 cmdSP.CommandType = System.Data.CommandType.StoredProcedure;
// //                 cmdSP.Parameters.AddWithValue("@Course", "Computer Science");
                
// //                 SqlDataReader readerSP = cmdSP.ExecuteReader();

// //                 while (readerSP.Read())
// //                 {
// //                     Console.WriteLine($"ID: {readerSP["Id"]}, Name: {readerSP["Name"]}, Age: {readerSP["Age"]}, Course: {readerSP["Course"]}");
// //                 }

// //                 readerSP.Close();

// //                 // --- Task 4: Read data for only Rushikesh using a parameterized query (Recommended) ---
// //                 Console.WriteLine("\n--- Data for Rushikesh (using a parameterized query) ---");

// //                 string sqlQueryForRushikesh = "SELECT Id, Name, Age, Course FROM Students WHERE Name = @Name";
// //                 SqlCommand cmdForRushikesh = new SqlCommand(sqlQueryForRushikesh, connection);
                
// //                 cmdForRushikesh.Parameters.AddWithValue("@Name", "Rushikesh");

// //                 SqlDataReader readerRushikesh = cmdForRushikesh.ExecuteReader();

// //                 if (readerRushikesh.HasRows)
// //                 {
// //                     while (readerRushikesh.Read())
// //                     {
// //                         Console.WriteLine($"ID: {readerRushikesh["Id"]}, Name: {readerRushikesh["Name"]}, Age: {readerRushikesh["Age"]}, Course: {readerRushikesh["Course"]}");
// //                     }
// //                 }
// //                 else
// //                 {
// //                     Console.WriteLine("No student with the name 'Rushikesh' was found.");
// //                 }

// //                 readerRushikesh.Close();
// //             }
// //             catch (Exception ex)
// //             {
// //                 Console.WriteLine($"An error occurred: {ex.Message}");
// //             }
// //         }
// //     }
// // }







// // using System;
// // using System.Data; // Required for DataSet and DataTable
// // using Microsoft.Data.SqlClient;

// // class Program
// // {
// //     static void Main(string[] args)
// //     {
// //         string connectionString = 
// //             "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADODemoDB; Encrypt=False;Integrated Security=True";

// //         using (SqlConnection connection = new SqlConnection(connectionString))
// //         {
// //             try
// //             {
// //                 connection.Open();
// //                 Console.WriteLine("Connection opened successfully.");
                
// //                 // --- Task 1: Insert multiple new students into the Students table (Batch Insert) ---
// //                 Console.WriteLine("\n--- Inserting multiple new students using a single command ---");
                
// //                 string sqlBatchInsertQuery = "INSERT INTO Students (Name, Age, Course) VALUES (@Name1, @Age1, @Course1), (@Name2, @Age2, @Course2)";
// //                 SqlCommand cmdBatchInsert = new SqlCommand(sqlBatchInsertQuery, connection);
                
// //                 cmdBatchInsert.Parameters.AddWithValue("@Name1", "David");
// //                 cmdBatchInsert.Parameters.AddWithValue("@Age1", 25);
// //                 cmdBatchInsert.Parameters.AddWithValue("@Course1", "Math");

// //                 cmdBatchInsert.Parameters.AddWithValue("@Name2", "Emily");
// //                 cmdBatchInsert.Parameters.AddWithValue("@Age2", 21);
// //                 cmdBatchInsert.Parameters.AddWithValue("@Course2", "Physics");

// //                 int rowsAffectedBatch = cmdBatchInsert.ExecuteNonQuery();
// //                 Console.WriteLine($"{rowsAffectedBatch} row(s) inserted successfully in a batch.");
                

// //                 // --- Task 2: Read all records using SqlDataReader (forward-only stream) ---
// //                 Console.WriteLine("\n--- All Students using SqlDataReader ---");
                
// //                 SqlCommand cmdSelectAll = new SqlCommand("SELECT Id, Name, Age, Course FROM Students", connection);
// //                 SqlDataReader readerAll = cmdSelectAll.ExecuteReader();

// //                 while (readerAll.Read())
// //                 {
// //                     Console.WriteLine($"ID: {readerAll["Id"]}, Name: {readerAll["Name"]}, Age: {readerAll["Age"]}, Course: {readerAll["Course"]}");
// //                 }
                
// //                 readerAll.Close();


// //                 // --- Task 3: Read data and fill a DataSet using SqlDataAdapter ---
// //                 Console.WriteLine("\n--- All Students using SqlDataAdapter and DataSet ---");
                
// //                 // SQL command to select data.
// //                 string sqlQueryForDataSet = "SELECT Id, Name, Age, Course FROM Students";

// //                 // Create a SqlDataAdapter that uses the command to fill the DataSet.
// //                 SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryForDataSet, connection);

// //                 // Create a new DataSet object to hold the data in memory.
// //                 DataSet ds = new DataSet();
                
// //                 // Fill the DataSet with data from the 'Students' table.
// //                 adapter.Fill(ds, "Students");

// //                 // Check if the 'Students' table exists and has rows.
// //                 if (ds.Tables.Contains("Students") && ds.Tables["Students"].Rows.Count > 0)
// //                 {
// //                     // Loop through each DataRow in the DataTable.
// //                     foreach (DataRow row in ds.Tables["Students"].Rows)
// //                     {
// //                         Console.WriteLine($"ID: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}, Course: {row["Course"]}");
// //                     }
// //                 }
// //                 else
// //                 {
// //                     Console.WriteLine("No data found in the Students table.");
// //                 }

                
// //                 // --- Task 4: Call the GetStudentsByCourse stored procedure ---
// //                 Console.WriteLine("\n--- Students in Computer Science Course ---");
                
// //                 SqlCommand cmdSP = new SqlCommand("GetStudentsByCourse", connection);
// //                 cmdSP.CommandType = System.Data.CommandType.StoredProcedure;
// //                 cmdSP.Parameters.AddWithValue("@Course", "Computer Science");
                
// //                 SqlDataReader readerSP = cmdSP.ExecuteReader();

// //                 while (readerSP.Read())
// //                 {
// //                     Console.WriteLine($"ID: {readerSP["Id"]}, Name: {readerSP["Name"]}, Age: {readerSP["Age"]}, Course: {readerSP["Course"]}");
// //                 }

// //                 readerSP.Close();

// //                 // --- Task 5: Read data for only Rushikesh using a parameterized query ---
// //                 Console.WriteLine("\n--- Data for Rushikesh (using a parameterized query) ---");

// //                 string sqlQueryForRushikesh = "SELECT Id, Name, Age, Course FROM Students WHERE Name = @Name";
// //                 SqlCommand cmdForRushikesh = new SqlCommand(sqlQueryForRushikesh, connection);
                
// //                 cmdForRushikesh.Parameters.AddWithValue("@Name", "Rushikesh");

// //                 SqlDataReader readerRushikesh = cmdForRushikesh.ExecuteReader();

// //                 if (readerRushikesh.HasRows)
// //                 {
// //                     while (readerRushikesh.Read())
// //                     {
// //                         Console.WriteLine($"ID: {readerRushikesh["Id"]}, Name: {readerRushikesh["Name"]}, Age: {readerRushikesh["Age"]}, Course: {readerRushikesh["Course"]}");
// //                     }
// //                 }
// //                 else
// //                 {
// //                     Console.WriteLine("No student with the name 'Rushikesh' was found.");
// //                 }

// //                 readerRushikesh.Close();
// //             }
// //             catch (Exception ex)
// //             {
// //                 Console.WriteLine($"An error occurred: {ex.Message}");
// //             }
// //         }
// //     }
// // }






































































// // Required Namespaces
// using System;
// using System.Data; // For DataSet, DataTable
// using Microsoft.Data.SqlClient; // For SQL Server connectivity (ADO.NET)

// class Program
// {
//     static void Main(string[] args)
//     {
//         // --- Connection String (Database details to connect SQL Server) ---
//         string connectionString = 
//             "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ADODemoDB; Encrypt=False;Integrated Security=True";

//         // --- SqlConnection (Connected Architecture) ---
//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 connection.Open();
//                 Console.WriteLine("Connection opened successfully.");
                
//                 // =========================================================================
//                 // Task 1: INSERT (Batch Insert using SqlCommand + Parameters)
//                 // =========================================================================
//                 Console.WriteLine("\n--- Inserting multiple new students using a single command ---");
                
//                 string sqlBatchInsertQuery = 
//                     "INSERT INTO Students (Name, Age, Course) VALUES (@Name1, @Age1, @Course1), (@Name2, @Age2, @Course2)";
//                 SqlCommand cmdBatchInsert = new SqlCommand(sqlBatchInsertQuery, connection);
                
//                 cmdBatchInsert.Parameters.AddWithValue("@Name1", "David");
//                 cmdBatchInsert.Parameters.AddWithValue("@Age1", 25);
//                 cmdBatchInsert.Parameters.AddWithValue("@Course1", "Math");

//                 cmdBatchInsert.Parameters.AddWithValue("@Name2", "Emily");
//                 cmdBatchInsert.Parameters.AddWithValue("@Age2", 21);
//                 cmdBatchInsert.Parameters.AddWithValue("@Course2", "Physics");

//                 int rowsAffectedBatch = cmdBatchInsert.ExecuteNonQuery();
//                 Console.WriteLine($"{rowsAffectedBatch} row(s) inserted successfully in a batch.");
                

//                 // =========================================================================
//                 // Task 2: SELECT using SqlDataReader (Connected - Forward Only Reader)
//                 // =========================================================================
//                 Console.WriteLine("\n--- All Students using SqlDataReader ---");
                
//                 SqlCommand cmdSelectAll = new SqlCommand("SELECT Id, Name, Age, Course FROM Students", connection);
//                 SqlDataReader readerAll = cmdSelectAll.ExecuteReader();

//                 while (readerAll.Read())
//                 {
//                     Console.WriteLine($"ID: {readerAll["Id"]}, Name: {readerAll["Name"]}, Age: {readerAll["Age"]}, Course: {readerAll["Course"]}");
//                 }
                
//                 readerAll.Close();


//                 // =========================================================================
//                 // Task 3: SELECT using SqlDataAdapter + DataSet (Disconnected Architecture)
//                 // =========================================================================
//                 Console.WriteLine("\n--- All Students using SqlDataAdapter and DataSet ---");
                
//                 string sqlQueryForDataSet = "SELECT Id, Name, Age, Course FROM Students";

//                 SqlDataAdapter adapter = new SqlDataAdapter(sqlQueryForDataSet, connection);

//                 DataSet ds = new DataSet();
//                 adapter.Fill(ds, "Students");

//                 if (ds.Tables.Contains("Students") && ds.Tables["Students"].Rows.Count > 0)
//                 {
//                     foreach (DataRow row in ds.Tables["Students"].Rows)
//                     {
//                         Console.WriteLine($"ID: {row["Id"]}, Name: {row["Name"]}, Age: {row["Age"]}, Course: {row["Course"]}");
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine("No data found in the Students table.");
//                 }

                
//                 // =========================================================================
//                 // Task 4: CALL STORED PROCEDURE using SqlCommand
//                 // =========================================================================
//                 Console.WriteLine("\n--- Students in Computer Science Course ---");
                
//                 SqlCommand cmdSP = new SqlCommand("GetStudentsByCourse", connection);
//                 cmdSP.CommandType = System.Data.CommandType.StoredProcedure;
//                 cmdSP.Parameters.AddWithValue("@Course", "Computer Science");
                
//                 SqlDataReader readerSP = cmdSP.ExecuteReader();

//                 while (readerSP.Read())
//                 {
//                     Console.WriteLine($"ID: {readerSP["Id"]}, Name: {readerSP["Name"]}, Age: {readerSP["Age"]}, Course: {readerSP["Course"]}");
//                 }

//                 readerSP.Close();


//                 // =========================================================================
//                 // Task 5: PARAMETERIZED QUERY (Prevents SQL Injection)
//                 // =========================================================================
//                 Console.WriteLine("\n--- Data for Rushikesh (using a parameterized query) ---");

//                 string sqlQueryForRushikesh = "SELECT Id, Name, Age, Course FROM Students WHERE Name = @Name";
//                 SqlCommand cmdForRushikesh = new SqlCommand(sqlQueryForRushikesh, connection);
                
//                 cmdForRushikesh.Parameters.AddWithValue("@Name", "Rushikesh");

//                 SqlDataReader readerRushikesh = cmdForRushikesh.ExecuteReader();

//                 if (readerRushikesh.HasRows)
//                 {
//                     while (readerRushikesh.Read())
//                     {
//                         Console.WriteLine($"ID: {readerRushikesh["Id"]}, Name: {readerRushikesh["Name"]}, Age: {readerRushikesh["Age"]}, Course: {readerRushikesh["Course"]}");
//                     }
//                 }
//                 else
//                 {
//                     Console.WriteLine("No student with the name 'Rushikesh' was found.");
//                 }

//                 readerRushikesh.Close();
                
//                 // =========================================================================
//                 // Task 6: WORKING WITH IN-MEMORY DATATABLES + DATASET (Disconnected Example)
//                 // =========================================================================
//                 Console.WriteLine("\n--- Working with In-Memory DataTables and DataSet ---");
                
//                 // Create DataTable 'customers'
//                 DataTable t1 = new DataTable("customers");
//                 t1.Columns.Add("custid", typeof(int));
//                 t1.Columns.Add("custname", typeof(string));
//                 t1.Columns.Add("price", typeof(int));
                
//                 t1.Rows.Add(101, "Ammu", 6000);
//                 t1.Rows.Add(102, "Tansi", 8000);
//                 t1.Rows.Add(103, "Cherry", 7000);

//                 // Create DataTable 'orders'
//                 DataTable t2 = new DataTable("orders");
//                 t2.Columns.Add("orderid", typeof(int));
//                 t2.Columns.Add("custid", typeof(int));
//                 t2.Columns.Add("orderdate", typeof(DateTime));
                
//                 t2.Rows.Add(1, 101, DateTime.Now);
//                 t2.Rows.Add(2, 102, DateTime.Now.AddDays(-1));
//                 t2.Rows.Add(3, 103, DateTime.Now.AddDays(-2));
//                 t2.Rows.Add(4, 101, DateTime.Now.AddDays(-3));
//                 t2.Rows.Add(5, 102, DateTime.Now.AddDays(-4));

//                 // Put both tables in a DataSet (in-memory database)
//                 DataSet ds1 = new DataSet();
//                 ds1.Tables.Add(t1);
//                 ds1.Tables.Add(t2);

//                 // Display tables
//                 foreach (DataTable t in ds1.Tables)
//                 {
//                     Console.WriteLine($"--- Table : {t.TableName} ---");
                    
//                     foreach (DataColumn column in t.Columns)
//                     {
//                         Console.Write($"{column.ColumnName}\t");
//                     }
//                     Console.WriteLine();

//                     foreach (DataRow row in t.Rows)
//                     {
//                         foreach (var item in row.ItemArray)
//                         {
//                             Console.Write($"{item}\t");
//                         }
//                         Console.WriteLine();
//                     }
//                     Console.WriteLine();
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine($"An error occurred: {ex.Message}");
//             }
//         }
//     }
// }
