using System;
using NUnit.Framework;
using ProjectManager.Service.Controllers;
using CommonEntities;
using System.Collections.Generic;
using ProjectManager.Test.Service;
using ProjectManager.Service;

namespace ProjectManager.Test
{
    [TestFixture]
    public class UnitTest1
    {
        #region Service controllers
        [Test]
        public void getUsersTest()
        {
            UserController user = new UserController(new MockUserBusiness());

            List<UsersModel> userData = user.GetUsers("FirstName");

            foreach (var x in userData)
            {
                Assert.IsNotNull(x.User_ID);
            }

            UserController user1 = new UserController();

        }

        [Test]
        public void addUsersTest()
        {
            UserController user = new UserController(new MockUserBusiness());
            UsersModel data = new UsersModel()
            {
                Employee_ID = "12",
                First_Name = "fn",
                Last_Name = "ls"
            };
            Assert.IsTrue(user.AddUser(data));
        }

        [Test]
        public void deleteUsersTest()
        {
            UserController user = new UserController(new MockUserBusiness());
            UsersModel data = new UsersModel()
            {
                Employee_ID = "12",
                First_Name = "fn",
                Last_Name = "ls"
            };

            Assert.IsTrue(user.DeleteUser(data));
        }

        #endregion
    }
}
