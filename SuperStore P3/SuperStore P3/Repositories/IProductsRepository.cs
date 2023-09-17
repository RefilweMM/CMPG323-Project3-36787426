using EcoPower_Logistics.Data;
using EcoPower_Logistics.Data.Repository;
using System.Linq.Expressions;
using Models;
using EcoPower_Logistics.Models;

namespace EcoPower_Logistics.Repository
{
    public interface IProductsRepository: IGenericRepository<Product>
    {
        Product GetMostRecentProduct();
    }

}
