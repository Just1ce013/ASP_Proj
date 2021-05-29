using CSU_ASP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSU_ASP.Data.interfaces
{
    public interface IAllOrders
    {
        void CreateOrder(Order _order);
    }
}
