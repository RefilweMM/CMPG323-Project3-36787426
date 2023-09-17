using System.Linq.Expressions;
using EcoPower_Logistics.Data;
using EcoPower_Logistics.Data.Repository;
using Models;
using EcoPower_Logistics.Models;

namespace EcoPower_Logistics.Repository
{
    public interface ICustomersRepository : IGenericRepository <Customer>
    {
        Customer GetMostRecentCustomer();

    }
}
