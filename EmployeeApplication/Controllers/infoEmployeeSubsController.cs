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
    public class infoEmployeeSubsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public infoEmployeeSubsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: infoEmployeeSubs
        public async Task<IActionResult> Index()
        {
            return View(await _context.infoEmployeeSubs.ToListAsync());
        }

        // GET: infoEmployeeSubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoEmployeeSub = await _context.infoEmployeeSubs
                .FirstOrDefaultAsync(m => m.aseriesId == id);
            if (infoEmployeeSub == null)
            {
                return NotFound();
            }

            return View(infoEmployeeSub);
        }

        // GET: infoEmployeeSubs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: infoEmployeeSubs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("aseriesId,EmployeeCode,holidaydate,Thenumberofdays,Isitvacation,Statement")] infoEmployeeSub infoEmployeeSub)
        {
            if (ModelState.IsValid)
            {
                _context.Add(infoEmployeeSub);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(infoEmployeeSub);
        }

        // GET: infoEmployeeSubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoEmployeeSub = await _context.infoEmployeeSubs.FindAsync(id);
            if (infoEmployeeSub == null)
            {
                return NotFound();
            }
            return View(infoEmployeeSub);
        }

        // POST: infoEmployeeSubs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("aseriesId,EmployeeCode,holidaydate,Thenumberofdays,Isitvacation,Statement")] infoEmployeeSub infoEmployeeSub)
        {
            if (id != infoEmployeeSub.aseriesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(infoEmployeeSub);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!infoEmployeeSubExists(infoEmployeeSub.aseriesId))
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
            return View(infoEmployeeSub);
        }

        // GET: infoEmployeeSubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var infoEmployeeSub = await _context.infoEmployeeSubs
                .FirstOrDefaultAsync(m => m.aseriesId == id);
            if (infoEmployeeSub == null)
            {
                return NotFound();
            }

            return View(infoEmployeeSub);
        }

        // POST: infoEmployeeSubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var infoEmployeeSub = await _context.infoEmployeeSubs.FindAsync(id);
            _context.infoEmployeeSubs.Remove(infoEmployeeSub);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool infoEmployeeSubExists(int id)
        {
            return _context.infoEmployeeSubs.Any(e => e.aseriesId == id);
        }
    }
}
