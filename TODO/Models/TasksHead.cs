using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TODO.Models
{
    public class TasksHead
    {
        public int tasksNameId { get; set; }
        public String taskname { get; set; }
        public bool isCompleted { get; set; }
    }
}