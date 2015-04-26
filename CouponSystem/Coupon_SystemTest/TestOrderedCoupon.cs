using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestOrderedCoupon
    {
        OrderedCouponDataAccess or_da;
        OrderedCoupon ordCoup;

        CatalogCoupon cat1;
        Location l1;
        Category c1;
        CatalogCouponDataAccess ca_da;
        Users_SystemAdministrator uAdmin;
        Users_BuisnessOwner ub1;
        Buisness b1;
        User user1;
        User user2;
        User user3;
        Users_Customer uCos;

        [TestInitialize]
        public void TestInitOrderedCoupon()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();

            uAdmin = new Users_SystemAdministrator();
            user2 = new User();
            user2.userName = "admin";
            uCos = new Users_Customer();
            user3 = new User();
            user3.userName = "costumer";
            uCos.User = user3;
            uAdmin.User = user2;
            cat1 = new CatalogCoupon();
            cat1.catalogID = 123;
            cat1.Users_SystemAdministrator = uAdmin;
            cat1.CouponName = "free resert";
            user1 = new User();
            c1 = new Category();
            b1 = new Buisness();
            l1 = new Location();
            uCos.Location = l1;
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
            ordCoup = new OrderedCoupon();
            ordCoup.serialKey = "serialKey";
            ordCoup.CatalogCoupon = cat1;
            ordCoup.Users_Customer = uCos;

            or_da = new OrderedCouponDataAccess();

        }
        [TestMethod]
        public void addOrderedCoupon()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            TestBuisness.clearAllTable();
        }


        [TestMethod]
        public void removeOrderedCoupon()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            or_da.removeOrderedCoupons(ordCoup);
            Assert.IsFalse(or_da.existsOrderedCoupons(ordCoup));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateOrderedCouponRank()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            short newValue = 5;
            or_da.updateOrderedCouponRank(ordCoup, newValue);
            Assert.AreEqual(ordCoup.rank, newValue);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateOrderedCouponsCouponName()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            string newValue = "newName" ;
            or_da.updateOrderedCouponsCouponName(ordCoup, newValue);
            Assert.AreEqual(ordCoup.CatalogCoupon.CouponName, newValue);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateOrderedCouponsDeadLineForUse()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            DateTime newValue = new DateTime(2016, 1, 1);
            or_da.updateOrderedCouponsDeadLineForUse(ordCoup, newValue);
            Assert.AreEqual(ordCoup.CatalogCoupon.deadLineForUse, newValue);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updatOrderedCouponsPriceAfterDiscount()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            int newValue = 5;
            or_da.updatOrderedCouponsPriceAfterDiscount(ordCoup, newValue);
            Assert.AreEqual(ordCoup.CatalogCoupon.priceAfterDiscount, newValue);
            TestBuisness.clearAllTable();

        }


        [TestMethod]
        public void updateOrderedisUsed()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            bool newValue = true;
            or_da.updateOrderedisUsed(ordCoup, newValue);
            Assert.AreEqual(ordCoup.isUsed, newValue);
            TestBuisness.clearAllTable();
        }


        [TestMethod]
        public void updateOrderedCouponsDateOfPurchase()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            DateTime newValue = new DateTime(2014, 4, 1);
            or_da.updateOrderedCouponsDateOfPurchase(ordCoup, newValue);
            Assert.AreEqual(ordCoup.dateOfPurchase, newValue);
            TestBuisness.clearAllTable();
        }


        [TestMethod]
        public void updateOrderedCouponsDateOfUses()
        {
            or_da.addOrderedCoupons(ordCoup);
            Assert.IsTrue(or_da.existsOrderedCoupons(ordCoup));
            DateTime newValue = new DateTime(2013, 4,9);
            or_da.updateOrderedCouponsDateOfUse(ordCoup, newValue);
            Assert.AreEqual(ordCoup.dateOfUse, newValue);
            TestBuisness.clearAllTable();
        }


    }
}
