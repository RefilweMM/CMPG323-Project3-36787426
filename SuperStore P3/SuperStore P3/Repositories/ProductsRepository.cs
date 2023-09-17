using Data;
using EcoPower_Logistics.Data.Repository;
using EcoPower_Logistics.Data.Migrations;
using EcoPower_Logistics.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Linq.Expressions;
using EcoPower_Logistics.Repository;
using EcoPower_Logistics.Models;
using System.Linq;

namespace EcoPower_Logistics.Data.Repository
{
    public class ProductsRepository : GenericRepository<Product>, IProductsRepository
    {
        public ProductsRepository(SuperStoreContext context) : base(context)
        {
        }

        public Product GetMostRecentProduct()
        {
            return _context.Products.OrderByDescending(product => product.ProductName).FirstOrDefault()!;
        }
    }
}
