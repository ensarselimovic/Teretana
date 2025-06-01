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
    public class TerminTreningaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TerminTreningaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TerminTreninga
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TerminTreninga.Include(t => t.Clan).Include(t => t.Teretana).Include(t => t.Trener);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TerminTreninga/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminTreninga = await _context.TerminTreninga
                .Include(t => t.Clan)
                .Include(t => t.Teretana)
                .Include(t => t.Trener)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (terminTreninga == null)
            {
                return NotFound();
            }

            return View(terminTreninga);
        }

        // GET: TerminTreninga/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email");
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa");
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email");
            return View();
        }

        // POST: TerminTreninga/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,Datum,Vrijeme,TeretanaID,TrenerID,ClanID")] TerminTreninga terminTreninga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(terminTreninga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email", terminTreninga.ClanID);
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa", terminTreninga.TeretanaID);
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email", terminTreninga.TrenerID);
            return View(terminTreninga);
        }

        // GET: TerminTreninga/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminTreninga = await _context.TerminTreninga.FindAsync(id);
            if (terminTreninga == null)
            {
                return NotFound();
            }
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email", terminTreninga.ClanID);
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa", terminTreninga.TeretanaID);
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email", terminTreninga.TrenerID);
            return View(terminTreninga);
        }

        // POST: TerminTreninga/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]

        public async Task<IActionResult> Edit(int id, [Bind("ID,Datum,Vrijeme,TeretanaID,TrenerID,ClanID")] TerminTreninga terminTreninga)
        {
            if (id != terminTreninga.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(terminTreninga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerminTreningaExists(terminTreninga.ID))
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
            ViewData["ClanID"] = new SelectList(_context.Clan, "ID", "Email", terminTreninga.ClanID);
            ViewData["TeretanaID"] = new SelectList(_context.Teretana, "ID", "Adresa", terminTreninga.TeretanaID);
            ViewData["TrenerID"] = new SelectList(_context.Trener, "ID", "Email", terminTreninga.TrenerID);
            return View(terminTreninga);
        }

        // GET: TerminTreninga/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var terminTreninga = await _context.TerminTreninga
                .Include(t => t.Clan)
                .Include(t => t.Teretana)
                .Include(t => t.Trener)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (terminTreninga == null)
            {
                return NotFound();
            }

            return View(terminTreninga);
        }

        // POST: TerminTreninga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var terminTreninga = await _context.TerminTreninga.FindAsync(id);
            if (terminTreninga != null)
            {
                _context.TerminTreninga.Remove(terminTreninga);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerminTreningaExists(int id)
        {
            return _context.TerminTreninga.Any(e => e.ID == id);
        }
    }
}
