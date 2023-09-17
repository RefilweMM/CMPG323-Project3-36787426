using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using EcoPower_Logistics.Data;
using Models;
using EcoPower_Logistics.Repository;
using EcoPower_Logistics.Models;

namespace EcoPower_Logistics.Controllers
{
    [Authorize]
    public class OrderDetailsController : Controller
    {
        private readonly IDOrderDetailsRepository _orderdetailRepository;
        private readonly IOrdersRepository _orderRepository;
        private readonly IProductsRepository _productRepository;

        public OrderDetailsController(IDOrderDetailsRepository orderdetailRepository, IOrdersRepository orderRepository, IProductsRepository productRepository)
        {
            _orderdetailRepository = orderdetailRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;

        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            return View(_orderdetailRepository.GetAll());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = _orderdetailRepository.GetById(id);

            if (orderdetail == null)
            {
                return NotFound();
            }

            return View(orderdetail);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId");
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ProductName");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            _orderdetailRepository.Add(orderDetail);
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDetails/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderdetail = _orderdetailRepository.GetById(id);

            if (orderdetail == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "OrderId", "CategoryName", orderdetail.OrderId);
            ViewData["ProductId"] = new SelectList(_productRepository.GetAll(), "ProductId", "ZoneName", orderdetail.ProductId);
            return View(orderdetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetail orderDetail)
        {
            if (id != orderDetail.OrderDetailsId)
            {
                return NotFound();
            }
            try
            {
                _orderdetailRepository.Update(orderDetail);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderDetailExists(orderDetail.OrderDetailsId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDetails/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetail = _orderdetailRepository.GetById(id);

            if (orderDetail == null)
            {
                return NotFound();
            }

            return View(orderDetail);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = _orderdetailRepository.GetById(id);
            _orderdetailRepository.Remove(orderDetail);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _orderdetailRepository.Exists(id);
        }
    }
}
