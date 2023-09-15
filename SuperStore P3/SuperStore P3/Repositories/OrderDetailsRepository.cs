using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailsRepository
    {
        public interface IOrdersRepository<OrderDetail>
        {
            OrderDetail GetById(int id);
            IEnumerable<OrderDetail> GetAll();
            IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> expression);
            void Add(OrderDetail entity);
            void AddRange(IEnumerable<OrderDetail> entities);
            void Remove(OrderDetail entity);
            void RemoveRange(IEnumerable<OrderDetail> entities);
        }
    }
}
