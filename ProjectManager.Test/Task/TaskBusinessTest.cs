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
    class TaskBusinessTest
    {

        [Test]
        public void GetTaskTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var taskBL = new BusinessLayer.Task(mockContext.Object);
            List<TaskModel> tasks = taskBL.getTasks("FirstName");
            Assert.IsNotNull(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNotNull(task.Task_ID);
            }
            var taskBL1 = new BusinessLayer.Task();
        }

        [Test]
        public void GetParentTaskTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var taskBL = new BusinessLayer.Task(mockContext.Object);
            List<TaskModel> tasks = taskBL.GetParentTasks();
            Assert.IsNotNull(tasks);
            foreach (var task in tasks)
            {
                Assert.IsNotNull(task.Parent_ID);
            }
        }

        [Test]
        public void AddProjectTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var taskBL = new BusinessLayer.Task(mockContext.Object);
            TaskModel data = new TaskModel
            {
                Task = "Task1",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now,
                Priority = 26
            };
            Assert.IsFalse(taskBL.AddTask(data));

            TaskModel dataParent = new TaskModel
            {
                Task = "Task1",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now,
                Priority = 26,
                isParentTask = true
            };
            Assert.IsTrue(taskBL.AddTask(dataParent));

            TaskModel dataUpdate = new TaskModel
            {
                Task = "Task1",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now,
                Priority = 26,
                Task_ID = 1
            };
            Assert.IsFalse(taskBL.AddTask(dataUpdate));
        }


        [Test]
        public void DeleteTaskTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var taskBL = new BusinessLayer.Task(mockContext.Object);
            TaskModel data = new TaskModel
            {
                Task = "Task1",
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now,
                Priority = 26
            };
            Assert.IsFalse(taskBL.endTask(data));
        }

        private static Mock<ProjectManagerEntities> MockDataSetList()
        {
            var data = new List<Task_Table>()
            {
               new Task_Table()
                {
                   Task_ID=1,
                   Task="Task1"
                },
                new Task_Table()
                {
                     Task_ID=2,
                   Task="Task2"
                }
            }.AsQueryable();

            var mockset = new Mock<DbSet<Task_Table>>();
            mockset.As<IQueryable<Task_Table>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<Task_Table>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Task_Table>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Task_Table>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var data2 = new List<Parent_Task_Table>()
            {
               new Parent_Task_Table()
                {
                   Parent_ID=1,
                   Parent_Task="Parent1"
                },
                new Parent_Task_Table()
                {
                   Parent_ID=2,
                   Parent_Task="Parent2"
                }
            }.AsQueryable();

            var mockset2 = new Mock<DbSet<Parent_Task_Table>>();
            mockset2.As<IQueryable<Parent_Task_Table>>().Setup(m => m.Provider).Returns(data2.Provider);
            mockset2.As<IQueryable<Parent_Task_Table>>().Setup(m => m.Expression).Returns(data2.Expression);
            mockset2.As<IQueryable<Parent_Task_Table>>().Setup(m => m.ElementType).Returns(data2.ElementType);
            mockset2.As<IQueryable<Parent_Task_Table>>().Setup(m => m.GetEnumerator()).Returns(data2.GetEnumerator());


            var mockContext = new Mock<ProjectManagerEntities>();
            mockContext.Setup(m => m.Task_Table).Returns(mockset.Object);


            // var mockContext2 = new Mock<ProjectManagerEntities>();
            mockContext.Setup(m => m.Parent_Task_Table).Returns(mockset2.Object);



            return mockContext;
        }
    }
}
