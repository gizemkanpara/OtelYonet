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
    public class MusteriTipController : Controller
    {
        private readonly OtelYonetDBContext _context;

        public MusteriTipController(OtelYonetDBContext context)
        {
            _context = context;
        }

        // GET: MusteriTip
        public async Task<IActionResult> Index()
        {
            return View(await _context.MusteriTipleri.ToListAsync());
        }

        // GET: MusteriTip/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriTip = await _context.MusteriTipleri
                .FirstOrDefaultAsync(m => m.MusteriTipID == id);
            if (musteriTip == null)
            {
                return NotFound();
            }

            return View(musteriTip);
        }

        // GET: MusteriTip/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MusteriTip/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MusteriTipID,MusteriTipleri")] MusteriTip musteriTip)
        {
            if (ModelState.IsValid)
            {
                _context.Add(musteriTip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(musteriTip);
        }

        // GET: MusteriTip/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriTip = await _context.MusteriTipleri.FindAsync(id);
            if (musteriTip == null)
            {
                return NotFound();
            }
            return View(musteriTip);
        }

        // POST: MusteriTip/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MusteriTipID,MusteriTipleri")] MusteriTip musteriTip)
        {
            if (id != musteriTip.MusteriTipID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(musteriTip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MusteriTipExists(musteriTip.MusteriTipID))
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
            return View(musteriTip);
        }

        // GET: MusteriTip/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var musteriTip = await _context.MusteriTipleri
                .FirstOrDefaultAsync(m => m.MusteriTipID == id);
            if (musteriTip == null)
            {
                return NotFound();
            }

            return View(musteriTip);
        }

        // POST: MusteriTip/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var musteriTip = await _context.MusteriTipleri.FindAsync(id);
            _context.MusteriTipleri.Remove(musteriTip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MusteriTipExists(int id)
        {
            return _context.MusteriTipleri.Any(e => e.MusteriTipID == id);
        }
    }
}
