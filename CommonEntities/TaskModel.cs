using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonEntities
{
    public class TaskModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaskModel()
        {
            
        }

        public long Task_ID { get; set; }
        public long? Parent_ID { get; set; }
        public long? Project_ID { get; set; }
        public string Task { get; set; }
        public System.DateTime? Start_Date { get; set; }
        public System.DateTime? End_Date { get; set; }
        public int? Priority { get; set; }
        public bool Status { get; set; }
        public long User_ID { get; set; }
        public bool isParentTask { get; set; }
        public string ParentTaskTitle { get; set; }

    }
}