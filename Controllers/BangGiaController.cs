using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTL_nhom08.Models;
using BTL_nhom08.Models.Process;

namespace BTL_nhom08.Controllers
{
    public class BangGiaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ExcelProcess _excelProcess = new ExcelProcess();

        public BangGiaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BangGia
        public async Task<IActionResult> Index()
        {
              return _context.BangGia != null ? 
                          View(await _context.BangGia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.BangGia'  is null.");
        }

        // GET: BangGia/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.BangGia == null)
            {
                return NotFound();
            }

            var bangGia = await _context.BangGia
                .FirstOrDefaultAsync(m => m.GiaID == id);
            if (bangGia == null)
            {
                return NotFound();
            }

            return View(bangGia);
        }

        // GET: BangGia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BangGia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GiaID,GiaVe")] BangGia bangGia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bangGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bangGia);
        }

        // GET: BangGia/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.BangGia == null)
            {
                return NotFound();
            }

            var bangGia = await _context.BangGia.FindAsync(id);
            if (bangGia == null)
            {
                return NotFound();
            }
            return View(bangGia);
        }

        // POST: BangGia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("GiaID,GiaVe")] BangGia bangGia)
        {
            if (id != bangGia.GiaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bangGia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BangGiaExists(bangGia.GiaID))
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
            return View(bangGia);
        }

        // GET: BangGia/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.BangGia == null)
            {
                return NotFound();
            }

            var bangGia = await _context.BangGia
                .FirstOrDefaultAsync(m => m.GiaID == id);
            if (bangGia == null)
            {
                return NotFound();
            }

            return View(bangGia);
        }

        // POST: BangGia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.BangGia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BangGia'  is null.");
            }
            var bangGia = await _context.BangGia.FindAsync(id);
            if (bangGia != null)
            {
                _context.BangGia.Remove(bangGia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BangGiaExists(string id)
        {
          return (_context.BangGia?.Any(e => e.GiaID == id)).GetValueOrDefault();
        }
public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload");
                }
                else
                {
                    //rename file when upload to sever
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        //read data from file and write to database
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        //using for loop to read data from dt
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            
                            var tl = new BangGia();
                            //set values for attributes
                            tl.GiaID = dt.Rows[i][0].ToString();
                            tl.GiaVe = dt.Rows[i][1].ToString();
                            //add object to context
                            _context.BangGia.Add(tl);
                        }
                        //save to database
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
