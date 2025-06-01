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
    public class PovratnaInformacijaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PovratnaInformacijaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PovratnaInformacija
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.PovratnaInformacija.ToListAsync());
        }

        // GET: PovratnaInformacija/Details/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povratnaInformacija = await _context.PovratnaInformacija
                .FirstOrDefaultAsync(m => m.ID == id);
            if (povratnaInformacija == null)
            {
                return NotFound();
            }

            return View(povratnaInformacija);
        }

        // GET: PovratnaInformacija/Create
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: PovratnaInformacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Create([Bind("ID,Ocjena,Komentar,DatumVrijeme,PlanTreningaID")] PovratnaInformacija povratnaInformacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(povratnaInformacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(povratnaInformacija);
        }

        // GET: PovratnaInformacija/Edit/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povratnaInformacija = await _context.PovratnaInformacija.FindAsync(id);
            if (povratnaInformacija == null)
            {
                return NotFound();
            }
            return View(povratnaInformacija);
        }

        // POST: PovratnaInformacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ocjena,Komentar,DatumVrijeme,PlanTreningaID")] PovratnaInformacija povratnaInformacija)
        {
            if (id != povratnaInformacija.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(povratnaInformacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PovratnaInformacijaExists(povratnaInformacija.ID))
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
            return View(povratnaInformacija);
        }

        // GET: PovratnaInformacija/Delete/5
        [HttpGet]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var povratnaInformacija = await _context.PovratnaInformacija
                .FirstOrDefaultAsync(m => m.ID == id);
            if (povratnaInformacija == null)
            {
                return NotFound();
            }

            return View(povratnaInformacija);
        }

        // POST: PovratnaInformacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("[Controller]/[Action]")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var povratnaInformacija = await _context.PovratnaInformacija.FindAsync(id);
            if (povratnaInformacija != null)
            {
                _context.PovratnaInformacija.Remove(povratnaInformacija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PovratnaInformacijaExists(int id)
        {
            return _context.PovratnaInformacija.Any(e => e.ID == id);
        }
    }
}
