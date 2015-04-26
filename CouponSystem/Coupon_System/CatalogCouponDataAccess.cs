using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class CatalogCouponDataAccess
    {
        private CS_DBEntities3 db;

        public CatalogCouponDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addCatalogCoupon(CatalogCoupon cp)
        {
            db.CatalogCoupons.Add(cp);
            db.SaveChanges();
        }


        public bool existsCatalogCoupon(CatalogCoupon cp)
        {
            CatalogCoupon cTemp = db.CatalogCoupons.Find(cp.catalogID);
            return (cTemp != null);
        }

        public CatalogCoupon findCatalogCoupon(CatalogCoupon cp)
        {
            CatalogCoupon cTmp = db.CatalogCoupons.Find(cp.catalogID);
            return cTmp;
        }

        public void removeCatalogCoupon(CatalogCoupon cp)
        {
            db.CatalogCoupons.Remove(cp);
            db.SaveChanges();
        }

        public void updateName(CatalogCoupon cp, string name)
        {
            db.CatalogCoupons.Find(cp.catalogID).CouponName = name;
            db.SaveChanges();
        }

        public void updateDescription(CatalogCoupon cp, string name)
        {
            db.CatalogCoupons.Find(cp.catalogID).description = name;
            db.SaveChanges();
        }

        public void updateOriginalPrice(CatalogCoupon cp, double newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).originalPrice = newValue;
            db.SaveChanges();
        }

        public void updatePriceAfterDiscount(CatalogCoupon cp, double newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).priceAfterDiscount = newValue;
            db.SaveChanges();
        }

        public void updateDeadlineForUser(CatalogCoupon cp, DateTime newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).deadLineForUse = newValue;
            db.SaveChanges();
        }

        public void updatAverageRank(CatalogCoupon cp, double newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).averageRank = newValue;
            db.SaveChanges();
        }

        public void updatAverageRank(CatalogCoupon cp, Location newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).Location = newValue;
            db.SaveChanges();
        }

        public void updatAverageRank(CatalogCoupon cp, Buisness newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).Buisness = newValue;
            db.SaveChanges();
        }

        public void updatAverageRank(CatalogCoupon cp, Category newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).Category = newValue;
            db.SaveChanges();
        }

        public void updatAverageRank(CatalogCoupon cp, Users_SystemAdministrator newValue)
        {
            db.CatalogCoupons.Find(cp.catalogID).Users_SystemAdministrator = newValue;
            db.SaveChanges();
        }

    }
}
