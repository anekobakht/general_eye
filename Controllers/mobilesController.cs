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
    public class mobilesController : Controller
    {
        private readonly general_cheshmContext _context;

        public mobilesController(general_cheshmContext context)
        {
            _context = context;
        }

        // GET: mobiles
        public async Task<IActionResult> Index()
        {
              return _context.mobile != null ? 
                          View(await _context.mobile.ToListAsync()) :
                          Problem("Entity set 'general_cheshmContext.mobile'  is null.");
        }

        // GET: mobiles/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.mobile == null)
            {
                return NotFound();
            }

            var mobile = await _context.mobile
                .FirstOrDefaultAsync(m => m.id_mobile == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // GET: mobiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mobiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_mobile,num_mobile,fname_mobile,lname_mobile")] mobile mobile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mobile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mobile);
        }




        // GET: mobiles/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.mobile == null)
            {
                return NotFound();
            }

            var mobile = await _context.mobile.FindAsync(id);
            if (mobile == null)
            {
                return NotFound();
            }
            return View(mobile);
        }

        // POST: mobiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_mobile,num_mobile,fname_mobile,lname_mobile")] mobile mobile)
        {
            if (id != mobile.id_mobile)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mobile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mobileExists(mobile.id_mobile))
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
            return View(mobile);
        }

        // GET: mobiles/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.mobile == null)
            {
                return NotFound();
            }

            var mobile = await _context.mobile
                .FirstOrDefaultAsync(m => m.id_mobile == id);
            if (mobile == null)
            {
                return NotFound();
            }

            return View(mobile);
        }

        // POST: mobiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.mobile == null)
            {
                return Problem("Entity set 'general_cheshmContext.mobile'  is null.");
            }
            var mobile = await _context.mobile.FindAsync(id);
            if (mobile != null)
            {
                _context.mobile.Remove(mobile);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mobileExists(long id)
        {
          return (_context.mobile?.Any(e => e.id_mobile == id)).GetValueOrDefault();
        }
    }
}
