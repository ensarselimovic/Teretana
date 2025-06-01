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
    public class TeretanaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeretanaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teretana
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Teretana.ToListAsync());
        }

        // GET: Teretana/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teretana = await _context.Teretana
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teretana == null)
            {
                return NotFound();
            }

            return View(teretana);
        }

        // GET: Teretana/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teretana/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,Naziv,Adresa,Kontakt,RadnoVrijeme")] Teretana teretana)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teretana);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teretana);
        }

        // GET: Teretana/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teretana = await _context.Teretana.FindAsync(id);
            if (teretana == null)
            {
                return NotFound();
            }
            return View(teretana);
        }

        // POST: Teretana/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Naziv,Adresa,Kontakt,RadnoVrijeme")] Teretana teretana)
        {
            if (id != teretana.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teretana);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeretanaExists(teretana.ID))
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
            return View(teretana);
        }

        // GET: Teretana/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var teretana = await _context.Teretana
                .FirstOrDefaultAsync(m => m.ID == id);
            if (teretana == null)
            {
                return NotFound();
            }

            return View(teretana);
        }

        // POST: Teretana/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var teretana = await _context.Teretana.FindAsync(id);
            if (teretana != null)
            {
                _context.Teretana.Remove(teretana);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeretanaExists(int id)
        {
            return _context.Teretana.Any(e => e.ID == id);
        }
    }
}
