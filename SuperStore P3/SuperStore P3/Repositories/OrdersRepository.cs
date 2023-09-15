using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository
    {
        protected readonly SuperStoreContext _context = new SuperStoreContext();

        // GET ALL: Orders
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        // GET by ID: Order
        public Order GetById(int id)
        {
            return _context.Orders.Find(id);
        }

        // CREATE: Order
        public void Create(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        // EDIT: Order
        public void Edit(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // DELETE: Order by ID
        public void Delete(int id)
        {
            var order = GetById(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        // EXISTS: Order by ID
        public bool Exists(int id)
        {
            return _context.Orders.Any(o => o.OrderId == id);
        }


    }
}
