using CommonEntities;
using ProjectManager.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManager.Service.Controllers
{
    [RoutePrefix("Task")]
    public class TaskController : ApiController
    {
        Task p1;
        public TaskController()
        {
            p1 = new Task();
        }
        //[Route("GetTasks")]
        //[HttpGet]
        //public List<UsersModel> GetTasks()
        //{
        //    return p1.GetUsers();
        //}

        [Route("GetParentTasks")]
        [HttpGet]
        public List<TaskModel> GetParentTasks()
        {
            return p1.GetParentTasks();
        }

        [Route("AddTask")]
        [HttpPost]
        public bool AddTask(TaskModel Task)
        {
            return p1.AddTask(Task);
        }

        [Route("GetTask")]
        [HttpGet]
        public List<TaskModel> getTasks()
        {
            return p1.getTasks();
        }

        [Route("EndTask")]
        [HttpPost]
        public Boolean endTask(TaskModel Task)
        {
            return p1.endTask(Task);
        }

        //[Route("DeleteUser")]
        //[HttpPost]
        //public bool DeleteUser(UsersModel user)
        //{
        //    return p1.DeleteUser(user);
        //}
    }
}
