using CommonEntities;
using CommonEntities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Test.Service
{
    class MockUserBusiness:IUserBusiness
    {

        public MockUserBusiness()
        {

        }

        public bool AddUser(UsersModel user)
        {
            return true;
        }
        public List<UsersModel> GetUsers(string sortingParameter)
        {
            return new List<UsersModel>() { new UsersModel { Employee_ID = "1", First_Name = "qw", Last_Name = "yt" }, new UsersModel { Employee_ID = "2", First_Name = "hs", Last_Name = "gh" } };

        }

        public bool DeleteUser(UsersModel user)
        {
            return true;
        }
    }
}
