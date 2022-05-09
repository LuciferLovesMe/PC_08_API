using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PC_08_API.Models;

namespace PC_08_API.Controllers
{
    public class FDController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        SqlCommand command;
        
        [HttpGet]
        public DataTable data()
        {
            command = new SqlCommand("select id, name, type, price from foodsAndDrinks", connection);
            return Utils.getdata(command);
        }
    }
}
