using System;
using NUnit.Framework;
using ProjectManager.Service.Controllers;
using CommonEntities;
using System.Collections.Generic;
using ProjectManager.Test.Service;

namespace ProjectManager.Test
{
    [TestFixture]
    public class TaskServiceControllerTest
    {
        #region Service controllers
        [Test]
        public void getTaskTest()
        {
            TaskController task = new TaskController(new MockTaskBusiness());

            List<TaskModel> taskData = task.getTasks("FirstName");

            foreach (var x in taskData)
            {
                Assert.IsNotNull(x.Task_ID);               
            }
        }

        [Test]
        public void addTaskTest()
        {
            TaskController task = new TaskController(new MockTaskBusiness());
            TaskModel data = new TaskModel
            {
                Task = "Task1",
                Priority = 26,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now
            };
            Assert.IsTrue(task.AddTask(data));
        }

        [Test]
        public void deleteTaskTest()
        {
            TaskController task = new TaskController(new MockTaskBusiness());
            TaskModel data = new TaskModel
            {
                Task = "Task1",
                Priority = 26,
                Start_Date = DateTime.Now,
                End_Date = DateTime.Now
            };
            Assert.IsTrue(task.endTask(data));
        }

        [Test]
        public void GetParentTasksTest()
        {
            TaskController task = new TaskController(new MockTaskBusiness());
            List<TaskModel> taskData = task.GetParentTasks();
            Assert.IsNotNull(taskData[0].Parent_ID);
        }

        #endregion
    }
}
