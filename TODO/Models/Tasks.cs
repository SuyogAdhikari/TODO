using System.Data;
using MySql.Data.MySqlClient;

namespace TODO.Models
{
    public class Tasks : BaseModel
    {
        public int tasksID { get; set; }
        public int TasksNameId { get; set; }
        public string tasks { get; set; }
        public bool isCompleted { get; set; }

        public Tasks() { }
        public Tasks(int tasksID)
        {
            this.tasksID = tasksID;
        }

        public Tasks(int tasksID, string tasks)
        {
            this.tasksID = tasksID;
            this.tasks = tasks;
        }

        public Tasks(int TasksNameid, string tasks, bool isCompleted)
        {
            this.TasksNameId = TasksNameid;
            this.tasks = tasks;
            this.isCompleted = isCompleted;
        }

        public Tasks(int tasksID, int TasksNameid, string tasks, bool isCompleted) {
            this.tasksID = tasksID;
            this.TasksNameId = TasksNameid;
            this.tasks= tasks;
            this.isCompleted = isCompleted;
        }


        public DataTable listTasks()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT tasksID, tasks FROM Tasks", con);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public void addTask(Tasks tasks)
        {
            string query = @"Insert into Tasks (TasksNameId,tasks,isCompleted) values(@TasksNameId,@tasks, @isCompleted)";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@TasksNameId", MySqlDbType.VarChar, 500).Value = tasks.TasksNameId;
            cmd.Parameters.Add("@tasks", MySqlDbType.VarChar, 500).Value = tasks.tasks;
            cmd.Parameters.Add("@isCompleted", MySqlDbType.VarChar, 500).Value = tasks.isCompleted;

            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void updateTask(Tasks tasks)
        {
            string query = @"Update Tasks set tasks= @tasks where tasksID = @tasksID";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@tasksID", MySqlDbType.VarChar, 500).Value = tasks.tasksID;
            cmd.Parameters.Add("@tasks", MySqlDbType.VarChar, 500).Value = tasks.tasks;

            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void deleteTasks(Tasks tasks)
        {
            string query = @"Delete from Tasks where tasksID= @tasksID";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add("@tasksID", MySqlDbType.Int32).Value = tasks.tasksID;
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void taskDone(int taskId, bool isCompleted)
        {
            string query = @"Update Tasks set isCompleted = @isCompleted where tasksID= @tasksID";
            MySqlCommand cmd = new MySqlCommand(query, con);

            cmd.Parameters.Add("@tasksID", MySqlDbType.Int32).Value = taskId;
            cmd.Parameters.Add("@isCompleted", MySqlDbType.UInt64).Value = isCompleted;

            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }
    }
}