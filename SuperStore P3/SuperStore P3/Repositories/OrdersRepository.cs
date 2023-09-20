using Data;
using EcoPower_Logistics.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
using EcoPower_Logistics.Models;
using EcoPower_Logistics.Data;
using System.Linq;
//using static NuGet.Packaging.PackagingConstants;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrdersRepository
    {
        public OrdersRepository(SuperStoreContext context) : base(context)
        {
        }

        public Order GetMostRecentOrder()
        {
            return _context.Orders.OrderByDescending(order => order.OrderDate).FirstOrDefault()!;
        }
    }

}
