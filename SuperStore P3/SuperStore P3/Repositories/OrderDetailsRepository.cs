using Data;
using EcoPower_Logistics.Data.Repository;
using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class OrderDetailRepository : GenericRepository<OrderDetail>
    {
        protected readonly SuperStoreContext _context;

        public OrderDetailRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }

        public void Add(OrderDetail entity)
        {
            _context.Set<OrderDetail>().Add(entity);
        }

        public void AddRange(IEnumerable<OrderDetail> entities)
        {
            _context.Set<OrderDetail>().AddRange(entities);
        }

        public IEnumerable<OrderDetail> Find(Expression<Func<OrderDetail, bool>> expression)
        {
            return _context.Set<OrderDetail>().Where(expression);
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.Set<OrderDetail>().ToList();
        }

        public OrderDetail GetById(int id)
        {
            return _context.Set<OrderDetail>().Find(id);
        }

        public void Remove(OrderDetail entity)
        {
            _context.Set<OrderDetail>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<OrderDetail> entities)
        {
            _context.Set<OrderDetail>().RemoveRange(entities);
        }
    }
}
