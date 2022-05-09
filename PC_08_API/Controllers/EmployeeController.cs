using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PC_08_API.Models;

namespace PC_08_API.Controllers
{
    public class EmployeeController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        SqlCommand command;
        PC_08Entities row;

        [HttpPost]
        public IHttpActionResult result(LoginModel u)
        {
            string pass = Utils.encode(u.password);
            string sql = "select * from employee where username = '"+u.username+"' and password = '"+pass+"'";
            var user = row.Employees.SqlQuery(sql).FirstOrDefault();
            if (user != null)
            {
                u.username = user.Username;
                u.id = user.ID;
                u.name = user.Name;
                return Ok(u);
            }

            return null;
        }
    }
}
