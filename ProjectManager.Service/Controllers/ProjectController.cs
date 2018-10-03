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
    [RoutePrefix("Project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectBusiness p1;
        public ProjectController()
        {
            p1 = new Project();
        }

        public ProjectController(IProjectBusiness project)
        {
            p1 = project;
        }

        [Route("GetProjects/{sortParameter?}")]
        [HttpGet]
        public List<ProjectModel> GetProject(string sortParameter)
        {
            return p1.GetProject(sortParameter);
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
