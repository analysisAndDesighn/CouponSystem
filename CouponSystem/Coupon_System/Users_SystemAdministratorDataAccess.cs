using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class Users_SystemAdministratorDataAccess
    {
       private CS_DBEntities3 db;

        public Users_SystemAdministratorDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addUsers_SystemAdministrator(Users_SystemAdministrator user)
        {
            db.Users_SystemAdministrator.Add(user);
            db.SaveChanges();
        }

        public bool existsUsers_SystemAdministrator(Users_SystemAdministrator user)
        {
            Users_SystemAdministrator b = db.Users_SystemAdministrator.Find(user.userName);
            return (b != null);
        }

        public Users_SystemAdministrator findUsers_SystemAdministrator(Users_SystemAdministrator user)
        {
            Users_SystemAdministrator b = db.Users_SystemAdministrator.Find(user.userName);
            return b;
        }

        public void removeUsers_SystemAdministrator(Users_SystemAdministrator user)
        {
            db.Users_SystemAdministrator.Remove(user);
            db.SaveChanges();
        }

        public void updatePassword(Users_SystemAdministrator user, string password)
        {
            db.Users_SystemAdministrator.Find(user.userName).User.password = password;
            db.SaveChanges();
        }

        public void updateName(Users_SystemAdministrator user, string name)
        {
            db.Users_SystemAdministrator.Find(user.userName).User.fullName = name;
            db.SaveChanges();
        }

        public void updateEmail(Users_SystemAdministrator user, string email)
        {
            db.Users_SystemAdministrator.Find(user.userName).User.email = email;
            db.SaveChanges();
        }

        public void updatePhone(Users_SystemAdministrator user, string phone)
        {
            db.Users_SystemAdministrator.Find(user.userName).User.phone = phone;
            db.SaveChanges();
        }

    }
}
