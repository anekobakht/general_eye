using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using general_cheshm.Data;
using general_cheshm.Models;
using System;

namespace general_cheshm.Controllers
{
    public class bakhshesController : Controller
    {
        private readonly general_cheshmContext _context;

        public bakhshesController(general_cheshmContext context)
        {
            _context = context;
        }

        // GET: bakhshes
        public async Task<IActionResult> Index()
        {
              return _context.bakhsh != null ? 
                          View(await _context.bakhsh.ToListAsync()) :
                          Problem("Entity set 'general_cheshmContext.bakhsh'  is null.");
        }

        // GET: bakhshes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: bakhshes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_bakhsh,name_bakhsh")] bakhsh bakhsh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bakhsh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bakhsh);
        }

        // GET: bakhshes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.bakhsh == null)
            {
                return NotFound();
            }

            var bakhsh = await _context.bakhsh.FindAsync(id);
            if (bakhsh == null)
            {
                return NotFound();
            }
            return View(bakhsh);
        }

        // POST: bakhshes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_bakhsh,name_bakhsh")] bakhsh bakhsh)
        {
            if (id != bakhsh.id_bakhsh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bakhsh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!bakhshExists(bakhsh.id_bakhsh))
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
            return View(bakhsh);
        }

        // GET: bakhshes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.bakhsh == null)
            {
                return NotFound();
            }

            var bakhsh = await _context.bakhsh
                .FirstOrDefaultAsync(m => m.id_bakhsh == id);
            if (bakhsh == null)
            {
                return NotFound();
            }
            return View(bakhsh);
        }

        // POST: bakhshes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.bakhsh == null)
            {
                return Problem("Entity set 'general_cheshmContext.bakhsh'  is null.");
            }
            var bakhsh = await _context.bakhsh.FindAsync(id);
            if (bakhsh != null)
            {
                _context.bakhsh.Remove(bakhsh);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool bakhshExists(long id)
        {
          return (_context.bakhsh?.Any(e => e.id_bakhsh == id)).GetValueOrDefault();
        }
    }
}
