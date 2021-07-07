using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TODO.Models;


namespace TODO.Controllers
{
    public class UsersController : ApiController
    {
        Users user = new Users();
        public HttpResponseMessage Get()
        {            
            DataTable dt = new DataTable();
            try
            {                
                dt = user.listUsers();
                return Request.CreateResponse(HttpStatusCode.OK,dt);
            }
            catch(Exception e) {
                return Request.CreateErrorResponse(HttpStatusCode.OK, e);
            }
        }

        public string post(Users userData)
        {
            try
            {
                user.addUser(userData);
                return "Data Added successfully !!";
            }catch(Exception e){
                return "Failed to insert data: Exception :" + e;
            }
        }
    }    
}

