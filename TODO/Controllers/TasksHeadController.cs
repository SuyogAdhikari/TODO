using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;
using TODO.App_Start;
using TODO.Models;

namespace TODO.Controllers
{
    public class TasksHeadController : ApiController
    {
        TasksHead task = new TasksHead();
        // GET: TasksHead
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = task.listTasks();
            }catch(Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, e);
            }
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(TasksHead taskData)
        {
            try
            {
                task.addTask(taskData);
                return "Task added Successfully";
            }catch(Exception e)
            {
                return "Task addition failed. Exception : " + e ;
            }
        }

        public string Put(TasksHead taskData)
        {
            try
            {
                task.updateTaskName(taskData);
                return ("Task updated Successfully");
            }catch(Exception e)
            {
                return ("Task update failed. Exception : " + e);
            }
        }

        public string Delete(int Id)
        {
            try
            {
                TasksHead taskData = new TasksHead(Id);
                task.deleteTask(taskData);
                return ("Task deleted");
            }
            catch (Exception e)
            {
                return ("Delete Failed : " + e);
            }
        }
        
    }
}