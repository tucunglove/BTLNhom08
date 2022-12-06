using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_nhom08.Models;

namespace BTL_nhom08.Controllers
{
    public class ChuyenXeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChuyenXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChuyenXe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChuyenXe.Include(c => c.BangGia).Include(c => c.TaiXe);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChuyenXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ChuyenXe == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXe
                .Include(c => c.BangGia)
                .Include(c => c.TaiXe)
                .FirstOrDefaultAsync(m => m.MaChuyenXe == id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            return View(chuyenXe);
        }

        // GET: ChuyenXe/Create
        public IActionResult Create()
        {
            ViewData["GiaID"] = new SelectList(_context.Set<BangGia>(), "GiaID", "GiaVe");
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe");
            return View();
        }

        // POST: ChuyenXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaChuyenXe,TenChuyenXe,NgayDi,DiemDi,DiemDen,MaTaiXe,GiaID")] ChuyenXe chuyenXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chuyenXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiaID"] = new SelectList(_context.Set<BangGia>(), "GiaID", "GiaVe", chuyenXe.GiaID);
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe", chuyenXe.MaTaiXe);
            return View(chuyenXe);
        }

        // GET: ChuyenXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ChuyenXe == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXe.FindAsync(id);
            if (chuyenXe == null)
            {
                return NotFound();
            }
            ViewData["GiaID"] = new SelectList(_context.Set<BangGia>(), "GiaID", "GiaVe", chuyenXe.GiaID);
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe", chuyenXe.MaTaiXe);
            return View(chuyenXe);
        }

        // POST: ChuyenXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaChuyenXe,TenChuyenXe,NgayDi,DiemDi,DiemDen,MaTaiXe,GiaID")] ChuyenXe chuyenXe)
        {
            if (id != chuyenXe.MaChuyenXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chuyenXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChuyenXeExists(chuyenXe.MaChuyenXe))
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
            ViewData["GiaID"] = new SelectList(_context.Set<BangGia>(), "GiaID", "GiaVe", chuyenXe.GiaID);
            ViewData["MaTaiXe"] = new SelectList(_context.TaiXe, "MaTaiXe", "MaTaiXe", chuyenXe.MaTaiXe);
            return View(chuyenXe);
        }

        // GET: ChuyenXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ChuyenXe == null)
            {
                return NotFound();
            }

            var chuyenXe = await _context.ChuyenXe
                .Include(c => c.BangGia)
                .Include(c => c.TaiXe)
                .FirstOrDefaultAsync(m => m.MaChuyenXe == id);
            if (chuyenXe == null)
            {
                return NotFound();
            }

            return View(chuyenXe);
        }

        // POST: ChuyenXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ChuyenXe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChuyenXe'  is null.");
            }
            var chuyenXe = await _context.ChuyenXe.FindAsync(id);
            if (chuyenXe != null)
            {
                _context.ChuyenXe.Remove(chuyenXe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChuyenXeExists(string id)
        {
          return (_context.ChuyenXe?.Any(e => e.MaChuyenXe == id)).GetValueOrDefault();
        }
    }
}
