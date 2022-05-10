using AwsLambdaApi.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace AwsLambdaApi.Dal
{
    public class Dal:IDal
    {
        private string _connectionString;
        private IConfiguration _configuration;
        public Dal( IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("AwsLambda");
            
        }

        public List<Customer> GetCustomerData(string tableName,int pageSize,int pageNumber)
        {
            var custs = new List<Customer>();

            

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
               
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageSize", SqlDbType.Int).Value = pageSize;
                        command.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = tableName;
                        command.Parameters.AddWithValue("@PageNumber", SqlDbType.Int).Value = pageNumber;
                        var dataReader=command.ExecuteReader();

                       
                        while (dataReader.Read())
                        {
                            var employeeModel = new Customer
                            {
                                CustomerId = dataReader.GetInt32(dataReader.GetOrdinal("CustomerId")),
                                Name = dataReader.GetString(dataReader.GetOrdinal("name")),
                                
                            };
                            custs.Add(employeeModel);
                        }
                    }
                    connection.Close();

                    
                }
                catch(Exception ex)
                {
                    return new List<Customer> { new Customer { CustomerId = -999, Name = ex.Message } };
                }

                finally
                {
                    connection.Close();
                }
                return custs;
            }

        
        }


        public List<Student> GetStudentData(string tableName, int pageSize, int pageNumber)
        {
            var custs = new List<Student>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetData", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@PageSize", SqlDbType.Int).Value = pageSize;
                        command.Parameters.AddWithValue("@TableName", SqlDbType.NVarChar).Value = tableName;
                        command.Parameters.AddWithValue("@PageNumber", SqlDbType.Int).Value = pageNumber;
                        var dataReader = command.ExecuteReader();


                        while (dataReader.Read())
                        {
                            var employeeModel = new Student
                            {
                                StudentId = dataReader.GetInt32(dataReader.GetOrdinal("StudentId")),
                                Name = dataReader.GetString(dataReader.GetOrdinal("name")),

                            };
                            custs.Add(employeeModel);
                        }
                    }
                    connection.Close();


                }
                catch (Exception ex)
                {
                    return new List<Student> { new Student { StudentId = -999, Name = ex.Message } };
                }

                finally
                {
                    connection.Close();
                }
                return custs;
            }


        }
    }
}
