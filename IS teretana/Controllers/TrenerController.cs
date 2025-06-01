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
    public class TrenerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TrenerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Trener
        [HttpGet]
        [Route("[Controller]/[Action]")]

        public async Task<IActionResult> Index()
        {
            return View(await _context.Trener.ToListAsync());
        }

        // GET: Trener/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Trener
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // GET: Trener/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trener/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,Ime,Prezime,Email,Specijalizacija")] Trener trener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trener);
        }

        // GET: Trener/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Trener.FindAsync(id);
            if (trener == null)
            {
                return NotFound();
            }
            return View(trener);
        }

        // POST: Trener/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Prezime,Email,Specijalizacija")] Trener trener)
        {
            if (id != trener.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrenerExists(trener.ID))
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
            return View(trener);
        }

        // GET: Trener/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trener = await _context.Trener
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trener == null)
            {
                return NotFound();
            }

            return View(trener);
        }

        // POST: Trener/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trener = await _context.Trener.FindAsync(id);
            if (trener != null)
            {
                _context.Trener.Remove(trener);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrenerExists(int id)
        {
            return _context.Trener.Any(e => e.ID == id);
        }
    }
}
