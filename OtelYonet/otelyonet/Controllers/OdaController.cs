using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using otelyonet.Data;
using otelyonet.Models;

namespace otelyonet.Controllers
{
    public class OdaController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public OdaController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Odas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Odalar.ToListAsync());
        }

        // GET: Odas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oda = await _context.Odalar
                .FirstOrDefaultAsync(m => m.OdaID == id);
            if (oda == null)
            {
                return NotFound();
            }

            return View(oda);
        }

        // GET: Odas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Odas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdaID,OdaAdı,KatNO,YatakSayısı")] Oda oda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oda);
        }

        // GET: Odas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oda = await _context.Odalar.FindAsync(id);
            if (oda == null)
            {
                return NotFound();
            }
            return View(oda);
        }

        // POST: Odas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OdaID,OdaAdı,KatNO,YatakSayısı")] Oda oda)
        {
            if (id != oda.OdaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdaExists(oda.OdaID))
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
            return View(oda);
        }

        // GET: Odas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oda = await _context.Odalar
                .FirstOrDefaultAsync(m => m.OdaID == id);
            if (oda == null)
            {
                return NotFound();
            }

            return View(oda);
        }

        // POST: Odas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oda = await _context.Odalar.FindAsync(id);
            _context.Odalar.Remove(oda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdaExists(int id)
        {
            return _context.Odalar.Any(e => e.OdaID == id);
        }
    }
}
