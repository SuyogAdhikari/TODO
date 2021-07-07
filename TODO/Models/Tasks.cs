using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODO.Models
{
    public class Tasks
    {
        public int tasksID { get; set; }
        public int TasksNameId { get; set; }
        public string tasks { get; set; }
        public bool isCompleted { get; set; }
    }
}