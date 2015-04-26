using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestUserBuisnessOwner
    {
        User user1;
        Users_BuisnessOwner ub;
        Users_BuisnessOwnerDataAccess buis_da;

        [TestInitialize]
        public void TestInitUser()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();
            buis_da = new Users_BuisnessOwnerDataAccess();
            user1 = new User();
            ub = new Users_BuisnessOwner();
            user1.userName = "blabla";
            user1.password = "123";
            user1.fullName = "avi ros";
            user1.phone = "052-1111111";
            user1.email = "email@jkjj.com";
            ub.User = user1;

        }
        [TestMethod]
        public void addUsers_BuisnessOwner()
        {
            buis_da.addUsers_BuisnessOwner(ub);
            Assert.IsTrue(buis_da.existsUsers_BuisnessOwner(ub));  
            TestBuisness.clearAllTable();
        }

        public void removeUsers_SystemAdministrator()
        {
            buis_da.addUsers_BuisnessOwner(ub);
            Assert.IsTrue(buis_da.existsUsers_BuisnessOwner(ub));
            buis_da.removeUsers_BuisnessOwner(ub);
            Assert.IsFalse(buis_da.existsUsers_BuisnessOwner(ub));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorName()
        {
            buis_da.addUsers_BuisnessOwner(ub);
            Assert.IsTrue(buis_da.existsUsers_BuisnessOwner(ub));
            String nwName = "Dor";
            buis_da.updateName(ub, nwName);
            Users_BuisnessOwner afterUpdate = buis_da.findUsers_BuisnessOwner(ub);
            Assert.AreEqual(nwName, ub.User.fullName);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorPassword()
        {
            buis_da.addUsers_BuisnessOwner(ub);
            Assert.IsTrue(buis_da.existsUsers_BuisnessOwner(ub));
            String nwPassword = "321";
            buis_da.updatePassword(ub, nwPassword);
            Users_BuisnessOwner afterUpdate = buis_da.findUsers_BuisnessOwner(ub);
            Assert.AreEqual(nwPassword, ub.User.password);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorEmail()
        {
            buis_da.addUsers_BuisnessOwner(ub);
            Assert.IsTrue(buis_da.existsUsers_BuisnessOwner(ub));
            String nwEmail = "Email@Email.com";
            buis_da.updateEmail(ub, nwEmail);
            Users_BuisnessOwner afterUpdate = buis_da.findUsers_BuisnessOwner(ub);
            Assert.AreEqual(nwEmail, ub.User.email);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateSystemAdministratorPhone()
        {
            buis_da.addUsers_BuisnessOwner(ub);
            Assert.IsTrue(buis_da.existsUsers_BuisnessOwner(ub));
            String nwPhone = "0009987766";
            buis_da.updatePhone(ub, nwPhone);
            Users_BuisnessOwner afterUpdate = buis_da.findUsers_BuisnessOwner(ub);
            Assert.AreEqual(nwPhone, ub.User.phone);
            TestBuisness.clearAllTable();
        }
    }
}
