using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeApplication.Data;
using EmployeeApplication.Models;

namespace EmployeeApplication.Controllers
{
    public class InfoEmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InfoEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: InfoEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.infoEmployees.ToListAsync());
        }

        // GET: InfoEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoEmployee = await _context.infoEmployees
                .FirstOrDefaultAsync(m => m.EmployeeCodeId == id);
            if (infoEmployee == null)
            {
                return NotFound();
            }

            return View(infoEmployee);
        }

        // GET: InfoEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: InfoEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeCodeId,EmployeeName,DateofBirth,PhoneNumpur,Address,Salary")] InfoEmployee infoEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoEmployee);
        }

        // GET: InfoEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoEmployee = await _context.infoEmployees.FindAsync(id);
            if (infoEmployee == null)
            {
                return NotFound();
            }
            return View(infoEmployee);
        }

        // POST: InfoEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeCodeId,EmployeeName,DateofBirth,PhoneNumpur,Address,Salary")] InfoEmployee infoEmployee)
        {
            if (id != infoEmployee.EmployeeCodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InfoEmployeeExists(infoEmployee.EmployeeCodeId))
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
            return View(infoEmployee);
        }

        // GET: InfoEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoEmployee = await _context.infoEmployees
                .FirstOrDefaultAsync(m => m.EmployeeCodeId == id);
            if (infoEmployee == null)
            {
                return NotFound();
            }

            return View(infoEmployee);
        }

        // POST: InfoEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoEmployee = await _context.infoEmployees.FindAsync(id);
            _context.infoEmployees.Remove(infoEmployee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InfoEmployeeExists(int id)
        {
            return _context.infoEmployees.Any(e => e.EmployeeCodeId == id);
        }
    }
}
