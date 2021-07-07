using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODO.Models
{
    public class Users
    {
        public int uid { get; set; }
        public string userName { get; set; }
        public string password { get; set; }

        public Users() { }
        public Users(int uid, string userName, string password)
        {
            this.uid = uid;
            this.userName = userName;
            this.password = password;
        }
    }
}