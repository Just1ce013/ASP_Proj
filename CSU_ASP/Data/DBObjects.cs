using CSU_ASP.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data
{
    public class DBObjects
    {

        public static void Initial(AppDBContent content)
        {
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(content => content.Value));

            if(!content.Car.Any())
                content.Car.AddRange(Cars.Select(content => content.Value));

            content.SaveChanges();
        }

        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Электромобили", desc = "Современные автомобили на электротяге"},
                        new Category { categoryName = "Машины с ДВС", desc = "Автомобили с двигателями внутреннего сгорания"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category el in list)
                        category.Add(el.categoryName, el);
                }

                return category;
            }
        }

        private static Dictionary<string, Car> cars;
        public static Dictionary<string, Car> Cars
        {
            get
            {
                if (cars == null)
                {
                    var list = new Car[]
                    {
                        new Car {
                        name = "Ford Mustang",
                        shortDesc = "Настоящий американский маслкар",
                        lonDesc = "Просто легендарный автомобиль от марки Форд",
                        img = "/img/mustang.jpg",
                        price = 7500000,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Машины с ДВС"]
                        },

                        new Car {
                            name = "Tesla Model X",
                            shortDesc = "Крутой кроссовер",
                            lonDesc = "Лучший кроссовер на электротяге от компании Tesla",
                            img = "/img/tesla-model-x.jpg",
                            price = 15000000,
                            isFavourite = true,
                            available = true,
                            Category = Categories["Электромобили"]
                        },

                        new Car {
                            name = "Nissan Leaf",
                            shortDesc = "Самый популярный электромобиль в России",
                            lonDesc = "Первый электрокар на территории нашей страны, произведенный Ниссаном",
                            img = "/img/nissan_leaf.jpg",
                            price = 1250000,
                            isFavourite = true,
                            available = true,
                            Category = Categories["Электромобили"]
                        },

                        new Car {
                            name = "Chevrolet Aveo",
                            shortDesc = "Тихо, надежно",
                            lonDesc = "Надежный и верный товарищ, подходящий для перемещения семьи",
                            img = "/img/aveo.jpg",
                            price = 300000,
                            isFavourite = true,
                            available = true,
                            Category = Categories["Машины с ДВС"]
                        },

                        new Car {
                            name = "BMW M3",
                            shortDesc = "Легенда, просто Легенда!!!",
                            lonDesc = "Крутой автомобиль, дарящий кучу позитивных эмоций",
                            img = "/img/bmw.jpg",
                            price = 9000000,
                            isFavourite = true,
                            available = true,
                            Category = Categories["Машины с ДВС"]
                        },

                        new Car {
                            name = "Mersedes-Benz S-class",
                            shortDesc = "Авто премиум класса",
                            lonDesc = "Премиальный авто для депутатов, чиновников и бизнесменов",
                            img = "/img/mersedes.jpg",
                            price = 25000000,
                            isFavourite = true,
                            available = true,
                            Category = Categories["Машины с ДВС"]
                        }
                    };

                    cars = new Dictionary<string, Car>();
                    foreach (Car el in list)
                        cars.Add(el.name, el);
                }

                return cars;
            }
        }
    }
}
