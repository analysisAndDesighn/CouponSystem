using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestUserSystemAdmisntrator
    {
        Users_SystemAdministratorDataAccess users_da;
        User user1;
        Users_SystemAdministrator us;

        [TestInitialize]
        public void TestInitUserSystemAdmisntrator()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();
            users_da = new Users_SystemAdministratorDataAccess();
            user1 = new User();
            us = new Users_SystemAdministrator();
            user1.userName = "David";
            user1.password = "123";
            user1.fullName = "avi ros";
            user1.email = "David@bla.com";
            user1.phone = "052-1111111";
            us.User = user1;

        }
        [TestMethod]
        public void addUsers_SystemAdministrator()
        {
            users_da.addUsers_SystemAdministrator(us);
            Assert.IsTrue(users_da.existsUsers_SystemAdministrator(us));  
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void removeUsers_SystemAdministrator()
        {
            users_da.addUsers_SystemAdministrator(us);
            Assert.IsTrue(users_da.existsUsers_SystemAdministrator(us));
            users_da.removeUsers_SystemAdministrator(us);
            Assert.IsFalse(users_da.existsUsers_SystemAdministrator(us));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorName()
        {
            users_da.addUsers_SystemAdministrator(us);
            Assert.IsTrue(users_da.existsUsers_SystemAdministrator(us));
            String nwName = "Dor";
            users_da.updateName(us, nwName);
            Users_SystemAdministrator afterUpdate = users_da.findUsers_SystemAdministrator(us);
            Assert.AreEqual(nwName, us.User.fullName);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorPassword()
        {
            users_da.addUsers_SystemAdministrator(us);
            Assert.IsTrue(users_da.existsUsers_SystemAdministrator(us));
            String nwPassword = "321";
            users_da.updatePassword(us, nwPassword);
            Users_SystemAdministrator afterUpdate = users_da.findUsers_SystemAdministrator(us);
            Assert.AreEqual(nwPassword, us.User.password);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorEmail()
        {
            users_da.addUsers_SystemAdministrator(us);
            Assert.IsTrue(users_da.existsUsers_SystemAdministrator(us));
            String nwEmail = "Email@Email.com";
            users_da.updateEmail(us, nwEmail);
            Users_SystemAdministrator afterUpdate = users_da.findUsers_SystemAdministrator(us);
            Assert.AreEqual(nwEmail, us.User.email);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorPhone()
        {
            users_da.addUsers_SystemAdministrator(us);
            Assert.IsTrue(users_da.existsUsers_SystemAdministrator(us));
            String nwPhone = "0009987766";
            users_da.updatePhone(us, nwPhone);
            Users_SystemAdministrator afterUpdate = users_da.findUsers_SystemAdministrator(us);
            Assert.AreEqual(nwPhone, us.User.phone);
            TestBuisness.clearAllTable();
        }

       
    }
}
