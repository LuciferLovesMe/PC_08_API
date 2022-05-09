using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace PC_08_API.Models
{
    public class Utils
    {
        public static string conn = @"Data Source=DESKTOP-HUJGH1E\SQLEXPRESS;Initial Catalog=PC_08;Integrated Security=True";

        public static DataTable getdata(SqlCommand command)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(dt);
            return dt;
        }

        public static string encode(string s)
        {
            using (SHA256 sha = new SHA256Managed())
            {
                return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(s)));
            }
        }
    }

    public class LoginModel
    {
        public string username { set; get; }
        public string password { set; get; }
        public string name { set; get; }
        public int id { set; get; }
    }

    public class CheckOutModel
    {
        public int fdid { set; get; }
        public int qty { set; get; }
        public int empId { set; get; }
        public int roomId { set; get; }
        public int total { set; get; }
    }
}