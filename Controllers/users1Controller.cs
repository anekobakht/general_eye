using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using general_eye.Models;
using general_eye.Data;

namespace general_eye.Controllers
{
    public class usersController : Controller
    {
        private readonly general_eyeContext _context;

        public usersController(general_eyeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> sendsms()
        {
            var client = new AmootSMS.AmootSMSWebService2SoapClient(
            AmootSMS.AmootSMSWebService2SoapClient.EndpointConfiguration.AmootSMSWebService2Soap12,
            "https://portal.amootsms.com/webservice2.asmx");
            string UserName = "09127784722";
            string Password = "@Alireza17439";
            DateTime SendDateTime = DateTime.Now;
            string SMSMessageText = "پیامک تستی من";
            string LineNumber = "Service";
            string[] Mobiles = new string[]
            {
            "09127784722",
            };

            // AmootSMS.AmootSMSWebService2SoapClient client = new AmootSMS.AmootSMSWebService2SoapClient("AmootSMSWebService2Soap12");

            AmootSMS.SendResult result = client.SendSimpleAsync(UserName, Password, SendDateTime, SMSMessageText, LineNumber, Mobiles).Result;

            if (result.Status == AmootSMS.Status.Success)
            {
                //خروجی
            }

            return View("login");

        }
        public async Task<IActionResult> login()
        {
            return View(); 
                       
        }

        [HttpPost]
        public async Task<IActionResult> login(string u_username, string u_userpass)
        {
            if (string.IsNullOrEmpty(u_username))
            {
                ViewBag.er_auth = "1";
                return View();
            }
            if (string.IsNullOrEmpty(u_userpass))
            {
                ViewBag.er_auth = "1";
                return View();
            }
            else
            {
                //var q1 = _context.user.Where(s => s.u_username == u_username).Where(s => s.u_userpass == u_userpass);
                var q = _context.user.Where(s => s.u_username == u_username).Where(s => s.u_userpass == u_userpass).FirstOrDefault();
                if (string.IsNullOrEmpty(q.u_fname))
                {
                    ViewBag.er_auth = "1";
                    return View();
                }
                else
                {
                    HttpContext.Session.SetString("id_user", q.id_user.ToString());
                    HttpContext.Session.SetString("u_fname", q.u_fname.ToString());
                    HttpContext.Session.SetString("u_lname", q.u_lname.ToString());
                    HttpContext.Session.SetString("u_admin", q.u_admin.ToString());
                    
                    if (HttpContext.Session.GetString("u_admin").ToString() == "True")
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        HttpContext.Session.SetString("id_bakhsh", q.id_bakhsh.ToString());
                        return RedirectToAction("index_user","nevers");
                    }

                }

            }
        }

        // GET: users
        public async Task<IActionResult> Index()
        {
            return View(await _context.v_user.ToListAsync());
        }


        // GET: users/Create
        public IActionResult Create()
        {
            ViewBag.id_bakhsh = new SelectList(_context.bakhsh, "id_bakhsh", "name_bakhsh");
            return View();
        }

        // POST: users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_user,id_bakhsh,u_fname,u_lname,u_code_meli,u_email,u_username,u_userpass,u_admin")] user user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(user);
        }

        // GET: users/Edit/5
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
            ViewBag.id_bakhsh = new SelectList(_context.bakhsh, "id_bakhsh", "name_bakhsh",user.id_bakhsh);
            return View(user);
        }

        // POST: users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("id_user,id_bakhsh,u_fname,u_lname,u_code_meli,u_email,u_username,u_userpass,u_admin")] user user)
        {
            if (id != user.id_user)
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
                    if (!userExists(user.id_user))
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

        // GET: users/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.user == null)
            {
                return NotFound();
            }

            var user = await _context.user
                .FirstOrDefaultAsync(m => m.id_user == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: users/Delete/5
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
          return (_context.user?.Any(e => e.id_user == id)).GetValueOrDefault();
        }
    }
}
