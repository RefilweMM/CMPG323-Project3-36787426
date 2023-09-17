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
using EcoPower_Logistics.Data;
using EcoPower_Logistics.Repository;
using EcoPower_Logistics.Models;

namespace EcoPower_Logistics.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly ICustomersRepository _customerRepository;

        public CustomersController(ICustomersRepository customersRepository)
        {
            _customerRepository = customersRepository;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {     
            return View(_customerRepository.GetAll());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Create([Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            _customerRepository.Add(customer);
            return RedirectToAction(nameof(Index), true);
        }

        /// GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

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
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,CustomerTitle,CustomerName,CustomerSurname,CellPhone")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            try
            {
                _customerRepository.Update(customer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(customer.CustomerId))
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

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _customerRepository.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Remove(customer);
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _customerRepository.Exists(id);
        }
    }
}
