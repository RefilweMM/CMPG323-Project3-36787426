using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class ProductsRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();

        // GET ALL: Products
        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

            // GET by ID: Product
            public Product GetById(int id)
            {
                return _context.Products.Find(id);
            }

            // CREATE: Product
            public void Create(Product product)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }

            // EDIT: Product
            public void Edit(Product product)
            {
                _context.Entry(product).State = EntityState.Modified;
                _context.SaveChanges();
            }

            // DELETE: Product by ID
            public void Delete(int id)
            {
                var product = _context.Products.Find(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    _context.SaveChanges();
                }
            }

            // EXISTS: Check if Product exists by ID
            public bool Exists(int id)
            {
                return _context.Products.Any(p => p.ProductId == id);
            }

    }
}
