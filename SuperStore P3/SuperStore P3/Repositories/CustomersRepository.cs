using Data;
using EcoPower_Logistics.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
using EcoPower_Logistics.Models;
using EcoPower_Logistics.Data;

namespace EcoPower_Logistics.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomersRepository
    {
        public CustomerRepository(SuperStoreContext context) : base(context)
        {
        }

        public Customer GetMostRecentCustomer()
        {
            return _context.Customers.OrderByDescending(customer => customer.CustomerSurname).FirstOrDefault()!;
        }
    }

}
