using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using general_eye.Data;
using general_eye.Models;

namespace general_eye.Controllers
{
    public class usersController : Controller
    {
        private readonly general_eyeContext _context;

        public usersController(general_eyeContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> main_user()
        {
            return View();
        }

        public async Task<IActionResult> login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> login(string username,string userpass)
        {

            var q = await _context.user.AsNoTracking().Where(s => s.username == username).Where(s => s.userpass == userpass).ToListAsync();
            if(q.Count==0)
            {
                TempData["er"] = "auth";
                return View();
            }
            else
            {
                var q2 = q.FirstOrDefault();
                if (q2.admin == false)
                {
                    return RedirectToAction("main_user");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

        }



        // GET: users
        public async Task<IActionResult> Index()
        {
              return _context.user != null ? 
                          View(await _context.user.ToListAsync()) :
                          Problem("Entity set 'general_eyeContext.user' is null.");
        }





        // GET: users/Create
        public IActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("user_id,flname,username,userpass,admin")] user user)
        {
            var q = await _context.user.AsNoTracking().Where(s => s.username == user.username).ToListAsync();
            if (q.Count != 0) 
            {
                TempData["tekrari"] = "1";
                return View();
            }



            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            TempData["admin"] = user.admin;
            return View(user);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("user_id,flname,username,userpass,admin")] user user)
        {
            if (id != user.user_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userExists(user.user_id))
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
            return View(user);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.user_id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.user == null)
            {
                return Problem("Entity set 'general_eyeContext.user'  is null.");
            }
            var user = await _context.user.FindAsync(id);
            if (user != null)
            {
                _context.user.Remove(user);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userExists(long id)
        {
          return (_context.user?.Any(e => e.user_id == id)).GetValueOrDefault();
        }
    }
}
