using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon_System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coupon_SystemTest
{
    [TestClass]
    public class TestCategories
    {
        Category cat1;
        Category cat2;
        Category cat3;
        CategoryDataAccess cat_da;
        [TestInitialize]
        public void TestInitCategory()
        {
            //making sure the table is empty
            TestBuisness.clearAllTable();

            cat1 = new Category();
            cat2 = new Category();
            cat3 = new Category();
            cat1.catName = "food";
            cat2.catName = "sport";
            cat3.catName = "Entertaiment";
            cat_da = new CategoryDataAccess();
        }

        [TestMethod]
        public void addCategory()
        {
            cat_da.addCategory(cat1);
            Assert.IsTrue(cat_da.existsCategory(cat1));
            TestBuisness.clearAllTable();

        }
        [TestMethod]
        public void removeCategory()
        {
            cat_da.addCategory(cat2);
            Assert.IsTrue(cat_da.existsCategory(cat2));
            cat_da.removeCategory(cat2);
            Assert.IsFalse(cat_da.existsCategory(cat2));
            TestBuisness.clearAllTable();
        }
    }
}
