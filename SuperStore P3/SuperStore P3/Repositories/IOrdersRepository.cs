using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public interface IOrdersRepository <Orders>
    {
        Orders GetById(int id);
        IEnumerable<Orders> GetAll();
        IEnumerable<Orders> Find(Expression<Func<Orders, bool>> expression);
        void Add(Orders entity);
        void AddRange(IEnumerable<Orders> entities);
        void Remove(Orders entity);
        void RemoveRange(IEnumerable<Orders> entities);
    }
}
