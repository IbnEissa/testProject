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
    public class TeacherTbsController : Controller
    {
        private readonly SchoolManagementSystemASPProjectContext _context;

        public TeacherTbsController(SchoolManagementSystemASPProjectContext context)
        {
            _context = context;
        }

        // GET: TeacherTbs
        public async Task<IActionResult> Index()
        {
              return _context.TeacherTb != null ? 
                          View(await _context.TeacherTb.ToListAsync()) :
                          Problem("Entity set 'SchoolManagementSystemASPProjectContext.TeacherTb'  is null.");
        }

        // GET: TeacherTbs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeacherTb == null)
            {
                return NotFound();
            }

            var teacherTb = await _context.TeacherTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherTb == null)
            {
                return NotFound();
            }

            return View(teacherTb);
        }

        // GET: TeacherTbs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TeacherTbs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Phone,Shift_type,major,task,exceperiance_years,qualification,date_qualification,state,fingerPrintData")] TeacherTb teacherTb)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacherTb);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(teacherTb);
        }

        // GET: TeacherTbs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeacherTb == null)
            {
                return NotFound();
            }

            var teacherTb = await _context.TeacherTb.FindAsync(id);
            if (teacherTb == null)
            {
                return NotFound();
            }
            return View(teacherTb);
        }

        // POST: TeacherTbs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Phone,Shift_type,major,task,exceperiance_years,qualification,date_qualification,state,fingerPrintData")] TeacherTb teacherTb)
        {
            if (id != teacherTb.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teacherTb);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeacherTbExists(teacherTb.Id))
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
            return View(teacherTb);
        }

        // GET: TeacherTbs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeacherTb == null)
            {
                return NotFound();
            }

            var teacherTb = await _context.TeacherTb
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teacherTb == null)
            {
                return NotFound();
            }

            return View(teacherTb);
        }

        // POST: TeacherTbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeacherTb == null)
            {
                return Problem("Entity set 'SchoolManagementSystemASPProjectContext.TeacherTb'  is null.");
            }
            var teacherTb = await _context.TeacherTb.FindAsync(id);
            if (teacherTb != null)
            {
                _context.TeacherTb.Remove(teacherTb);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeacherTbExists(int id)
        {
          return (_context.TeacherTb?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
