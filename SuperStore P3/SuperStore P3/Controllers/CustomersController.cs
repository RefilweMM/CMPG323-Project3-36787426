using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Data;
using Models;
using EcoPower_Logistics.Repository;

namespace Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly SuperStoreContext _context;

        private readonly CustomersRepository _customerRepository;

        public CustomersController()
        {
            _customerRepository = new CustomersRepository(); // Initialize your repository here
        }

        // GET: Customers
        public IActionResult Index()
        {
            var customers = _customerRepository.GetAll();
            return View(customers);
        }

        // GET: Customers/Details/5
        public IActionResult Details(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }
        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _customerRepository.Create(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        /// GET: Customers/Edit/5
        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        /// POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _customerRepository.Edit(customer);
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customers == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_customerRepository.Exists(id))
            {
                _customerRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return NotFound();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}
