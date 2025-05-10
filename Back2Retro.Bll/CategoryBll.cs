using Back2Retro.Dal;
using Back2Retro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back2Retro.Bll
{
    public class CategoryBll
    {
        public static List<Category> GetAll()
        {
            return CategoryDal.GetAll();
        }

        public static Category GetCategoryById(int id)
        {
            Category category = CategoryDal.GetCategoryById(id);
            return category;
        }
    }
}
