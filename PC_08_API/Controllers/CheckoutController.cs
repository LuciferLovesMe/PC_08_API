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
    public class CheckoutController : ApiController
    {
        SqlConnection connection = new SqlConnection(Utils.conn);
        SqlCommand command;
        SqlDataReader reader;
        int reserId;

        [HttpPost]
        public string[] post(CheckOutModel c)
        {
            command = new SqlCommand("select top(1) id from reservationRoom order by id desc", connection);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            reserId = reader.GetInt32(0);
            connection.Close();

            command = new SqlCommand("insert into FDCheckOut values(" + reserId + ", " + c.fdid + ", " + c.qty + ", " + c.total + ", " + c.empId + ")", connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return new string[] { "Success" };
        }
    }
}
