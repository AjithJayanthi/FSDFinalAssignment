using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonEntities
{
    public class ProjectModel
    {
        public ProjectModel()
        {
        }

        public long Project_ID { get; set; }
        public string Project { get; set; }
        public System.DateTime? Start_Date { get; set; }
        public System.DateTime? End_Time { get; set; }
        public int Priority { get; set; }
        public long User_ID { get; set; }
    }
}