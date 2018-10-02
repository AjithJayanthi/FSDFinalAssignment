using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataAccessLayer;
using System.Data.Entity;
using ProjectManager.BusinessLayer;
using System.Collections.ObjectModel;
using CommonEntities;

namespace ProjectManager.Test.Service
{
    [TestFixture]
    class ProjectBusinessTest
    {

        [Test]
        public void GetProjectTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var projectBL = new Project(mockContext.Object);
            List<ProjectModel> projects = projectBL.GetProject();
            Assert.IsNotNull(projects);
            foreach (var project in projects)
            {
                Assert.IsNotNull(project.Project_ID);
            }
        }

        [Test]
        public void AddProjectTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var projectBL = new Project(mockContext.Object);
            ProjectModel data = new ProjectModel()
            {
              Project="P5"
            };
            Assert.IsTrue(projectBL.AddProject(data));
        }


        [Test]
        public void DeleteProjectTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var projectBL = new Project(mockContext.Object);
            ProjectModel data = new ProjectModel()
            {
                Project = "P5"
            };
            Assert.IsTrue(projectBL.DeleteProject(data));
        }

        private static Mock<ProjectManagerEntities> MockDataSetList()
        {
            var data = new List<Project_Table>()
            {
               new Project_Table()
                {
                   Project_ID=1,
                   Project="P1"
                },
                new Project_Table()
                {
                    Project_ID=2,
                   Project="P2"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Project_Table>>();
            mockset.As<IQueryable<Project_Table>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<Project_Table>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Project_Table>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Project_Table>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var data2 = new List<Users_Table>()
            {
               new Users_Table()
                {
                    Employee_ID="1",
                    First_Name="fs",
                    Last_Name="ls",
                    User_ID=1
                },
                new Users_Table()
                {
                    Employee_ID="2",
                    First_Name="fs",
                    Last_Name="ls",
                    User_ID=2
                }
            }.AsQueryable();

            var mockset2 = new Mock<DbSet<Users_Table>>();
            mockset2.As<IQueryable<Users_Table>>().Setup(m => m.Provider).Returns(data2.Provider);
            mockset2.As<IQueryable<Users_Table>>().Setup(m => m.Expression).Returns(data2.Expression);
            mockset2.As<IQueryable<Users_Table>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            mockset2.As<IQueryable<Users_Table>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());


            var mockContext = new Mock<ProjectManagerEntities>();
            mockContext.Setup(m => m.Project_Table).Returns(mockset.Object);

            
           // var mockContext2 = new Mock<ProjectManagerEntities>();
            mockContext.Setup(m => m.Users_Table).Returns(mockset2.Object);



            return mockContext;
        }
    }
}
