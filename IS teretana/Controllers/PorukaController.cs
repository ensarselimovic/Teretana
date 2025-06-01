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
    public class PorukaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PorukaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Poruka
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Poruka.Include(p => p.Posiljalac).Include(p => p.Primalac);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Poruka/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poruka = await _context.Poruka
                .Include(p => p.Posiljalac)
                .Include(p => p.Primalac)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poruka == null)
            {
                return NotFound();
            }

            return View(poruka);
        }

        // GET: Poruka/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            ViewData["PosiljalacID"] = new SelectList(_context.Trener, "ID", "Email");
            ViewData["PrimalacID"] = new SelectList(_context.Clan, "ID", "Email");
            return View();
        }

        // POST: Poruka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,Sadrzaj,DatumSlanja,PosiljalacID,PrimalacID")] Poruka poruka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poruka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PosiljalacID"] = new SelectList(_context.Trener, "ID", "Email", poruka.PosiljalacID);
            ViewData["PrimalacID"] = new SelectList(_context.Clan, "ID", "Email", poruka.PrimalacID);
            return View(poruka);
        }

        // GET: Poruka/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poruka = await _context.Poruka.FindAsync(id);
            if (poruka == null)
            {
                return NotFound();
            }
            ViewData["PosiljalacID"] = new SelectList(_context.Trener, "ID", "Email", poruka.PosiljalacID);
            ViewData["PrimalacID"] = new SelectList(_context.Clan, "ID", "Email", poruka.PrimalacID);
            return View(poruka);
        }

        // POST: Poruka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]

        public async Task<IActionResult> Edit(int id, [Bind("ID,Sadrzaj,DatumSlanja,PosiljalacID,PrimalacID")] Poruka poruka)
        {
            if (id != poruka.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poruka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PorukaExists(poruka.ID))
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
            ViewData["PosiljalacID"] = new SelectList(_context.Trener, "ID", "Email", poruka.PosiljalacID);
            ViewData["PrimalacID"] = new SelectList(_context.Clan, "ID", "Email", poruka.PrimalacID);
            return View(poruka);
        }

        // GET: Poruka/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poruka = await _context.Poruka
                .Include(p => p.Posiljalac)
                .Include(p => p.Primalac)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (poruka == null)
            {
                return NotFound();
            }

            return View(poruka);
        }

        // POST: Poruka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poruka = await _context.Poruka.FindAsync(id);
            if (poruka != null)
            {
                _context.Poruka.Remove(poruka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PorukaExists(int id)
        {
            return _context.Poruka.Any(e => e.ID == id);
        }
    }
}
