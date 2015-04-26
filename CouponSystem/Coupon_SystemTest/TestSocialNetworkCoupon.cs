using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestSocialNetworkCoupon
    {
        SocialNetworkCouponDataAccess soCup_da;
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
        CatalogCoupons_SocialNetworkCoupon socCoup;
        Users_Customer uCos;

        [TestInitialize]
        public void TestInitSocialCoupon()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();

            uAdmin = new Users_SystemAdministrator();
            user2 = new User();
            user2.userName = "admin";
            uCos = new Users_Customer();
            user3=new User();
            user3.userName = "costumer";
            uCos.User = user3;
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
            socCoup = new CatalogCoupons_SocialNetworkCoupon();
            socCoup.CatalogCoupon = cat1;
            socCoup.Users_Customer = uCos;

            soCup_da = new SocialNetworkCouponDataAccess();

        }

        [TestMethod]
        public void addSocialNetwork()
        {
            soCup_da.addSocialNetworkCoupon(socCoup);
            Assert.IsTrue(soCup_da.existsSocialNetworkCoupon(socCoup));
            TestBuisness.clearAllTable();
        }


        [TestMethod]
        public void removeSocialNetwork()
        {
            soCup_da.addSocialNetworkCoupon(socCoup);
            Assert.IsTrue(soCup_da.existsSocialNetworkCoupon(socCoup));
            soCup_da.removeSocialNetworkCoupon(socCoup);
            Assert.IsFalse(soCup_da.existsSocialNetworkCoupon(socCoup));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateOriginWebsite()
        {
            soCup_da.addSocialNetworkCoupon(socCoup);
            Assert.IsTrue(soCup_da.existsSocialNetworkCoupon(socCoup));
            string newWeb = "www,test.co.il";
            soCup_da.updateWebSite(socCoup, newWeb);
            Assert.AreEqual(socCoup.origionWebsite,newWeb);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateCouponName()
        {
            soCup_da.addSocialNetworkCoupon(socCoup);
            Assert.IsTrue(soCup_da.existsSocialNetworkCoupon(socCoup));
            string newName = "AGADIR";
            soCup_da.updateCouponName(socCoup, newName);
            Assert.AreEqual(socCoup.CatalogCoupon.CouponName, newName);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updatePriceAfterDiscount()
        {
            soCup_da.addSocialNetworkCoupon(socCoup);
            Assert.IsTrue(soCup_da.existsSocialNetworkCoupon(socCoup));
            double newPrice = 8.9;
            soCup_da.updatPriceAfterDiscount(socCoup, newPrice);
            Assert.AreEqual(socCoup.CatalogCoupon.priceAfterDiscount, newPrice);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateDateTime()
        {
            soCup_da.addSocialNetworkCoupon(socCoup);
            Assert.IsTrue(soCup_da.existsSocialNetworkCoupon(socCoup));
            DateTime newDate = new DateTime(2020,1,1);
            soCup_da.updateDateTime(socCoup, newDate);
            Assert.AreEqual(socCoup.CatalogCoupon.deadLineForUse, newDate);
            TestBuisness.clearAllTable();
        }
    }
}
