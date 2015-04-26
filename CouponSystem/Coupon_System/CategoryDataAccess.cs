using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon_System
{
    public class CategoryDataAccess
    {
        private CS_DBEntities3 db;

        public CategoryDataAccess()
        {
            db = new CS_DBEntities3();
        }

        public void addCategory(Category cp)
        {
            db.Categories.Add(cp);
            db.SaveChanges();
        }


        public bool existsCategory(Category cp)
        {
            Category cTemp = db.Categories.Find(cp.catName);
            return (cTemp != null);
        }

        public Category findCategory(Category cp)
        {
            Category cTmp = db.Categories.Find(cp.catName);
            return cTmp;
        }

        public void removeCategory(Category cp)
        {
            db.Categories.Remove(cp);
            db.SaveChanges();
        }
    }
}
