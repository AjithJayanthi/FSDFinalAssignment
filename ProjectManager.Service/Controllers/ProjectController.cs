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
    [RoutePrefix("Project")]
    public class ProjectController : ApiController
    {
        Project p1;
        public ProjectController()
        {
            p1 = new Project();
        }
        [Route("GetProjects")]
        [HttpGet]
        public List<ProjectModel> GetProject()
        {
            return p1.GetProject();
        }

        [Route("AddProject")]
        [HttpPost]
        public bool AddProject(ProjectModel project)
        {            
            return p1.AddProject(project);            
        }

        [Route("DeleteProject")]
        [HttpPost]
        public bool DeleteProject(ProjectModel project)
        {
            return p1.DeleteProject(project);
        }
    }
}
