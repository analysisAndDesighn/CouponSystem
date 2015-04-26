using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class Users_CustomerDataAccess
    {
         private CS_DBEntities3 db;

        public Users_CustomerDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addUsers_Customer(Users_Customer user)
        {
            db.Users_Customer.Add(user);
            db.SaveChanges();
        }

        public bool existsUsers_Customer(Users_Customer user)
        {
            Users_Customer b = db.Users_Customer.Find(user.userName);
            return (b != null);
        }

        public bool existsCategoryUsers_Customer(Users_Customer user, Category c)
        {
            Users_Customer b = db.Users_Customer.Find(user.userName);
            return (b.Categories.Contains(c));
        }

        public Users_Customer findUsers_Customer(Users_Customer user)
        {
            Users_Customer b = db.Users_Customer.Find(user.userName);
            return b;
        }

        public void removeUsers_Customer(Users_Customer user)
        {
            db.Users_Customer.Remove(user);
            db.SaveChanges();
        }

        public void updatePassword(Users_Customer user, string password)
        {
            db.Users_Customer.Find(user.userName).User.password = password;
            db.SaveChanges();
        }

        public void updateName(Users_Customer user, string name)
        {
            db.Users_Customer.Find(user.userName).User.fullName = name;
            db.SaveChanges();
        }

        public void updateEmail(Users_Customer user, string email)
        {
            db.Users_Customer.Find(user.userName).User.email = email;
            db.SaveChanges();
        }

        public void updatePhone(Users_Customer user, string phone)
        {
            db.Users_Customer.Find(user.userName).User.phone = phone;
            db.SaveChanges();
        }

        public void updateAge(Users_Customer user, short age)
        {
            db.Users_Customer.Find(user.userName).age = age;
            db.SaveChanges();
        }

        public void updateAge(Users_Customer user, string gender)
        {
            db.Users_Customer.Find(user.userName).gender = gender;
            db.SaveChanges();
        }

        public void updateLocation(Users_Customer user, Location loc)
        {
            db.Users_Customer.Find(user.userName).Location = loc;
            db.SaveChanges();
        }

        public void addCategory(Users_Customer user, Category c)
        {
            db.Users_Customer.Find(user.userName).Categories.Add(c);
            db.SaveChanges();
        }

        public void removeCategory(Users_Customer user, Category c)
        {
            db.Users_Customer.Find(user.userName).Categories.Remove(c);
            db.SaveChanges();
        }



    }
}
