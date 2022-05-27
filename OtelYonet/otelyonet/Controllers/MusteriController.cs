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
    public class MusteriController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public MusteriController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: Musteri
        public async Task<IActionResult> Index()
        {
            var otelYonetDBContext = _context.Musteriler.Include(m => m.Cinsiyet).Include(m => m.MusteriTip);
            return View(await otelYonetDBContext.ToListAsync());
        }

        // GET: Musteri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteriler
                .Include(m => m.Cinsiyet)
                .Include(m => m.MusteriTip)
                .FirstOrDefaultAsync(m => m.MusteriID == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        // GET: Musteri/Create
        public IActionResult Create()
        {
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetTuru");
            ViewData["MusteriTipID"] = new SelectList(_context.MusteriTipleri, "MusteriTipID", "MusteriTipleri");
            return View();
        }

        // POST: Musteri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriID,MusteriTC,MusteriAdi,MusteriSoyadi,MusteriTel,MusteriAdresi,CinsiyetID,MusteriTipID")] Musteri musteri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetTuru", musteri.CinsiyetID);
            ViewData["MusteriTipID"] = new SelectList(_context.MusteriTipleri, "MusteriTipID", "MusteriTipleri", musteri.MusteriTipID);
            return View(musteri);
        }

        // GET: Musteri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteriler.FindAsync(id);
            if (musteri == null)
            {
                return NotFound();
            }
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetTuru", musteri.CinsiyetID);
            ViewData["MusteriTipID"] = new SelectList(_context.MusteriTipleri, "MusteriTipID", "MusteriTipleri", musteri.MusteriTipID);
            return View(musteri);
        }

        // POST: Musteri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriID,MusteriTC,MusteriAdi,MusteriSoyadi,MusteriTel,MusteriAdresi,CinsiyetID,MusteriTipID")] Musteri musteri)
        {
            if (id != musteri.MusteriID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusteriExists(musteri.MusteriID))
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
            ViewData["CinsiyetID"] = new SelectList(_context.Cinsiyetler, "CinsiyetID", "CinsiyetTuru", musteri.CinsiyetID);
            ViewData["MusteriTipID"] = new SelectList(_context.MusteriTipleri, "MusteriTipID", "MusteriTipleri", musteri.MusteriTipID);
            return View(musteri);
        }

        // GET: Musteri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteri = await _context.Musteriler
                .Include(m => m.Cinsiyet)
                .Include(m => m.MusteriTip)
                .FirstOrDefaultAsync(m => m.MusteriID == id);
            if (musteri == null)
            {
                return NotFound();
            }

            return View(musteri);
        }

        // POST: Musteri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteri = await _context.Musteriler.FindAsync(id);
            _context.Musteriler.Remove(musteri);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusteriExists(int id)
        {
            return _context.Musteriler.Any(e => e.MusteriID == id);
        }
    }
}
