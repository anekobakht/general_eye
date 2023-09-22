using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using general_cheshm.Data;
using general_cheshm.Models;

namespace general_cheshm.Controllers
{
    public class jensiatsController : Controller
    {
        private readonly general_cheshmContext _context;

        public jensiatsController(general_cheshmContext context)
        {
            _context = context;
        }

        // GET: jensiats
        public async Task<IActionResult> Index()
        {
              return _context.jensiat != null ? 
                          View(await _context.jensiat.ToListAsync()) :
                          Problem("Entity set 'general_cheshmContext.jensiat'  is null.");
        }

        // GET: jensiats/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.jensiat == null)
            {
                return NotFound();
            }

            var jensiat = await _context.jensiat
                .FirstOrDefaultAsync(m => m.id_jensiat == id);
            if (jensiat == null)
            {
                return NotFound();
            }

            return View(jensiat);
        }

        // GET: jensiats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: jensiats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_jensiat,name_jensiat")] jensiat jensiat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jensiat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jensiat);
        }

        // GET: jensiats/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.jensiat == null)
            {
                return NotFound();
            }

            var jensiat = await _context.jensiat.FindAsync(id);
            if (jensiat == null)
            {
                return NotFound();
            }
            return View(jensiat);
        }

        // POST: jensiats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_jensiat,name_jensiat")] jensiat jensiat)
        {
            if (id != jensiat.id_jensiat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jensiat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!jensiatExists(jensiat.id_jensiat))
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
            return View(jensiat);
        }

        // GET: jensiats/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.jensiat == null)
            {
                return NotFound();
            }

            var jensiat = await _context.jensiat
                .FirstOrDefaultAsync(m => m.id_jensiat == id);
            if (jensiat == null)
            {
                return NotFound();
            }

            return View(jensiat);
        }

        // POST: jensiats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.jensiat == null)
            {
                return Problem("Entity set 'general_cheshmContext.jensiat'  is null.");
            }
            var jensiat = await _context.jensiat.FindAsync(id);
            if (jensiat != null)
            {
                _context.jensiat.Remove(jensiat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool jensiatExists(long id)
        {
          return (_context.jensiat?.Any(e => e.id_jensiat == id)).GetValueOrDefault();
        }
    }
}
