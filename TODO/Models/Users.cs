using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using TODO.App_Start;

namespace TODO.Models
{
    public class Users : BaseModel
    {
        public int uid { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public Users() { }
        public Users(string userName, string password)
        {            
            this.userName = userName;
            this.password = password;
        }

        public Users(int uid, string userName)
        {
            this.uid = uid;
            this.userName = userName;
        }

        public Users(int uid)
        {
            this.uid = uid;            
        }


        public DataTable listUsers()
        {                       
            MySqlCommand cmd = new MySqlCommand("SELECT uid, userName FROM Users", con);
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;            
        }
        
        public void addUser(Users user)
        {
            string query = @"Insert into Users (userName,password) values(@userName, @password)";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add("@userName", MySqlDbType.VarChar, 500).Value = user.userName;
            cmd.Parameters.Add("@password", MySqlDbType.VarChar, 500).Value = user.password;
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }    
        
        public void updateUser(Users user)
        {
            string query = @"Update Users set userName = @userName where uid = @uid";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add("@userName", MySqlDbType.VarChar, 500).Value = user.userName;
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = user.uid;
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public void deleteUser(Users user)
        {
            string query = @"Delete from Users where uid = @uid";
            MySqlCommand cmd = new MySqlCommand(query, con);           
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = user.uid;
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
        }

        public DataTable userInformation(int uid)
        {
            string query = @"SELECT uid, userName FROM Users where uid = @uid";
            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.Parameters.Add("@uid", MySqlDbType.Int32).Value = uid;
            cmd.CommandType = CommandType.Text;
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}