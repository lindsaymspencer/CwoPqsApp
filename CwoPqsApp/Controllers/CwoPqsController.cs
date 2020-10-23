using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CwoPqsApp.Data;
using CwoPqsApp.Models;

namespace CwoPqsApp.Controllers
{
    public class CwoPqsController : Controller
    {
        private readonly CwoPqsAppContext _context;

        public CwoPqsController(CwoPqsAppContext context)
        {
            _context = context;
        }

        // GET: CwoPqs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CwoPqs.ToListAsync());
        }

        // GET: CwoPqs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cwoPqs = await _context.CwoPqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cwoPqs == null)
            {
                return NotFound();
            }

            return View(cwoPqs);
        }

        // GET: CwoPqs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CwoPqs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] CwoPqs cwoPqs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cwoPqs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cwoPqs);
        }

        // GET: CwoPqs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cwoPqs = await _context.CwoPqs.FindAsync(id);
            if (cwoPqs == null)
            {
                return NotFound();
            }
            return View(cwoPqs);
        }

        // POST: CwoPqs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] CwoPqs cwoPqs)
        {
            if (id != cwoPqs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cwoPqs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CwoPqsExists(cwoPqs.Id))
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
            return View(cwoPqs);
        }

        // GET: CwoPqs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cwoPqs = await _context.CwoPqs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cwoPqs == null)
            {
                return NotFound();
            }

            return View(cwoPqs);
        }

        // POST: CwoPqs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cwoPqs = await _context.CwoPqs.FindAsync(id);
            _context.CwoPqs.Remove(cwoPqs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CwoPqsExists(int id)
        {
            return _context.CwoPqs.Any(e => e.Id == id);
        }
    }
}
