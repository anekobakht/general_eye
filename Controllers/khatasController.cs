using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using general_cheshm.Models;
using general_cheshm.Data;

namespace general_cheshm.Controllers
{
    public class khatasController : Controller
    {
        private readonly general_cheshmContext _context;

        public khatasController(general_cheshmContext context)
        {
            _context = context;
        }

        // GET: khatas
        public async Task<IActionResult> Index()
        {
              return _context.khata != null ? 
                          View(await _context.khata.ToListAsync()) :
                          Problem("Entity set 'general_cheshmContext.khata'  is null.");
        }



        // GET: khatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: khatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_khata,num_khata,name_khata,sms")] khata khata)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khata);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khata);
        }

        // GET: khatas/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.khata == null)
            {
                return NotFound();
            }

            var khata = await _context.khata.FindAsync(id);
            if (khata == null)
            {
                return NotFound();
            }
            return View(khata);
        }

        // POST: khatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_khata,num_khata,name_khata,sms")] khata khata)
        {
            if (id != khata.id_khata)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khata);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!khataExists(khata.id_khata))
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
            return View(khata);
        }

        // GET: khatas/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.khata == null)
            {
                return NotFound();
            }

            var khata = await _context.khata
                .FirstOrDefaultAsync(m => m.id_khata == id);
            if (khata == null)
            {
                return NotFound();
            }

            return View(khata);
        }

        // POST: khatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.khata == null)
            {
                return Problem("Entity set 'general_cheshmContext.khata'  is null.");
            }
            var khata = await _context.khata.FindAsync(id);
            if (khata != null)
            {
                _context.khata.Remove(khata);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool khataExists(long id)
        {
          return (_context.khata?.Any(e => e.id_khata == id)).GetValueOrDefault();
        }
    }
}
