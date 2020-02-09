using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace WpfProject_Shipov
{
    class DataBase
    {
        string connectionString = @" Data Source=(localdb)\MSSQLLocalDB;
        Initial Catalog = WPFPROJECT_Shipov; 
        Integrated Security = True; 
        Pooling=False";

        public void AddToDataBase(ObservableCollection<Employee> emp)
        {
            try
            {
                for (int i = 0; i < emp.Count; i++)
                {
                    var sql = String.Format("INSERT INTO People (Name, Salary) " +
                                                "VALUES (N'{0}', '{1}')",
                                                emp[i].Name,
                                                emp[i].Salary);
                    Console.WriteLine(sql);

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand(sql, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("exit");
            }
        }

        public void ReadDataBase()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = @"SELECT * FROM People";

                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader.GetValue(0),4} | " +
                                          $"{reader["Name"],10} | " +
                                          $"{reader[2],15} | " +
                                          $"{reader[3],25} | ");
                    }
                    //connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



    }
}
