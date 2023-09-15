using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class CustomersRepository
    {
            protected readonly SuperStoreContext _context = new SuperStoreContext();

            // GET ALL: Customers
            public IEnumerable<Customer> GetAll()
            {
                return _context.Customers.ToList();
            }
        // GET by ID: Customer
        public Customer GetById(int id)
        {
            return _context.Customers.Find(id);
        }

        // CREATE: Customer
        public void Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        // EDIT: Customer
        public void Edit(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE: Customer by ID
        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
            }
        }

        // EXISTS: Customer by ID
        public bool Exists(int id)
        {
            return _context.Customers.Any(c => c.CustomerId == id);
        }

    }

}
