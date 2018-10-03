using CommonEntities;
using CommonEntities.Interfaces;
using ProjectManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BusinessLayer
{
    public class Task : ITaskBusiness
    {
        private readonly ProjectManagerEntities dbContext = null;
        public Task()
        {
            dbContext = new ProjectManagerEntities();
        }

        public Task(ProjectManagerEntities dbContextdata)
        {
            dbContext = dbContextdata;
        }

        public bool AddTask(TaskModel Task)
        {

            try
            {
                if (Task.isParentTask)
                {
                    Parent_Task_Table parentTableData = new Parent_Task_Table();
                    Parent_Task_Table parentTable = new Parent_Task_Table
                    {
                        Parent_Task = Task.ParentTaskTitle
                    };
                    parentTableData = dbContext.Parent_Task_Table.Add(parentTable);
                    dbContext.SaveChanges();
                }
                else if (Task.Task_ID == 0)
                {
                    Parent_Task_Table parentTableData = new Parent_Task_Table();

                    Task_Table taskData = new Task_Table
                    {
                        Project_ID = Task.Project_ID,
                        Task = Task.Task,
                        Start_Date = Task.isParentTask ? null : Task.Start_Date,
                        End_Date = Task.isParentTask ? null : Task.End_Date,
                        Priority = Task.isParentTask ? null : (Task.Priority == null ? 0 : Task.Priority),
                        Parent_ID = Task.isParentTask ? parentTableData.Parent_ID : Task.Parent_ID,
                        Status = true
                    };

                    var taskAdded = dbContext.Task_Table.Add(taskData);
                    dbContext.SaveChanges();


                    var userData = dbContext.Users_Table.Where(c => c.User_ID == Task.User_ID).FirstOrDefault();
                    if (userData != null)
                    {
                        userData.Task_ID = taskAdded.Task_ID;
                        dbContext.SaveChanges();
                    }

                }
                else
                {
                    var taskData = dbContext.Task_Table.Where(c => c.Task_ID == Task.Task_ID).First();
                    if (taskData != null)
                    {
                        taskData.Project_ID = Task.Project_ID;
                        taskData.Task = Task.Task;
                        taskData.Start_Date = Task.isParentTask ? null : Task.Start_Date;
                        taskData.End_Date = Task.isParentTask ? null : Task.End_Date;
                        taskData.Priority = Task.isParentTask ? null : (Task.Priority == null ? 0 : Task.Priority);
                        taskData.Parent_ID = Task.isParentTask ? null : Task.Parent_ID;
                        taskData.Status = true;
                        dbContext.SaveChanges();

                        var userData = dbContext.Users_Table.Where(c => c.User_ID == Task.User_ID).FirstOrDefault();
                        if (userData != null)
                        {
                            userData.Task_ID = Task.Task_ID;
                            dbContext.SaveChanges();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;

        }

        public List<TaskModel> GetParentTasks()
        {
            List<TaskModel> task;
            try
            {
                task = dbContext.Parent_Task_Table.Select(s => new TaskModel { Parent_ID = s.Parent_ID, ParentTaskTitle = s.Parent_Task }).ToList();
            }
            catch (Exception e)
            {
                return new List<TaskModel>();
            }
            return task;

        }
        public List<TaskModel> getTasks(string sortingParameter)
        {
            List<TaskModel> tasks;
            try
            {
                tasks = dbContext.Task_Table.Where(c => c.Parent_ID == null).Select(s => new TaskModel { Task = s.Task, Project_ID = s.Project_ID, ParentTaskTitle = "", Priority = s.Priority, Start_Date = s.Start_Date, End_Date = s.End_Date, Task_ID = s.Task_ID, Status = s.Status, User_ID = dbContext.Users_Table.Where(u => u.Task_ID == s.Task_ID).Select(u => u.User_ID).FirstOrDefault() }).ToList();
                tasks.AddRange(dbContext.Task_Table.Where(c => c.Parent_ID != null).Join(dbContext.Parent_Task_Table, f => f.Parent_ID, s => s.Parent_ID, (f, s) => new TaskModel { Task = f.Task, Project_ID = f.Project_ID, ParentTaskTitle = s.Parent_Task, Priority = f.Priority, Start_Date = f.Start_Date, End_Date = f.End_Date, Parent_ID = s.Parent_ID, Task_ID = f.Task_ID, Status = f.Status, User_ID = dbContext.Users_Table.Where(u => u.Task_ID == f.Task_ID).Select(u => u.User_ID).FirstOrDefault() }).ToList());
                if (String.IsNullOrEmpty(sortingParameter) || sortingParameter == "sDate")
                {
                    tasks = tasks.OrderBy(o => o.Start_Date).ToList();
                }
                else if (sortingParameter == "eDate")
                {
                    tasks = tasks.OrderBy(o => o.End_Date).ToList();
                }
                else if (sortingParameter == "priority")
                {
                    tasks = tasks.OrderBy(o => o.Priority).ToList();
                }
                else if (sortingParameter == "completed")
                {
                    tasks = tasks.OrderBy(o => o.Status).ToList();
                }
            }
            catch (Exception e)
            {
                return new List<TaskModel>();
            }
            return tasks;
        }

        public Boolean endTask(TaskModel Task)
        {
            try
            {
                var result = dbContext.Task_Table.Where(c => c.Task_ID == Task.Task_ID).FirstOrDefault();
                result.Status = false;
                dbContext.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
