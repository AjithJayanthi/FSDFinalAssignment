using CommonEntities;
using CommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Test.Service
{
    class MockTaskBusiness:ITaskBusiness
    {

        public MockTaskBusiness()
        {

        }

        public bool AddTask(TaskModel task)
        {
            return true;
        }

        public List<TaskModel> GetParentTasks()
        {
            return new List<TaskModel> { new TaskModel { Parent_ID = 1, ParentTaskTitle = "Parent1" }, new TaskModel { Parent_ID = 2, ParentTaskTitle = "Parent2" } };
        }

        public List<TaskModel> getTasks(string sortingParameter)
        {
            return new List<TaskModel> { new TaskModel { Task_ID=1,Task="Task1" }, new TaskModel { Task_ID = 1, Task = "Task1" } };
        }

        public bool endTask(TaskModel Task)
        {
            return true;
        }
    }
}
