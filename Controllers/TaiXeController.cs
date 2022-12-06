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
    public class TaiXeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaiXeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaiXe
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TaiXe.Include(t => t.GioiTinh);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TaiXe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.TaiXe == null)
            {
                return NotFound();
            }

            var taiXe = await _context.TaiXe
                .Include(t => t.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaTaiXe == id);
            if (taiXe == null)
            {
                return NotFound();
            }

            return View(taiXe);
        }

        // GET: TaiXe/Create
        public IActionResult Create()
        {
            ViewData["TenGioiTinh"] = new SelectList(_context.Set<GioiTinh>(), "ID", "TenGioiTinh");
            return View();
        }

        // POST: TaiXe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaTaiXe,TenTaiXe,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] TaiXe taiXe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taiXe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.Set<GioiTinh>(), "ID", "TenGioiTinh", taiXe.TenGioiTinh);
            return View(taiXe);
        }

        // GET: TaiXe/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.TaiXe == null)
            {
                return NotFound();
            }

            var taiXe = await _context.TaiXe.FindAsync(id);
            if (taiXe == null)
            {
                return NotFound();
            }
            ViewData["TenGioiTinh"] = new SelectList(_context.Set<GioiTinh>(), "ID", "TenGioiTinh", taiXe.TenGioiTinh);
            return View(taiXe);
        }

        // POST: TaiXe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaTaiXe,TenTaiXe,Ngaysinh,TenGioiTinh,Diachi,CMND,SoDienThoai")] TaiXe taiXe)
        {
            if (id != taiXe.MaTaiXe)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taiXe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaiXeExists(taiXe.MaTaiXe))
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
            ViewData["TenGioiTinh"] = new SelectList(_context.Set<GioiTinh>(), "ID", "TenGioiTinh", taiXe.TenGioiTinh);
            return View(taiXe);
        }

        // GET: TaiXe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.TaiXe == null)
            {
                return NotFound();
            }

            var taiXe = await _context.TaiXe
                .Include(t => t.GioiTinh)
                .FirstOrDefaultAsync(m => m.MaTaiXe == id);
            if (taiXe == null)
            {
                return NotFound();
            }

            return View(taiXe);
        }

        // POST: TaiXe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.TaiXe == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TaiXe'  is null.");
            }
            var taiXe = await _context.TaiXe.FindAsync(id);
            if (taiXe != null)
            {
                _context.TaiXe.Remove(taiXe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaiXeExists(string id)
        {
          return (_context.TaiXe?.Any(e => e.MaTaiXe == id)).GetValueOrDefault();
        }
    }
}
