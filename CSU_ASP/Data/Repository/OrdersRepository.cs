using CSU_ASP.Data.interfaces;
using CSU_ASP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent appDBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDBContent appDBContent, ShopCart shopCart)
        {
            this.appDBContent = appDBContent;
            this.shopCart = shopCart;
        }
        public void CreateOrder(Order _order)
        {
            _order.orderTime = DateTime.Now;
            appDBContent.Order.Add(_order);

            var items = shopCart.shopItems;

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    carID = el.car.id,
                    order = _order,
                    orderID = _order.id,
                    price = el.car.price
                };
                appDBContent.OrderDetail.Add(orderDetail);
            }
            appDBContent.SaveChanges();
        }
    }
}
