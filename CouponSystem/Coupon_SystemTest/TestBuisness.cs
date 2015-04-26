using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestBuisness
    {
        Buisness b1;
        Users_BuisnessOwner ub;
        User user1;
        Category c1;
        BuisnessDataAccess buisness_da;
        Location l;

        [TestInitialize]
        public void TestInitBuisness()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();

            user1 = new User();
            c1 = new Category();
            b1 = new Buisness();
            l = new Location();
            l.latitude = 34.8999;
            l.longitude = 45.3666;
            ub = new Users_BuisnessOwner();
            b1.BuisDescription = "Sushi bar";
            b1.buisAddress = "Aharom Meskin 13";
            b1.buisCity = "Beer-Sheva";
            b1.buisName = "JAPANIKA";
            user1.userName = "userName";
            c1.catName = "food";
            ub.User = user1;
            b1.Users_BuisnessOwner = ub;
            b1.Category = c1;
            b1.Location = l;
            buisness_da = new BuisnessDataAccess();

        }

        [TestMethod]
        public void addBuisness()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void removeBuisness()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            buisness_da.removeBuisness(b1);
            Assert.IsFalse(buisness_da.existsBuisness(b1));
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateBuisnessAddress()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            string newAddress = "Ehad Haam 12";
            buisness_da.updateAddress(b1, newAddress);
            Buisness afterUpdate = buisness_da.findBuisness(b1);
            Assert.AreEqual(newAddress, afterUpdate.buisAddress);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateBuisnessCity()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            string newCity = "Jerusalem";
            buisness_da.updateCity(b1, newCity);
            Buisness afterUpdate = buisness_da.findBuisness(b1);
            Assert.AreEqual(newCity, afterUpdate.buisCity);
            TestBuisness.clearAllTable();
        }

        public void updateBuisnessDescription()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            string newDescription = "Shusi and gril";
            buisness_da.updateDescription(b1, newDescription);
            Buisness afterUpdate = buisness_da.findBuisness(b1);
            Assert.AreEqual(newDescription, afterUpdate.BuisDescription);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateBuisnessCategory()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            Category newCategory = new Category();
            newCategory.catName = "sport";
            buisness_da.updateCategory(b1, newCategory);
            Buisness afterUpdate = buisness_da.findBuisness(b1);
            Assert.AreEqual(newCategory.catName, afterUpdate.Category.catName);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateBuisnessLocation()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            Location newLoc = new Location();
            newLoc.latitude = 34.5;
            newLoc.longitude = 31.8;
            buisness_da.updateLocation(b1, newLoc);
            Buisness afterUpdate = buisness_da.findBuisness(b1);
            Assert.AreEqual(newLoc.longitude, afterUpdate.Location.longitude);
            Assert.AreEqual(newLoc.latitude, afterUpdate.Location.latitude);
            TestBuisness.clearAllTable();
        }

        [TestMethod]
        public void updateBuisnessOwner()
        {
            buisness_da.addBuisness(b1);
            Assert.IsTrue(buisness_da.existsBuisness(b1));
            User u2 = new User();
            Users_BuisnessOwner owner = new Users_BuisnessOwner();
            u2.userName = "Moshe";
            owner.User = u2;
            buisness_da.updateOwner(b1, owner);
            Buisness afterUpdate = buisness_da.findBuisness(b1);
            Assert.AreEqual(owner.userName, afterUpdate.Users_BuisnessOwner.userName);
            TestBuisness.clearAllTable();
        }




        public static void clearAllTable()
        {
            using (var db = new CS_DBEntities3())
            {
                foreach (var cat in db.Categories)
                {
                    db.Entry(cat).Collection("Users_Customer").Load();

                    foreach (var item in db.Users_Customer)
                    {
                        cat.Users_Customer.Remove(item);
                    }
                }

                db.SaveChanges();

                var query1 = from b in db.Buisnesses
                             select b;
                foreach (var item in query1)
                {
                    db.Buisnesses.Remove(item);
                }

                var query2 = from b in db.Users
                             select b;
                foreach (var item in query2)
                {
                    db.Users.Remove(item);
                }

                var query3 = from b in db.Categories
                             select b;
                foreach (var item in query3)
                {
                    db.Categories.Remove(item);
                }

                var query4 = from b in db.Users_BuisnessOwner
                             select b;
                foreach (var item in query4)
                {
                    db.Users_BuisnessOwner.Remove(item);
                }

                var query5 = from b in db.Locations
                             select b;
                foreach (var item in query5)
                {
                    db.Locations.Remove(item);
                }

                var query6 = from b in db.CatalogCoupons
                             select b;
                foreach (var item in query6)
                {
                    db.CatalogCoupons.Remove(item);
                }

                var query7 = from b in db.CatalogCoupons_SocialNetworkCoupon
                             select b;
                foreach (var item in query7)
                {
                    db.CatalogCoupons_SocialNetworkCoupon.Remove(item);
                }

                var query8 = from b in db.OrderedCoupons
                             select b;
                foreach (var item in query8)
                {
                    db.OrderedCoupons.Remove(item);
                }

                var query9 = from b in db.Users_Customer
                             select b;
                foreach (var item in query9)
                {
                    db.Users_Customer.Remove(item);
                }

                var query10 = from b in db.Users_SystemAdministrator
                              select b;
                foreach (var item in query10)
                {
                    db.Users_SystemAdministrator.Remove(item);
                }
                db.SaveChanges();
            }

        }
    }
}
