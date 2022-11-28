using MCC71.Context;
using MCC71.Models;
using MCC71.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC71.Repositories.Data
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        SqlConnection sqlConnection;
        string ConnectionString = "Data Source=LAPTOP-IQE37H9B\\MSSQLSERVER01;Initial catalog=Link_VS_to_SSMS;User ID=MCC71;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Department> Get()
        {
            sqlConnection = new SqlConnection(MyContext.GetConnection());
            List<Department> departments = new List<Department>();
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
                            Department department = new Department(Convert.ToInt32(sqlDataReader[0]), sqlDataReader[1].ToString(), Convert.ToInt32(sqlDataReader[2]));
                            departments.Add(department);
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
            return departments;
        }

        public int Get(int Id)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            int result = 0;
            try
            {
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division WHERE Id = @id;";

                SqlParameter ParameterId = new SqlParameter();
                ParameterId.ParameterName = "@id";
                ParameterId.SqlDbType = System.Data.SqlDbType.Int;
                ParameterId.Value = Id;
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
            return result;
        }

        public int Insert(Division division)
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
        public int Update(Division division)
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
        public int Delete(int Id)
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
