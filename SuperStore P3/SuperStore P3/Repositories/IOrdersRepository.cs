using EcoPower_Logistics.Data.Repository;
using System.Linq.Expressions;
using Models;
using EcoPower_Logistics.Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrdersRepository : IGenericRepository<Order>
    {
        Order GetMostRecentOrder();
    }
}
