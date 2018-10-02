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
    class UserBusinessTet
    {

        [Test]
        public void GetUserTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var UserBL = new User(mockContext.Object);
            List<UsersModel> users = UserBL.GetUsers("FirstName");
            Assert.IsNotNull(users);
            foreach (var user in users)
            {
                Assert.IsNotNull(user.User_ID);
            }
        }

        [Test]
        public void AddUserTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var UserBL = new User(mockContext.Object);
            UsersModel data = new UsersModel()
            {
                Employee_ID = "5",
                First_Name = "firstName1",
                Last_Name = "lastName1"
            };
            Assert.IsTrue(UserBL.AddUser(data));
        }


        [Test]
        public void DeleteUserTestBL()
        {
            Mock<ProjectManagerEntities> mockContext = MockDataSetList();
            var UserBL = new User(mockContext.Object);
            UsersModel data = new UsersModel()
            {
                Employee_ID = "1",
                First_Name = "fs",
                Last_Name = "ls",
                User_ID = 1
            };
            Assert.IsTrue(UserBL.DeleteUser(data));
        }

        private static Mock<ProjectManagerEntities> MockDataSetList()
        {
            var data = new List<Users_Table>()
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

            var mockset = new Mock<DbSet<Users_Table>>();
            mockset.As<IQueryable<Users_Table>>().Setup(m => m.Provider).Returns(data.Provider);
            mockset.As<IQueryable<Users_Table>>().Setup(m => m.Expression).Returns(data.Expression);
            mockset.As<IQueryable<Users_Table>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockset.As<IQueryable<Users_Table>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            var mockContext = new Mock<ProjectManagerEntities>();
            mockContext.Setup(m => m.Users_Table).Returns(mockset.Object);

            return mockContext;
        }
    }
}
