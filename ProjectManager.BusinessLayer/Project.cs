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
    public class Project
    {
        public Project()
        {

        }

        public bool AddProject(ProjectModel project)
        {
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                try
                {
                    if (project.Project_ID == 0)
                    {
                        Project_Table projectData = new Project_Table()
                        {
                            Project = project.Project,
                            Start_Date = project.Start_Date == DateTime.MinValue ? null : project.Start_Date,
                            End_Time = project.End_Time == DateTime.MinValue ? null : project.End_Time,
                            Priority = project.Priority
                        };

                        Project_Table projectCreated = dbContext.Project_Table.Add(projectData);
                        dbContext.SaveChanges();

                        var userData = dbContext.Users_Table.Where(c => c.User_ID == project.User_ID).First();
                        if (userData != null)
                        {
                            userData.Project_ID = projectCreated.Project_ID;
                        }
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        var projectData = dbContext.Project_Table.Where(c => c.Project_ID == project.Project_ID).First();
                        if (projectData != null)
                        {
                            projectData.Project = project.Project;
                            projectData.Start_Date = project.Start_Date == DateTime.MinValue ? null : project.Start_Date;
                            projectData.End_Time = project.End_Time == DateTime.MinValue ? null : project.End_Time;
                            projectData.Priority = project.Priority;
                            dbContext.SaveChanges();
                        }

                        var userData = dbContext.Users_Table.Where(c => c.User_ID == project.User_ID).First();
                        if (userData != null)
                        {
                            userData.Project_ID = project.Project_ID;
                        }
                        dbContext.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }

        }

        public List<ProjectModel> GetProject()
        {
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                List<ProjectModel> projects;
                try
                {
                    projects = dbContext.Project_Table.Select(c => new ProjectModel { Project_ID = c.Project_ID, Start_Date = c.Start_Date, End_Time = c.End_Time, Priority = c.Priority, Project = c.Project,User_ID = dbContext.Users_Table.Where(s=>s.Project_ID == c.Project_ID).Select(s=>s.User_ID).FirstOrDefault() }).ToList();                    

                }
                catch (Exception e)
                {
                    return new List<ProjectModel>();
                }
                return projects;
            }

        }

        public bool DeleteProject(ProjectModel project)
        {
            using (ProjectManagerEntities dbContext = new ProjectManagerEntities())
            {
                try
                {
                    var userData = dbContext.Users_Table.Where(c => c.User_ID == project.User_ID).First();
                    userData.Project_ID = null;
                    dbContext.SaveChanges();
                    var projectData = new Project_Table { Project_ID = project.Project_ID };
                    dbContext.Entry(projectData).State = EntityState.Deleted;
                    dbContext.SaveChanges();
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }

        }
    }
}
