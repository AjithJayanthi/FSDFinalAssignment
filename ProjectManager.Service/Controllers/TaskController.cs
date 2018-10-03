using CommonEntities;
using CommonEntities.Interfaces;
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
        private readonly ITaskBusiness p1 = null;
        public TaskController()
        {
            p1 = new Task();
        }
        public TaskController(ITaskBusiness task)
        {
            p1 = task;
        }

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

        [Route("GetTasks/{sortingParameter?}")]
        [HttpGet]
        public List<TaskModel> getTasks(string sortingParameter)
        {
            return p1.getTasks(sortingParameter);
        }

        [Route("EndTask")]
        [HttpPost]
        public Boolean endTask(TaskModel Task)
        {
            return p1.endTask(Task);
        }        
    }
}
