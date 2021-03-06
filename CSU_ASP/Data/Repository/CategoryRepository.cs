using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private AppDBContent appDBContent;

        public CategoryRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Category> AllCategories => appDBContent.Category;
    }
}
