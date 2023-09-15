using Data;
using EcoPower_Logistics.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;

namespace EcoPower_Logistics.Repository
{
    public class CustomersRepository : GenericRepository<Customer>
    {
        protected readonly SuperStoreContext _context;

        public CustomersRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            _context.Set<Customer>().AddRange(entities);
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> expression)
        {
            return _context.Set<Customer>().Where(expression);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _context.Set<Customer>().ToList();
        }

        public Customer GetById(int id)
        {
            return _context.Set<Customer>().Find(id);
        }

        public void Remove(Customer entity)
        {
            _context.Set<Customer>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Customer> entities)
        {
            _context.Set<Customer>().RemoveRange(entities);
        }
    }

}
