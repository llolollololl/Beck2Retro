using Back2Retro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Retro.Dal
{
    public static class CategoryDal
    {
        public static List<Category> GetAll()
        {
            using (var db = new Back2RetroDbContext())
            {
                return db.Categories.ToList();
            }
        }

        public static Category GetCategoryById(int id)
        {
            using (var db = new Back2RetroDbContext())
            {
                return db.Categories.Find(id);
            }
        }
    }
}
