using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab5_Gadgets.Models;

namespace Lab5_Gadgets.Controllers
{
    public class customerController : Controller
    {
        private readonly GadgetContext _context;

        public customerController(GadgetContext context)
        {
            _context = context;
        }

        // GET: customers
        public async Task<IActionResult> Index()
        {
            return View(await _context.customer.ToListAsync());
        }

        // GET: customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.customer
                .FirstOrDefaultAsync(m => m.customerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("customerID,customerFName,customerLName,customerPhonenumber,customerEmail")] customer customer)
        {
            if (customer.vaildateInfo(customer.customerFName, customer.customerLName, customer.customerPhonenumber, customer.customerEmail) == true)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(customer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

                }
                return View(customer);
            }
            else
            {
                return View("fail");
            }
        }

        // GET: customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customerID,customerFName,customerLName,customerPhonenumber,customerEmail")] customer customer)
        {
            if (id != customer.customerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!customerExists(customer.customerID))
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
            return View(customer);
        }

        // GET: customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.customer
                .FirstOrDefaultAsync(m => m.customerID == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.customer.FindAsync(id);
            _context.customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool customerExists(int id)
        {
            return _context.customer.Any(e => e.customerID == id);
        }
    }
}