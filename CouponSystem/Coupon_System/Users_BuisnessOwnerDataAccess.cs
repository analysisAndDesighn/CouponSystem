using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class Users_BuisnessOwnerDataAccess
    {
        private CS_DBEntities3 db;

        public Users_BuisnessOwnerDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addUsers_BuisnessOwner(Users_BuisnessOwner b)
        {
            db.Users_BuisnessOwner.Add(b);
            db.SaveChanges();
        }

        public bool existsUsers_BuisnessOwner(Users_BuisnessOwner buis)
        {
            Users_BuisnessOwner b = db.Users_BuisnessOwner.Find(buis.userName);
            return (b != null);
        }

        public Users_BuisnessOwner findUsers_BuisnessOwner(Users_BuisnessOwner buis)
        {
            Users_BuisnessOwner b = db.Users_BuisnessOwner.Find(buis.userName);
            return b;
        }

        public void removeUsers_BuisnessOwner(Users_BuisnessOwner b)
        {
            db.Users_BuisnessOwner.Remove(b);
            db.SaveChanges();
        }

        public void updatePassword(Users_BuisnessOwner user, string password)
        {
            db.Users_BuisnessOwner.Find(user.userName).User.password = password;
            db.SaveChanges();
        }

        public void updateName(Users_BuisnessOwner user, string name)
        {
            db.Users_BuisnessOwner.Find(user.userName).User.fullName = name;
            db.SaveChanges();
        }

        public void updateEmail(Users_BuisnessOwner user, string email)
        {
            db.Users_BuisnessOwner.Find(user.userName).User.email = email;
            db.SaveChanges();
        }

        public void updatePhone(Users_BuisnessOwner user, string phone)
        {
            db.Users_BuisnessOwner.Find(user.userName).User.phone = phone;
            db.SaveChanges();
        }



    }
}
