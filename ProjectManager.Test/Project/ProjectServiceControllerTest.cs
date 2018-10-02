using System;
using NUnit.Framework;
using ProjectManager.Service.Controllers;
using CommonEntities;
using System.Collections.Generic;
using ProjectManager.Test.Service;

namespace ProjectManager.Test
{
    [TestFixture]
    public class ProjectServiceControllerTest
    {
        #region Service controllers
        [Test]
        public void getProjectTest()
        {
            ProjectController project = new ProjectController(new MockProjectBusiness());

            List<ProjectModel> projectData = project.GetProject();

            foreach (var x in projectData)
            {
                Assert.IsNotNull(x.Project_ID);               
            }
        }

        [Test]
        public void addUsersTest()
        {
            ProjectController project = new ProjectController(new MockProjectBusiness());
            ProjectModel data = new ProjectModel()
            {
                Project_ID = 1,
                Project = "p5"
            };
            Assert.IsTrue(project.AddProject(data));
        }

        [Test]
        public void deleteUsersTest()
        {
            ProjectController project = new ProjectController(new MockProjectBusiness());
            ProjectModel data = new ProjectModel()
            {
                Project_ID = 1,
                Project = "p5"
            };
            Assert.IsTrue(project.DeleteProject(data));
        }

        #endregion
    }
}
