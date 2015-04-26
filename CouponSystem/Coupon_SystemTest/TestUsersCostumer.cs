using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestUsersCostumer
    {
        User u1;
        Users_Customer uc1;
        Users_CustomerDataAccess customer_da;

        [TestInitialize]
        public void TestInitUserCostumer()
        {
            TestBuisness.clearAllTable();
            customer_da = new Users_CustomerDataAccess();
            u1 = new User();
            uc1 = new Users_Customer();
            u1.userName = "michab";
            u1.fullName = "michael B";
            u1.password = "66666";
            u1.phone = "45385748";
            u1.email = "email@email.com";
            uc1.User = u1;
            Location l = new Location();
            l.latitude = 34.8999;
            l.longitude = 45.3666;
            uc1.Location = l;
            uc1.gender = "Male";
            uc1.age = 20;
            
        }

        [TestMethod]
        public void addUserCostumer()
        {
            customer_da.addUsers_Customer(uc1);
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void removeUserCostumer()
        {
            customer_da.addUsers_Customer(uc1);
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            customer_da.removeUsers_Customer(uc1);
            Assert.IsFalse(customer_da.existsUsers_Customer(uc1));
            TestBuisness.clearAllTable();   
        }

         [TestMethod]
        public void updateCustomerName()
        {
            customer_da.addUsers_Customer(uc1);;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            String nwName = "Dor";
            customer_da.updateName(uc1, nwName);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.AreEqual(nwName, uc1.User.fullName);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCustomerPassword()
        {
            customer_da.addUsers_Customer(uc1);;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            String nwPassword = "321";
            customer_da.updatePassword(uc1, nwPassword);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.AreEqual(nwPassword, uc1.User.password);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCustomerEmail()
        {
            customer_da.addUsers_Customer(uc1);;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            String nwEmail = "Email@Email.com";
            customer_da.updateEmail(uc1, nwEmail);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.AreEqual(nwEmail, uc1.User.email);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCustomerPhone()
        {
            customer_da.addUsers_Customer(uc1);;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            String nwPhone = "0009987766";
            customer_da.updatePhone(uc1, nwPhone);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.AreEqual(nwPhone, uc1.User.phone);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCustomerLocation()
        {
            customer_da.addUsers_Customer(uc1); ;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            Location newLoc = new Location();
            newLoc.latitude = 34.5;
            newLoc.longitude = 31.8;
            customer_da.updateLocation(uc1, newLoc);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.AreEqual(newLoc.longitude, afterUpdate.Location.longitude);
            Assert.AreEqual(newLoc.latitude, afterUpdate.Location.latitude);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void addCustomerCategory()
        {
            customer_da.addUsers_Customer(uc1); ;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            Category c = new Category();
            c.catName = "food";
            customer_da.addCategory(uc1, c);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.IsTrue(customer_da.existsCategoryUsers_Customer(uc1, c));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void removeCustomerCategory()
        {
            customer_da.addUsers_Customer(uc1); ;
            Assert.IsTrue(customer_da.existsUsers_Customer(uc1));
            Category c = new Category();
            c.catName = "food";
            customer_da.addCategory(uc1, c);
            Users_Customer afterUpdate = customer_da.findUsers_Customer(uc1);
            Assert.IsTrue(customer_da.existsCategoryUsers_Customer(uc1, c));
            customer_da.removeCategory(uc1, c);
            Assert.IsFalse(customer_da.existsCategoryUsers_Customer(uc1, c));
            TestBuisness.clearAllTable();
        }
        
    }
}
