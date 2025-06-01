using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISTeretana.Models;
using IS_teretana.Data;

namespace IS_teretana.Controllers
{
    public class NapredakController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NapredakController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Napredak
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Napredak.Include(n => n.PlanTreninga);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Napredak/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var napredak = await _context.Napredak
                .Include(n => n.PlanTreninga)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (napredak == null)
            {
                return NotFound();
            }

            return View(napredak);
        }

        // GET: Napredak/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            ViewData["PlanTreningaID"] = new SelectList(_context.PlanTreninga, "ID", "Naziv");
            return View();
        }

        // POST: Napredak/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,PlanTreningaID,Datum,Opis")] Napredak napredak)
        {
            if (ModelState.IsValid)
            {
                _context.Add(napredak);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PlanTreningaID"] = new SelectList(_context.PlanTreninga, "ID", "Naziv", napredak.PlanTreningaID);
            return View(napredak);
        }

        // GET: Napredak/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var napredak = await _context.Napredak.FindAsync(id);
            if (napredak == null)
            {
                return NotFound();
            }
            ViewData["PlanTreningaID"] = new SelectList(_context.PlanTreninga, "ID", "Naziv", napredak.PlanTreningaID);
            return View(napredak);
        }

        // POST: Napredak/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,PlanTreningaID,Datum,Opis")] Napredak napredak)
        {
            if (id != napredak.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(napredak);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NapredakExists(napredak.ID))
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
            ViewData["PlanTreningaID"] = new SelectList(_context.PlanTreninga, "ID", "Naziv", napredak.PlanTreningaID);
            return View(napredak);
        }

        // GET: Napredak/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var napredak = await _context.Napredak
                .Include(n => n.PlanTreninga)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (napredak == null)
            {
                return NotFound();
            }

            return View(napredak);
        }

        // POST: Napredak/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var napredak = await _context.Napredak.FindAsync(id);
            if (napredak != null)
            {
                _context.Napredak.Remove(napredak);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NapredakExists(int id)
        {
            return _context.Napredak.Any(e => e.ID == id);
        }
    }
}
