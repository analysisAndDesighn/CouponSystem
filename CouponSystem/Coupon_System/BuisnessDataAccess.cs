using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class BuisnessDataAccess
    {
        private CS_DBEntities3 db;

        public BuisnessDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addBuisness(Buisness b)
        {
            db.Buisnesses.Add(b);
            db.SaveChanges();
        }

        public bool existsBuisness(Buisness buis)
        {
            Buisness b = db.Buisnesses.Find(buis.buisName);
            return (b != null);
        }

        public Buisness findBuisness(Buisness buis)
        {
            Buisness b = db.Buisnesses.Find(buis.buisName);
            return b;
        }

        public void removeBuisness(Buisness b)
        {
            db.Buisnesses.Remove(b);
            db.SaveChanges();
        }

        public void updateAddress(Buisness b, string address)
        {
            db.Buisnesses.Find(b.buisName).buisAddress = address;
            db.SaveChanges();
        }

        public void updateCity(Buisness b, string city)
        {
            db.Buisnesses.Find(b.buisName).buisCity = city;
            db.SaveChanges();
        }

        public void updateDescription(Buisness b, string description)
        {
            db.Buisnesses.Find(b.buisName).BuisDescription = description;
            db.SaveChanges();
        }

        public void updateOwner(Buisness b, Users_BuisnessOwner user)
        {
            db.Buisnesses.Find(b.buisName).Users_BuisnessOwner = user;
            db.SaveChanges();
        }

        public void updateLocation(Buisness b, Location loc)
        {
            db.Buisnesses.Find(b.buisName).Location = loc;
            db.SaveChanges();
        }

        public void updateCategory(Buisness b, Category c)
        {
            db.Buisnesses.Find(b.buisName).Category = c;
            db.SaveChanges();
        }
    }
}
