using Data;
using EcoPower_Logistics.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
using static NuGet.Packaging.PackagingConstants;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>
    {
        protected readonly SuperStoreContext _context;

        public OrdersRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Set<Order>().Add(entity);
        }

        public void AddRange(IEnumerable<Order> entities)
        {
            _context.Set<Order>().AddRange(entities);
        }

        public IEnumerable<Order> Find(Expression<Func<Order, bool>> expression)
        {
            return _context.Set<Order>().Where(expression);
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Set<Order>().ToList();
        }

        public Order GetById(int id)
        {
            return _context.Set<Order>().Find(id);
        }

        public void Remove(Order entity)
        {
            _context.Set<Order>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Order> entities)
        {
            _context.Set<Order>().RemoveRange(entities);
        }
    }
}
