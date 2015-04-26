using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    
    public class TestLocation
    {
        Location l1;
        Location l2;
        LocationDataAccess loc_da;
        [TestInitialize]
        public void TestInitLocation()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();

            l1 = new Location();
            l2 = new Location();
            l1.latitude = 1.11;
            l1.longitude = 1.21;
            l1.city = "Beer-Sheva";
            l2.latitude = 2.1;
            l2.longitude = 2.2;
            l2.city = "Tel-Aviv";
            loc_da =new  LocationDataAccess();
            
        }
        [TestMethod]
        public void addLocation()
        {
            loc_da.addLocation(l1);
            Assert.IsTrue(loc_da.existsLocation(l1));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void removeLocation()
        {
            loc_da.addLocation(l1);
            Assert.IsTrue(loc_da.existsLocation(l1));
            loc_da.removeLocation(l1);
            Assert.IsFalse(loc_da.existsLocation(l1));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateLocation()
        {
            loc_da.addLocation(l1);
            Assert.IsTrue(loc_da.existsLocation(l1));
            string str ="Ashdod";
            loc_da.updaetCity(l1, str);
            Assert.AreEqual(l1.city,str);
            TestBuisness.clearAllTable();
        }


    }
}
