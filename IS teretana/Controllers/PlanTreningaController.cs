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
    public class PlanTreningaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlanTreningaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PlanTreninga
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PlanTreninga.Include(p => p.Clan).Include(p => p.Teretana).Include(p => p.Trener);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PlanTreninga/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planTreninga = await _context.PlanTreninga
                .Include(p => p.Clan)
                .Include(p => p.Teretana)
                .Include(p => p.Trener)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (planTreninga == null)
            {
                return NotFound();
            }

            return View(planTreninga);
        }

        // GET: PlanTreninga/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email");
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa");
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email");
            return View();
        }

        // POST: PlanTreninga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Opis,ClanID,TrenerID,TeretanaID")] PlanTreninga planTreninga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planTreninga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email", planTreninga.ClanID);
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa", planTreninga.TeretanaID);
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email", planTreninga.TrenerID);
            return View(planTreninga);
        }

        // GET: PlanTreninga/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planTreninga = await _context.PlanTreninga.FindAsync(id);
            if (planTreninga == null)
            {
                return NotFound();
            }
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email", planTreninga.ClanID);
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa", planTreninga.TeretanaID);
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email", planTreninga.TrenerID);
            return View(planTreninga);
        }

        // POST: PlanTreninga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Opis,ClanID,TrenerID,TeretanaID")] PlanTreninga planTreninga)
        {
            if (id != planTreninga.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planTreninga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanTreningaExists(planTreninga.ID))
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
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email", planTreninga.ClanID);
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa", planTreninga.TeretanaID);
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email", planTreninga.TrenerID);
            return View(planTreninga);
        }

        // GET: PlanTreninga/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planTreninga = await _context.PlanTreninga
                .Include(p => p.Clan)
                .Include(p => p.Teretana)
                .Include(p => p.Trener)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (planTreninga == null)
            {
                return NotFound();
            }

            return View(planTreninga);
        }

        // POST: PlanTreninga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planTreninga = await _context.PlanTreninga.FindAsync(id);
            if (planTreninga != null)
            {
                _context.PlanTreninga.Remove(planTreninga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanTreningaExists(int id)
        {
            return _context.PlanTreninga.Any(e => e.ID == id);
        }
    }
}
