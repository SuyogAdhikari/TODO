using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;


namespace TODO.Controllers
{
    public class UsersController : ApiController
    {
        public HttpResponseMessage Get()
        {           
            MySqlConnection con = WebApiConfig.conn();
            MySqlCommand cmd = new MySqlCommand("SELECT uid, userName FROM Users", con);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return Request.CreateResponse(HttpStatusCode.OK, dt);            
        }

        public void Put()
        {

        }
    }
}

