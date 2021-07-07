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

        public HttpResponseMessage Get(int id) {
            DataTable dt = new DataTable();
            try
            {
                dt = user.userInformation(id);
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, e);
            }
        }

        public string Post(Users userData)
        {
            try
            {
                user.addUser(userData);
                return "Data Added successfully !!";
            }catch(Exception e){
                return "Failed to insert data: Exception :" + e;
            }
        }

        public string Put(Users userData)
        {
            try
            {
                user.updateUser(userData);
                return "Update Data successfull";
            }catch(Exception e)
            {
                return "Failed to Update data: Exception :" + e;
            }
        }

        public string Delete(Users userData)
        {
            try
            {
                user.deleteUser(userData);
                return "User Deleted Successfully";
            }catch(Exception e)
            {
                return "Delete Failed";
            }
        }
    }    
}

