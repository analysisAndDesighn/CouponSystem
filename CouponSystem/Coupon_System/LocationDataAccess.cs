using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class LocationDataAccess
    {
        private CS_DBEntities3 db;

        public LocationDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addLocation(Location newValue)
        {
            db.Locations.Add(newValue);
            db.SaveChanges();
        }


        public bool existsLocation(Location newValue)
        {
            Location cTemp = db.Locations.Find(newValue.latitude, newValue.longitude);
            return (cTemp != null);
        }

        public Location findLocation(Location newValue)
        {
            Location cTmp = db.Locations.Find(newValue.latitude, newValue.longitude);
            return cTmp;
        }

        public void removeLocation(Location newValue)
        {
            db.Locations.Remove(newValue);
            db.SaveChanges();
        }

        public void updaetCity(Location newValue, string newCity)
        {
            db.Locations.Find(newValue.latitude, newValue.longitude).city = newCity;
            db.SaveChanges();
        }
    }
}
