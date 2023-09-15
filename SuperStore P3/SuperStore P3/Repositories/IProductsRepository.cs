using EcoPower_Logistics.Data;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IProductsRepository <Products>
    {
        Products GetById(int id);
        IEnumerable<Products> GetAll();
        IEnumerable<Products> Find(Expression<Func<Products, bool>> expression);
        void Add(Products entity);
        void AddRange(IEnumerable<Products> entities);
        void Remove(Products entity);
        void RemoveRange(IEnumerable<Products> entities);

    }
}
