using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        private const string CONNECTIONSTRING = "Data Source=N205-10;Initial Catalog=Library;Integrated Security=True";
        static void Main(string[] args)
        {
            using (var sqlConnection = new SqlConnection(CONNECTIONSTRING))
            {
                try
                {
                    sqlConnection.Open();
                    var sqlCommand = "insert into AuthorBooks values " +
                        "(1, 12)," +
                        "(2, 13)," +
                        "(3, 14)," +
                        "(4, 15)," +
                        "(5, 16)";
                    //var sqlCommand = "select * from Authors";

                    using (var command = new SqlCommand(sqlCommand, sqlConnection))
                    {
                        var affectedRows = command.ExecuteNonQuery();
                        Console.WriteLine(affectedRows);

                        //var sqlDataReader = command.ExecuteReader();
                        //while (sqlDataReader.Read())
                        //{
                        //    Console.WriteLine(string.Format("{0} : {1}", sqlDataReader[0], sqlDataReader[1]));
                        //}
                    }
                }
                catch (SqlException exception)
                {
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine(string.Format("Соединение не установлено: {0}", exception));
                    }
                    Console.WriteLine(string.Format("Другая ошибка: {0}", exception));
                }
                finally 
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
