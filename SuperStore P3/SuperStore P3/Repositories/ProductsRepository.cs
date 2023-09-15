using Data;
using EcoPower_Logistics.Data.Repository;
using EcoPower_Logistics.Data.Migrations;
using EcoPower_Logistics.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
using EcoPower_Logistics.Repository;

namespace EcoPower_Logistics.Data.Repository
{
    public class ProductsRepository : GenericRepository<Product>
    {
        protected readonly SuperStoreContext _context;

        public ProductsRepository(SuperStoreContext context) : base(context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Set<Product>().Add(entity);
        }

        public void AddRange(IEnumerable<Product> entities)
        {
            _context.Set<Product>().AddRange(entities);
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return _context.Set<Product>().Where(expression);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Set<Product>().ToList();
        }

        public Product GetById(int id)
        {
            return _context.Set<Product>().Find(id);
        }

        public void Remove(Product entity)
        {
            _context.Set<Product>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _context.Set<Product>().RemoveRange(entities);
        }
    }
}
