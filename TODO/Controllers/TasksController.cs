using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace TODO.Controllers
{
    public class TasksController : ApiController
    {
        public HttpResponseMessage Get()
        {
            MySqlConnection connection = WebApiConfig.conn();
            string query = @"SELECT * FROM Tasks";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }    
    }
}
