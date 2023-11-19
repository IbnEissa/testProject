using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemASPProject.Data;
using SchoolManagementSystemASPProject.Models;

namespace SchoolManagementSystemASPProject.Controllers
{
    public class StudentTbsController : Controller
    {
        private readonly SchoolManagementSystemASPProjectContext _context;

        public StudentTbsController(SchoolManagementSystemASPProjectContext context)
        {
            _context = context;
        }

        // GET: StudentTbs
        public async Task<IActionResult> Index()
        {
              return _context.StudentTb != null ? 
                          View(await _context.StudentTb.ToListAsync()) :
                          Problem("Entity set 'SchoolManagementSystemASPProjectContext.StudentTb'  is null.");
        }

        // GET: StudentTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentTb == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTb == null)
            {
                return NotFound();
            }

            return View(studentTb);
        }

        // GET: StudentTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,ClassName")] StudentTb studentTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentTb);
        }

        // GET: StudentTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentTb == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTb.FindAsync(id);
            if (studentTb == null)
            {
                return NotFound();
            }
            return View(studentTb);
        }

        // POST: StudentTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,ClassName")] StudentTb studentTb)
        {
            if (id != studentTb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentTbExists(studentTb.Id))
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
            return View(studentTb);
        }

        // GET: StudentTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentTb == null)
            {
                return NotFound();
            }

            var studentTb = await _context.StudentTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentTb == null)
            {
                return NotFound();
            }

            return View(studentTb);
        }

        // POST: StudentTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentTb == null)
            {
                return Problem("Entity set 'SchoolManagementSystemASPProjectContext.StudentTb'  is null.");
            }
            var studentTb = await _context.StudentTb.FindAsync(id);
            if (studentTb != null)
            {
                _context.StudentTb.Remove(studentTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentTbExists(int id)
        {
          return (_context.StudentTb?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
