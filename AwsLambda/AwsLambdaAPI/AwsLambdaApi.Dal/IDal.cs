using AwsLambdaApi.Models;
using System;
using System.Collections.Generic;

namespace AwsLambdaApi.Dal
{
    public interface IDal
    {
        List<Customer> GetCustomerData(string tableName, int pageSize, int pageNumber);

        List<Student> GetStudentData(string tableName, int pageSize, int pageNumber);
    }
}
