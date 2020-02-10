using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Data;

namespace WpfProject_Shipov
{
    class DataBase
    {
        SqlDataAdapter adapter;
        SqlConnection connection;

        public void AddToDataBase(ObservableCollection<Employee> emp)
        {
            try
            {
                var connectionStringBuilder = new SqlConnectionStringBuilder
                {
                    DataSource = @"(localdb)\MSSQLLocalDB",
                    InitialCatalog = "WPFPROJECT_Shipov",

                    Pooling = true
                };

                connection = new SqlConnection(connectionStringBuilder.ConnectionString);
                adapter = new SqlDataAdapter();

                SqlCommand command = new SqlCommand("SELECT Name, Salary FROM People", connection);
                adapter.SelectCommand = command;
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

        public void InsertDB()
        {
            SqlCommand command = new SqlCommand(@"INSERT FROM People (Name, Salary)
                                VALUES(@Name, @Salary); SET @ID = @@IDENTITY;",
                                connection);

            command.Parameters.Add("@Name", SqlDbType.NVarChar, -1, "Name");
            command.Parameters.Add("@Salary", SqlDbType.NVarChar, -1, "Salary");

            SqlParameter param = command.Parameters.Add("@ID", SqlDbType.Int, 0, "ID");

            param.Direction = ParameterDirection.Output;

            adapter.InsertCommand = command;
        }
    }
}
