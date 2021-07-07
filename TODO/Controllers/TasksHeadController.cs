using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace TODO.Controllers
{
    public class TasksHeadController : ApiController
    {
        // GET: TasksHead
        public HttpResponseMessage Get()
        {
            MySqlConnection connection = WebApiConfig.conn();
            string query = @"SELECT * from TasksHead";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }
    }
}