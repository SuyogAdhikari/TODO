using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace TODO.Models
{
    public class TasksHead : BaseModel
    {
        public int tasksNameId { get; set; }
        public int uid { get; set; }
        public String taskname { get; set; }
        public bool isCompleted { get; set; }
        
        //Empty constructoor
        public TasksHead() { }

        //Task id only
        public TasksHead(int tasksNameId)
        {
            this.tasksNameId = tasksNameId;
        }

        //Task name and id
        public TasksHead(int tasksNameId, string taskname)
        {
            this.tasksNameId = tasksNameId;
            this.taskname = taskname;
        }

        //uid, taskname and isCompleted
        public TasksHead(int uid, string taskname, bool isCompleted)
        {
            this.uid = uid;
            this.taskname = taskname;
            this.isCompleted = isCompleted;
        }

        //taskId and isCompleted
        public TasksHead(int tasksNameId, bool isCompleted)
        {
            this.tasksNameId = tasksNameId;
            this.isCompleted = isCompleted;
        }

        //Complete constructor
        public TasksHead(int tasksNameId, int uid, string taskname, bool isCompleted)
        {
            this.tasksNameId = tasksNameId;
            this.uid = uid;
            this.taskname = taskname;
            this.isCompleted = isCompleted;
        }

        public DataTable listTasks()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tasksNameId, userName, taskname, isCompleted FROM TasksHead inner join Users on TasksHead.uid = Users.uid", con);

            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }  
        
        public void addTask(TasksHead task)
        {
            string query = @"Insert into TasksHead (uid, taskName, isCompleted) values(@uid, @taskName, @isCompleted)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = task.uid;
            cmd.Parameters.Add("@taskName", MySqlDbType.VarChar, 500).Value = task.taskname;
            cmd.Parameters.Add("@isCompleted", MySqlDbType.UInt64).Value = task.isCompleted;

            cmd.CommandType = CommandType.Text;
            Console.WriteLine(query);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

        }

        public void updateTaskName(TasksHead task)
        {
            string query = @"Update TasksHead set taskname = @taskname where tasksNameId = @taskNameId";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@taskNameId", MySqlDbType.Int32).Value = task.tasksNameId;
            cmd.Parameters.Add("@taskName", MySqlDbType.VarChar, 500).Value = task.taskname;

            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void deleteTask(TasksHead task)
        {
            string query = @"Delete from taskshead where tasksNameId = @tasksNameId";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@tasksNameId", MySqlDbType.Int32).Value = task.tasksNameId;

            cmd.CommandType = CommandType.Text;
            Console.WriteLine(task.tasksNameId);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void taskDone(int taskId, bool isCompleted)
        {
            
            string query = @"Update TasksHead set isCompleted = @isCompleted where tasksNameId = @taskNameId";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@taskNameId", MySqlDbType.Int32).Value = taskId;
            cmd.Parameters.Add("@isCompleted", MySqlDbType.UInt64).Value = isCompleted;

            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }
    }
}