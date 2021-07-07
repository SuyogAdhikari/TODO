using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using TODO.App_Start;

namespace TODO.Models
{    
    public class BaseModel
    {
        public MySqlConnection con = DBconnector.conn();
    }
}