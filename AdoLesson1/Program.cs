using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoLesson1
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Select and Connection Way 1

            //var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlConnection conn = new SqlConnection();
            //conn.ConnectionString = connectionString;

            //SqlDataReader reader = null;
            //try
            //{
            //    conn.Open();

            //    string query = "SELECT * FROM Authors";

            //    SqlCommand command=new SqlCommand(query, conn); 
            //    reader= command.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        Console.WriteLine($"{reader[0]}  -  {reader[1]}  -  {reader[2]}");
            //        Console.WriteLine();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if(reader != null)
            //    {
            //        reader.Close();
            //    }
            //    if(conn != null)
            //    {
            //        conn.Close();
            //    }
            //}

            #endregion



            #region Example 2
            //using (var conn=new SqlConnection())
            //{
            //    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    conn.ConnectionString=connectionString;
            //    conn.Open();

            //    SqlDataReader reader = null;

            //    string query = "SELECT * FROM Authors";
            //    using (var command=new SqlCommand(query,conn))
            //    {
            //        reader= command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            Console.WriteLine($"{reader[0]}  {reader[1]}  {reader[2]}");
            //            Console.WriteLine();
            //        }
            //    }
            //}
            #endregion


            #region Double Select
            //using (var conn = new SqlConnection())
            //{
            //    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    conn.ConnectionString = connectionString;
            //    conn.Open();

            //    SqlDataReader reader = null;

            //    string query = "SELECT * FROM Authors;SELECT * FROM Books;";
            //    using (var command = new SqlCommand(query, conn))
            //    {
            //        reader = command.ExecuteReader();

            //        bool hasShowed = false;
            //        do
            //        {
            //            Console.WriteLine("Total Records");
            //            while (reader.Read())
            //            {
            //                if (!hasShowed)
            //                {
            //                    hasShowed = true;
            //                    for (int i = 0; i < reader.FieldCount; i++)
            //                    {
            //                        Console.Write(reader.GetName(i).ToString() + "\t");
            //                    }
            //                    Console.WriteLine();
            //                }

            //                for (int i = 0; i < reader.FieldCount; i++)
            //                {
            //                    Console.Write(reader[i] + "\t");
            //                }
            //                Console.WriteLine();
            //            }

            //            hasShowed = false;

            //        } while (reader.NextResult());
            //    }
            //}


            #endregion


            #region Insert
            //using (var conn=new SqlConnection())
            //{
            //    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    conn.ConnectionString = connectionString;
            //    conn.Open();


            //    string query = $@" INSERT INTO Authors(Id,FirstName,LastName)
            //                VALUES(@id,@firstName,@lastName)";

            //    var paramId=new SqlParameter();
            //    paramId.ParameterName = "@id";
            //    paramId.SqlDbType = SqlDbType.Int;
            //    paramId.Value = 1111;

            //    var paramName=new SqlParameter();
            //    paramName.ParameterName = "@firstName";
            //    paramName.SqlDbType = SqlDbType.NVarChar;
            //    paramName.Value = "Elchin";

            //    var paramSurname = new SqlParameter();
            //    paramSurname.ParameterName = "@lastName";
            //    paramSurname.SqlDbType = SqlDbType.NVarChar;
            //    paramSurname.Value = "Quliyev";

            //    using (var command=new SqlCommand(query,conn))
            //    {
            //        command.Parameters.Add(paramId);
            //        command.Parameters.Add(paramName);
            //        command.Parameters.Add(paramSurname);

            //        var result=command.ExecuteNonQuery();
            //        Console.WriteLine($"{result} row affected");
            //    }

            //}
            #endregion

            #region Where with params

            //using (var conn = new SqlConnection())
            //{
            //    var connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //    conn.ConnectionString = connectionString;
            //    conn.Open();


            //    string query = @"SELECT * FROM Books
            //                    WHERE Pages>@pPage";

            //    var param = new SqlParameter();
            //    param.ParameterName = "@pPage";
            //    param.SqlDbType = SqlDbType.Int;
            //    param.Value = 100;

            //    SqlDataReader reader = null;
            //    using (var command=new SqlCommand(query,conn))
            //    {
            //        command.Parameters.Add(param);
            //        reader=command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            Console.WriteLine($"{reader[1]}  {reader[2]}");
            //            Console.WriteLine();
            //        }
            //    }
            //}

            #endregion


            #region Stored Procedure Call

            using (var conn = new SqlConnection())
            {
                var connectionString = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
                conn.ConnectionString = connectionString;
                conn.Open();

                SqlCommand cmd = new SqlCommand(StoredProcedures.ShowStudentByGroupId, conn);

                cmd.CommandType = CommandType.StoredProcedure;

                var param = new SqlParameter();
                param.SqlDbType = SqlDbType.Int;
                param.ParameterName = "@groupId";
                param.Value = 8;

                cmd.Parameters.Add(param);

                var reader=cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}  {reader[1]}  {reader[2]}\n");
                }

            }
            #endregion
        }
    }
}
