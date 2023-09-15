using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Data;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly SuperStoreContext _context;
        private readonly OrdersRepository _orderRepository;

        public OrdersController(SuperStoreContext context)
        {
            _context = context;
        }
        

        public OrdersController()
        {
            _orderRepository = new OrdersRepository(); // Initialize your repository here
        }

        // GET: Orders
        public IActionResult Index()
        {
            var orders = _orderRepository.GetAll();
            return View(orders);
        }

        // GET: Orders/Details/5
        public IActionResult Details(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _orderRepository.Create(order);
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }
        // GET: Orders/Edit/5
        public IActionResult Edit(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _orderRepository.Edit(order);
                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        // GET: Orders/Delete/5
        public IActionResult Delete(int id)
        {
            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_orderRepository.Exists(id))
            {
                _orderRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
