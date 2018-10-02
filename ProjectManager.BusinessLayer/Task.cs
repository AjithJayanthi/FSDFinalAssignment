using CommonEntities;
using ProjectManager.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.BusinessLayer
{
    public class Task
    {
        public Task()
        {

        }

        public bool AddTask(TaskModel Task)
        {
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                try
                {
                    if (Task.Task_ID == 0)
                    {
                        Parent_Task_Table parentTableData = new Parent_Task_Table();
                        if (Task.isParentTask)
                        {
                            Parent_Task_Table parentTable = new Parent_Task_Table
                            {
                                Parent_Task = Task.ParentTaskTitle
                            };
                            parentTableData = dbContext.Parent_Task_Table.Add(parentTable);
                            dbContext.SaveChanges();
                        }
                        Task_Table taskData = new Task_Table
                        {
                            Project_ID = Task.Project_ID,
                            Task = Task.Task,
                            Start_Date = Task.isParentTask ? null : Task.Start_Date,
                            End_Date = Task.isParentTask ? null : Task.End_Date,
                            Priority = Task.isParentTask ? null : Task.Priority,
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
                            taskData.Priority = Task.isParentTask ? null : Task.Priority;
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

        }

        public List<TaskModel> GetParentTasks()
        {
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                List<TaskModel> task;
                try
                {
                    task = dbContext.Task_Table.Where(c => c.Parent_ID != null)
                           .Select(c => new TaskModel { Parent_ID = (int)(dbContext.Parent_Task_Table.Where(s => s.Parent_ID == c.Parent_ID)
                           .Select(s => s.Parent_ID).FirstOrDefault()), ParentTaskTitle = (dbContext.Parent_Task_Table.Where(s => s.Parent_ID == c.Parent_ID)
                           .Select(s => s.Parent_Task).FirstOrDefault()), Task = c.Task }).ToList();
                }
                catch (Exception e)
                {
                    return new List<TaskModel>();
                }
                return task;
            }

        }
        public List<TaskModel> getTasks()
        {
            List<TaskModel> tasks;
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                
                
                try
                {
                    tasks = dbContext.Task_Table.Where(c => c.Parent_ID == null && c.Status ).Select(s => new TaskModel { Task = s.Task,Project_ID=s.Project_ID,ParentTaskTitle="",Priority=s.Priority,Start_Date= s.Start_Date,End_Date = s.End_Date,Task_ID=s.Task_ID }).ToList();
                    tasks.AddRange( dbContext.Task_Table.Where(c => c.Parent_ID != null && c.Status).Join(dbContext.Parent_Task_Table, f => f.Parent_ID, s => s.Parent_ID, (f, s) => new TaskModel { Task = f.Task, Project_ID = f.Project_ID, ParentTaskTitle = s.Parent_Task, Priority = f.Priority, Start_Date = f.Start_Date, End_Date = f.End_Date,Parent_ID=s.Parent_ID, Task_ID = f.Task_ID }).ToList());
                }
                catch(Exception e)
                {
                    return new List<TaskModel>();
                }
            }
                return tasks;
        }

        public Boolean endTask(TaskModel Task)
        {
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                try
                {
                    var result = dbContext.Task_Table.Where(c => c.Task_ID == Task.Task_ID).FirstOrDefault();
                    result.Status =false;
                    dbContext.SaveChanges();
                }
                catch
                {
                    return false;
                }
            }
                return true;
        }
        //public List<UsersModel> GetUsers()
        //{
        //    using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
        //    {
        //        List<UsersModel> users;
        //        try
        //        {
        //            users = dbContext.Users_Table.Select(c => new UsersModel { User_ID = c.User_ID, First_Name = c.First_Name, Last_Name = c.Last_Name, Employee_ID = c.Employee_ID }).ToList();
        //        }
        //        catch (Exception e)
        //        {
        //            return new List<UsersModel>();
        //        }
        //        return users;
        //    }

        //}

        //public bool DeleteUser(UsersModel user)
        //{
        //    using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
        //    {
        //        try
        //        {
        //            var userData = new Users_Table { User_ID = user.User_ID };
        //            dbContext.Entry(userData).State = EntityState.Deleted;
        //            dbContext.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }

        //}
    }
}
