using EcoPower_Logistics.Data.Repository;
using Models;
using EcoPower_Logistics.Models;

namespace EcoPower_Logistics.Repository
{
    public interface IDOrderDetailsRepository : IGenericRepository<OrderDetail>
    {
        OrderDetail GetMostRecentOrderDetail();
    }
}
