using MCC71.Models;
using MCC71.Repositories.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace MCC71
{
    class Program
    {
        SqlConnection sqlConnection;
        string ConnectionString = "Data Source=LAPTOP-IQE37H9B\\MSSQLSERVER01;Initial catalog=Link_VS_to_SSMS;User ID=MCC71;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Get(1);
            DivisionRepository divisionRepository = new DivisionRepository();

            Division division = new Division(6, "Machine Learning");

            //DELETE
            //sudah bisa
            //divisionRepository.Delete(7);

            //GET
            //Sudah Bisa
            //var data = divisionRepository.Get();
            //foreach (var item in data)
            //{
            //    Console.WriteLine("ID : "+item.Id);
            //    Console.WriteLine("Name : "+item.Name);
            //    Console.WriteLine();
            //}

            //GET BY
            //Sudah Bisa
            //divisionRepository.Get(3);

            //INSERT
            ////Sudah Bisa
            //divisionRepository.Insert(division);

            //UPDATE
            ////Sudah Bisa
            //divisionRepository.Update(division);

        }
        public void Get()
        {
            
            sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division";

                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("Id :" + sqlDataReader[0]);
                            Console.WriteLine("Name :" + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public void Get(int id)
        {
            
            sqlConnection = new SqlConnection(ConnectionString);

            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division WHERE Id=@id";

                SqlParameter ParameterId = new SqlParameter();
                ParameterId.ParameterName = "@id";
                ParameterId.SqlDbType = System.Data.SqlDbType.Int;
                ParameterId.Value = id;
                sqlCommand.Parameters.Add(ParameterId);

                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("Id :" + sqlDataReader[0]);
                            Console.WriteLine("Name :" + sqlDataReader[1]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                }

                sqlConnection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        public int  insert(Division division)
        {
            int result = 0;
            using(sqlConnection=new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlTransaction sqlTransaction=sqlConnection.BeginTransaction();
                
                SqlCommand sqlCommand=sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO Division (Name) VALUES (@Name);";

                    SqlParameter parameterName = new SqlParameter();
                    parameterName.ParameterName = "@Name";
                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterName.Value = division.Name;

                    sqlCommand.Parameters.Add(parameterName);

                    result = sqlCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {

                        Console.WriteLine(exRollback.Message); ;
                    }
                }
            }
            return result; 
        }

        public int update(Division division)
        {
            int result = 0;
            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE Division SET Name=@Name WHERE Id= @Id ;";

                    SqlParameter parameterName = new SqlParameter();
                    parameterName.ParameterName = "@Name";
                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterName.Value = division.Name;

                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@Id";
                    parameterId.SqlDbType = SqlDbType.NVarChar;
                    parameterId.Value = division.Id;
                    sqlCommand.Parameters.Add(parameterName);
                    sqlCommand.Parameters.Add(parameterId);
                    result = sqlCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {

                        Console.WriteLine(exRollback.Message); ;
                    }
                }
            }
            return result;
        }

        public int delete (int Id)
        {
            int result = 0;
            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();

                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "DELETE FROM Division WHERE Id=@Id ;";

                    SqlParameter parameterId = new SqlParameter();
                    parameterId.ParameterName = "@Id";
                    parameterId.SqlDbType = SqlDbType.Int;
                    parameterId.Value = Id;

                    sqlCommand.Parameters.Add(parameterId);
                    result = sqlCommand.ExecuteNonQuery();

                    sqlTransaction.Commit();

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {

                        Console.WriteLine(exRollback.Message); ;
                    }
                }
            }
            return result;
        }

    }
}