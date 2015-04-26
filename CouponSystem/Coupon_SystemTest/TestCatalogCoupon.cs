using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestCatalogCoupon
    {

        CatalogCoupon cat1;
        Location l1;
        Category c1;
        CatalogCouponDataAccess ca_da;
        Users_SystemAdministrator uAdmin;
        Users_BuisnessOwner ub1;
        Buisness b1;
        User user1;
        User user2;

       [TestInitialize]
        public void TestInitCatalogCoupon()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();

            uAdmin = new Users_SystemAdministrator();
            user2 = new User();
            user2.userName = "admin";
            uAdmin.User = user2;
            cat1 = new CatalogCoupon();
            cat1.catalogID = 123;
            cat1.Users_SystemAdministrator = uAdmin;
            ca_da = new CatalogCouponDataAccess();
            cat1.CouponName = "free resert";
            user1 = new User();
            c1 = new Category();
            b1 = new Buisness();
            l1 = new Location();
            l1.latitude = 34.8999;
            l1.longitude = 45.3666;
            ub1 = new Users_BuisnessOwner();
            b1.BuisDescription = "Sushi bar";
            b1.buisAddress = "Aharom Meskin 13";
            b1.buisCity = "Beer-Sheva";
            b1.buisName = "JAPANIKA";
            user1.userName = "userName";
            c1.catName = "food";
            ub1.User = user1;
            b1.Users_BuisnessOwner = ub1;
            b1.Category = c1;
            b1.Location = l1;
            cat1.Category = c1;
            cat1.Location = l1;
            cat1.Buisness = b1;


        }
        [TestMethod]
        public void addCatalogCoupon(){
            ca_da.addCatalogCoupon(cat1);
            Assert.IsTrue(ca_da.existsCatalogCoupon(cat1));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void removeCatalogCoupon()
        {
            using (var db = new CS_DBEntities3())//adding user and category for test
            {

                ca_da.addCatalogCoupon(cat1);
                Assert.IsTrue(ca_da.existsCatalogCoupon(cat1));
                ca_da.removeCatalogCoupon(cat1);
                Assert.IsFalse(ca_da.existsCatalogCoupon(cat1));
                TestBuisness.clearAllTable();
            }
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCatalogCouponDescription()
        {
            using (var db = new CS_DBEntities3())//adding user and category for test
            {
                ca_da.addCatalogCoupon(cat1);
                Assert.IsTrue(ca_da.existsCatalogCoupon(cat1));
                string newDescription = "Shusi and gril";
                ca_da.updateDescription(cat1, newDescription);
                CatalogCoupon afterUpdate = ca_da.findCatalogCoupon(cat1);
                Assert.AreEqual(newDescription, afterUpdate.description);
                TestBuisness.clearAllTable();
            }
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCatalogCouponAverageRank()
        {
            using (var db = new CS_DBEntities3())//adding user and category for test
            {
                ca_da.addCatalogCoupon(cat1);
                Assert.IsTrue(ca_da.existsCatalogCoupon(cat1));
                double newValue  = 13;
                ca_da.updatAverageRank(cat1, newValue);
                CatalogCoupon afterUpdate = ca_da.findCatalogCoupon(cat1);
                Assert.AreEqual(newValue, afterUpdate.averageRank);
                TestBuisness.clearAllTable();
            }
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCatalogCouponPriceAfterDiscount()
        {
            using (var db = new CS_DBEntities3())//adding user and category for test
            {
                ca_da.addCatalogCoupon(cat1);
                Assert.IsTrue(ca_da.existsCatalogCoupon(cat1));
                double newValue = 5.54;
                ca_da.updatePriceAfterDiscount(cat1, newValue);
                CatalogCoupon afterUpdate = ca_da.findCatalogCoupon(cat1);
                Assert.AreEqual(newValue, afterUpdate.priceAfterDiscount);
                TestBuisness.clearAllTable();
            }
            TestBuisness.clearAllTable();
        }

    }
}
