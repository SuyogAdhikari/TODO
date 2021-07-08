using System;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TODO.Models;

namespace TODO.Controllers
{
    public class TasksController : ApiController
    {
        Tasks tasks = new Tasks();
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = tasks.listTasks();
                return Request.CreateResponse(HttpStatusCode.OK, dt);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, e);
            }
        }    

        public string Post(Tasks taskData)
        {
            try
            {
                tasks.addTask(taskData);
                return "Task added successfully";
            }catch(Exception e)
            {
                return "Failed to add data " + e;
            }
        }

        public string Put(Tasks taskData)
        {
            try
            {
                tasks.updateTask(taskData);
                return "Task updated successfully";
            }catch(Exception e)
            {
                return "Task Updated failed, Exception : " + e;
            }
        }

        public string Delete(Tasks taskData)
        {
            try
            {
                tasks.deleteTasks(taskData);
                return "Task successfully deleted";
            }
            catch(Exception e)
            {
                return "Task deletion failed, Exception: " + e; 
            }
        }
    }
}
