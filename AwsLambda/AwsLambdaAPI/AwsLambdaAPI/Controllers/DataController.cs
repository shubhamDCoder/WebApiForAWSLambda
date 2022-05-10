using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwsLambdaApi.Dal;
using Microsoft.AspNetCore.Mvc;

namespace AwsLambdaAPI.Controllers
{
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private IDal _dal;

        public DataController(IDal dal)
        {
            _dal = dal;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get([FromQuery]string tableName="Customer"
            ,[FromQuery]int pageSize=500,[FromQuery] int pageNumber=1)
        {
            if (tableName == "Customer")
            {
                var cust= _dal.GetCustomerData(tableName, pageSize, pageNumber);
                return Ok(cust);
            }
            if(tableName == "Student")
            {
                var stud = _dal.GetStudentData(tableName, pageSize, pageNumber);
                return Ok(stud);
            }
            else
            {
                return NotFound();
            }
        }

       
    }
}
