using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using EcoPower_Logistics.Data;
using EcoPower_Logistics.Models;
using EcoPower_Logistics.Repository;

namespace EcoPower_Logistics.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        private readonly IOrdersRepository _orderRepository;
        private readonly ICustomersRepository _customerRepository;


        public OrdersController(IOrdersRepository orderRepository, ICustomersRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            return View(_orderRepository.GetAll());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
            ViewData["CustomerId"] = new SelectList(_customerRepository.GetAll(), "CustomerId", "CustomerName");
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,OrderDate,CustomerId,DelliveryAddress")] Order order)
        {
            _orderRepository.Add(order);
            return RedirectToAction(nameof(Index));
        }
        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var order = _orderRepository.GetById(id);

            if (order == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_orderRepository.GetAll(), "CustomerId", "CustomerName", order.CustomerId);
            return View(order);
        }

        // POST: Orders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,OrderDate,CustomerId,DelliveryAddress")] Order order)
        {

            if (id != order.OrderId)
            {
                return NotFound();
            }
            try
            {
                _orderRepository.Update(order);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.OrderId))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = _orderRepository.GetById(id);
            _orderRepository.Remove(order);
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _orderRepository.Exists(id);
        }
    }
}
