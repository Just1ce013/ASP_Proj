using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category> {
                    new Category { categoryName = "Электромобили", desc = "Современные автомобили на электротяге"},
                    new Category { categoryName = "Машины с ДВС", desc = "Автомобили с двигателями внутреннего сгорания"}
                };
            }
        }
    }
}
