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
    public class appointmentsController : Controller
    {
        private readonly GadgetContext _context;

        public appointmentsController(GadgetContext context)
        {
            _context = context;
        }

        // GET: appointments
        public async Task<IActionResult> Index()
        {
            var gadgetcontext = _context.appointment.Include(a => a.customer).Include(a => a.salesRep);
            return View(await gadgetcontext.ToListAsync());
        }

        // GET: appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointment
                .Include(a => a.customer)
                .Include(a => a.salesRep)
                .FirstOrDefaultAsync(m => m.appointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: appointments/Create
        public IActionResult Create()
        {
            ViewData["customerID"] = new SelectList(_context.customer, "customerID", "customerID");
            ViewData["salesRepID"] = new SelectList(_context.salesRep, "salesRepID", "fullname");
            return View();
        }

        // POST: appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("appointmentID,appointmentDate,salesRepID,customerID")] appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["customerID"] = new SelectList(_context.customer, "customerID", "customerID", appointment.customerID);
            ViewData["salesRepID"] = new SelectList(_context.salesRep, "salesRepID", "fullname", appointment.salesRepID);
            return View(appointment);
        }

        // GET: appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["customerID"] = new SelectList(_context.customer, "customerID", "customerID", appointment.customerID);
            ViewData["salesRepID"] = new SelectList(_context.salesRep, "salesRepID", "fullname", appointment.salesRepID);
            return View(appointment);
        }

        // POST: appointments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("appointmentID,appointmentDate,salesRepID,customerID")] appointment appointment)
        {
            if (id != appointment.appointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!appointmentExists(appointment.appointmentID))
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
            ViewData["customerID"] = new SelectList(_context.customer, "customerID", "customerID", appointment.customerID);
            ViewData["salesRepID"] = new SelectList(_context.salesRep, "salesRepID", "fullname", appointment.salesRepID);
            return View(appointment);
        }

        // GET: appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.appointment
                .Include(a => a.customer)
                .Include(a => a.salesRep)
                .FirstOrDefaultAsync(m => m.appointmentID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: appointments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.appointment.FindAsync(id);
            _context.appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool appointmentExists(int id)
        {
            return _context.appointment.Any(e => e.appointmentID == id);
        }
    }
}