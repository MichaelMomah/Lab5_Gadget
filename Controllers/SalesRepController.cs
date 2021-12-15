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
    public class SalesRepController : Controller
    {
        private readonly GadgetContext _context;

        public SalesRepController(GadgetContext context)
        {
            _context = context;
        }

        // GET: SalesReps
        public async Task<IActionResult> Index()
        {
            return View(await _context.salesRep.ToListAsync());
        }

        // GET: SalesReps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRep = await _context.salesRep
                .FirstOrDefaultAsync(m => m.salesRepID == id);
            if (salesRep == null)
            {
                return NotFound();
            }

            return View(salesRep);
        }

        // GET: SalesReps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesReps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("salesRepID,salesRepFName,salesRepLName,salesRepExt")] SalesRep salesRep)
        {
            if (salesRep.vaildatesalesrep(salesRep.salesRepFName, salesRep.salesRepLName, salesRep.salesRepExt))
            {
                if (ModelState.IsValid)
                {
                    _context.Add(salesRep);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(salesRep);
            }
            else
            {
                return View("fail");
            }
        }

        // GET: SalesReps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRep = await _context.salesRep.FindAsync(id);
            if (salesRep == null)
            {
                return NotFound();
            }
            return View(salesRep);
        }

        // POST: SalesReps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("salesRepID,salesRepFName,salesRepLName,salesRepExt")] SalesRep salesRep)
        {
            if (id != salesRep.salesRepID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesRep);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesRepExists(salesRep.salesRepID))
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
            return View(salesRep);
        }

        // GET: SalesReps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesRep = await _context.salesRep
                .FirstOrDefaultAsync(m => m.salesRepID == id);
            if (salesRep == null)
            {
                return NotFound();
            }

            return View(salesRep);
        }

        // POST: SalesReps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesRep = await _context.salesRep.FindAsync(id);
            _context.salesRep.Remove(salesRep);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesRepExists(int id)
        {
            return _context.salesRep.Any(e => e.salesRepID == id);
        }
    }
}
