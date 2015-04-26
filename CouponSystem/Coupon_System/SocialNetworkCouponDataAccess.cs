using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class SocialNetworkCouponDataAccess
    {
        private CS_DBEntities3 db;

        public SocialNetworkCouponDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addSocialNetworkCoupon(CatalogCoupons_SocialNetworkCoupon newValue)
        {
            db.CatalogCoupons_SocialNetworkCoupon.Add(newValue);
            db.SaveChanges();
        }

        public bool existsSocialNetworkCoupon(CatalogCoupons_SocialNetworkCoupon newValue)
        {
            CatalogCoupons_SocialNetworkCoupon b = db.CatalogCoupons_SocialNetworkCoupon.Find(newValue.socialCatalogID);
            return (b != null);
        }

        public CatalogCoupons_SocialNetworkCoupon findCatalogCoupons_SocialNetworkCoupon(CatalogCoupons_SocialNetworkCoupon newValue)
        {
            CatalogCoupons_SocialNetworkCoupon b = db.CatalogCoupons_SocialNetworkCoupon.Find(newValue.socialCatalogID);
            return b;
        }

        public void removeSocialNetworkCoupon(CatalogCoupons_SocialNetworkCoupon newValue)
        {
            db.CatalogCoupons_SocialNetworkCoupon.Remove(newValue);
            db.SaveChanges();
        }

        public void updateWebSite(CatalogCoupons_SocialNetworkCoupon newValue, string address)
        {
            db.CatalogCoupons_SocialNetworkCoupon.Find(newValue.socialCatalogID).origionWebsite = address;
            db.SaveChanges();
        }


        public void updateCouponName(CatalogCoupons_SocialNetworkCoupon newValue, string newName)
        {
            db.CatalogCoupons_SocialNetworkCoupon.Find(newValue.socialCatalogID).CatalogCoupon.CouponName = newName;
            db.SaveChanges();
        }

        public void updateDateTime(CatalogCoupons_SocialNetworkCoupon newValue, DateTime newTime)
        {
            db.CatalogCoupons_SocialNetworkCoupon.Find(newValue.socialCatalogID).CatalogCoupon.deadLineForUse = newTime;
            db.SaveChanges();
        }

        public void updatPriceAfterDiscount(CatalogCoupons_SocialNetworkCoupon newValue, double newPrice)
        {
            db.CatalogCoupons_SocialNetworkCoupon.Find(newValue.socialCatalogID).CatalogCoupon.priceAfterDiscount = newPrice;
            db.SaveChanges();
        }

    }
}
