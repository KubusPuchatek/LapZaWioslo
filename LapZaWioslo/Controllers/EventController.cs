using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LapZaWioslo.Data;
using LapZaWioslo.Models;

namespace LapZaWioslo.Controllers
{
    public class EventController : Controller
    {
        private readonly DBContext _context;

        public EventController(DBContext context)
        {
            _context = context;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            return View(await _context.EventInformation.ToListAsync());
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInformation = await _context.EventInformation
                .Include(eventData=>eventData.Participants)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (eventInformation == null)
            {
                return NotFound();
            }

            return View(eventInformation);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AdditionalQuestion,StartDate,EndDate")] EventInformation eventInformation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventInformation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventInformation);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInformation = await _context.EventInformation.FindAsync(id);
            if (eventInformation == null)
            {
                return NotFound();
            }
            return View(eventInformation);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AdditionalQuestion,StartDate,EndDate")] EventInformation eventInformation)
        {
            if (id != eventInformation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventInformationExists(eventInformation.Id))
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
            return View(eventInformation);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventInformation = await _context.EventInformation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (eventInformation == null)
            {
                return NotFound();
            }

            return View(eventInformation);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventInformation = await _context.EventInformation.FindAsync(id);
            _context.EventInformation.Remove(eventInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventInformationExists(int id)
        {
            return _context.EventInformation.Any(e => e.Id == id);
        }
    }
}
