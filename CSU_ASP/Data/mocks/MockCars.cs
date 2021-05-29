using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars 
        {
            get
            {
                return new List<Car>
                {
                    new Car { 
                        name = "Ford Mustang", 
                        shortDesc = "Настоящий американский маслкар", 
                        lonDesc = "Просто легендарный автомобиль от марки Форд", 
                        img = "/img/mustang.jpg", 
                        price = 7500000, 
                        isFavourite = true, 
                        available = true, 
                        Category = _categoryCars.AllCategories.Last()
                    },

                    new Car {
                        name = "Tesla Model X",
                        shortDesc = "Крутой кроссовер",
                        lonDesc = "Лучший кроссовер на электротяге от компании Tesla",
                        img = "/img/tesla-model-x.jpg",
                        price = 15000000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },

                    new Car {
                        name = "Nissan Leaf",
                        shortDesc = "Самый популярный электромобиль в России",
                        lonDesc = "Первый электрокар на территории нашей страны, произведенный Ниссаном",
                        img = "/img/nissan_leaf.jpg",
                        price = 1250000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },

                    new Car {
                        name = "Chevrolet Aveo",
                        shortDesc = "Тихо, надежно",
                        lonDesc = "Надежный и верный товарищ, подходящий для перемещения семьи",
                        img = "/img/aveo.jpg",
                        price = 300000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.First()
                    },

                    new Car {
                        name = "BMW M3",
                        shortDesc = "Легенда, просто Легенда!!!",
                        lonDesc = "Крутой автомобиль, дарящий кучу позитивных эмоций",
                        img = "/img/bmw.jpg",
                        price = 9000000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    },

                    new Car {
                        name = "Mersedes-Benz S-class",
                        shortDesc = "Авто премиум класса",
                        lonDesc = "Премиальный авто для депутатов, чиновников и бизнесменов",
                        img = "/img/mersedes.jpg",
                        price = 25000000,
                        isFavourite = true,
                        available = true,
                        Category = _categoryCars.AllCategories.Last()
                    }
                };
            }
        }
        public IEnumerable<Car> getFavCars { get ; set; }

        public Car getObjCar(int carID)
        {
            throw new NotImplementedException();
        }
    }
}
