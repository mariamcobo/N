using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NAILSART.Data;
using NAILSART.Models;
using Microsoft.AspNetCore.Authorization;

namespace NAILSART.Views.NAILSART_SALONS
{
    public class NAILSART_SALONSController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NAILSART_SALONSController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NAILSART_SALONS
        public async Task<IActionResult> Index()
        {
            return View(await _context.NAILSART_SALON.ToListAsync());
        }

        // GET: NAILSART_SALONS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nAILSART_SALON = await _context.NAILSART_SALON.FirstOrDefaultAsync(m => m.Id == id);
            if (nAILSART_SALON == null)
            {
                return NotFound();
            }

            return View(nAILSART_SALON);
        }

        // GET: NAILSART_SALONS/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: NAILSART_SALONS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] NAILSART_SALON nAILSART_SALON)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nAILSART_SALON);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nAILSART_SALON);
        }

        // GET: NAILSART_SALONS/Edit/5
        [Authorize]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nAILSART_SALON = await _context.NAILSART_SALON.FindAsync(id);
            if (nAILSART_SALON == null)
            {
                return NotFound();
            }
            return View(nAILSART_SALON);
        }

        // POST: NAILSART_SALONS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Categoria,Descripcion,Precio,URL_IMAGEN")] NAILSART_SALON nAILSART_SALON)
        {
            if (id != nAILSART_SALON.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nAILSART_SALON);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NAILSART_SALONExists(nAILSART_SALON.Id))
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
            return View(nAILSART_SALON);
        }

        // GET: NAILSART_SALONS/Delete/5
        [Authorize]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nAILSART_SALON = await _context.NAILSART_SALON
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nAILSART_SALON == null)
            {
                return NotFound();
            }

            return View(nAILSART_SALON);
        }

        // POST: NAILSART_SALONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nAILSART_SALON = await _context.NAILSART_SALON.FindAsync(id);
            _context.NAILSART_SALON.Remove(nAILSART_SALON);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NAILSART_SALONExists(int id)
        {
            return _context.NAILSART_SALON.Any(e => e.Id == id);
        }
    }
}
