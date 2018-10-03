using CommonEntities;
using CommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Test.Service
{
    class MockProjectBusiness:IProjectBusiness
    {

        public MockProjectBusiness()
        {

        }

        //public bool AddUser(UsersModel user)
        //{
        //    return true;
        //}
        //public List<UsersModel> GetUsers()
        //{
        //    return new List<UsersModel>() { new UsersModel { Employee_ID = "1", First_Name = "qw", Last_Name = "yt" }, new UsersModel { Employee_ID = "2", First_Name = "hs", Last_Name = "gh" } };

        //}

        //public bool DeleteUser(UsersModel user)
        //{
        //    return true;
        //}

        public bool AddProject(ProjectModel project)
        {
            return true;
        }

        public List<ProjectModel> GetProject(string sortingParamter)
        {
            return new List<ProjectModel>() { new ProjectModel { Project_ID = 1, Project = "P1", Start_Date = DateTime.Now, End_Time = DateTime.Now }, new ProjectModel { Project_ID = 2, Project = "P2", Start_Date = DateTime.Now, End_Time = DateTime.Now } };
        }

        public bool DeleteProject(ProjectModel project)
        {
            return true;
        }
    }
}
