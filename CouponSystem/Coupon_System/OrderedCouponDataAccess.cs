using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class OrderedCouponDataAccess
    {
        private CS_DBEntities3 db;

        public OrderedCouponDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addOrderedCoupons(OrderedCoupon newValue)
        {
            
            db.OrderedCoupons.Add(newValue);
            db.SaveChanges();
        }

        public bool existsOrderedCoupons(OrderedCoupon newValue)
        {
            OrderedCoupon b = db.OrderedCoupons.Find(newValue.serialKey);
            return (b != null);
        }

        public OrderedCoupon findOrderedCoupon(OrderedCoupon newValue)
        {
            OrderedCoupon b = db.OrderedCoupons.Find(newValue.serialKey);
            return b;
        }

        public void removeOrderedCoupons(OrderedCoupon newValue)
        {
            db.OrderedCoupons.Remove(newValue);
            db.SaveChanges();
        }

        public void updateOrderedCouponRank(OrderedCoupon newValue, short newRank)
        {
            db.OrderedCoupons.Find(newValue.serialKey).rank = newRank;
            db.SaveChanges();
        }


        public void updateOrderedCouponsCouponName(OrderedCoupon newValue, string newName)
        {
            db.OrderedCoupons.Find(newValue.serialKey).CatalogCoupon.CouponName = newName;
            db.SaveChanges();
        }

        public void updateOrderedCouponsDeadLineForUse(OrderedCoupon newValue, DateTime newTime)
        {
            db.OrderedCoupons.Find(newValue.serialKey).CatalogCoupon.deadLineForUse = newTime;
            db.SaveChanges();
        }

        public void updatOrderedCouponsPriceAfterDiscount(OrderedCoupon newValue, double newPrice)
        {
            db.OrderedCoupons.Find(newValue.serialKey).CatalogCoupon.priceAfterDiscount = newPrice;
            db.SaveChanges();
        }

        public void updateOrderedisUsed(OrderedCoupon newValue, bool isUsesd)
        {
            db.OrderedCoupons.Find(newValue.serialKey).isUsed = isUsesd;
            db.SaveChanges();
        }

        public void updateOrderedCouponsDateOfPurchase(OrderedCoupon newValue, DateTime newTime)
        {
            db.OrderedCoupons.Find(newValue.serialKey).dateOfPurchase = newTime;
            db.SaveChanges();
        }

        public void updateOrderedCouponsDateOfUse(OrderedCoupon newValue, DateTime newTime)
        {
            db.OrderedCoupons.Find(newValue.serialKey).dateOfUse = newTime;
            db.SaveChanges();
        }

    }
}
