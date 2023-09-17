using Data;
using EcoPower_Logistics.Data.Repository;
using Models;
using System.Linq.Expressions;
using EcoPower_Logistics.Models;
using EcoPower_Logistics.Data;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailsRepository : GenericRepository<OrderDetail>, IDOrderDetailsRepository
    {
        public OrderDetailsRepository(SuperStoreContext context) : base(context)
        {
        }

        public OrderDetail GetMostRecentOrderDetail()
        {
            return _context.OrderDetails.OrderByDescending(orderdetail => orderdetail.Quantity).FirstOrDefault()!;
        }
    }

}
