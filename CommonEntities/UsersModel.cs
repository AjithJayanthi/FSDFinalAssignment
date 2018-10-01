using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommonEntities
{
    public class UsersModel
    {
        public long User_ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Employee_ID { get; set; }
        public Nullable<long> Project_ID { get; set; }
        public Nullable<long> Task_ID { get; set; }
    }
}