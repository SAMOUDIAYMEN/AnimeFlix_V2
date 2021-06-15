using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anime.Data;
using AnimeFlix.Models;
using Microsoft.AspNetCore.Authorization;

namespace AnimeFlix.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryAnimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryAnimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoryAnimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryAnime.ToListAsync());
        }

        // GET: CategoryAnimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryAnimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,CategoryName")] CategoryAnime categoryAnime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryAnime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryAnime);
        }

        // GET: CategoryAnimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryAnime = await _context.CategoryAnime.FindAsync(id);
            if (categoryAnime == null)
            {
                return NotFound();
            }
            return View(categoryAnime);
        }

        // POST: CategoryAnimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,CategoryName")] CategoryAnime categoryAnime)
        {
            if (id != categoryAnime.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryAnime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryAnimeExists(categoryAnime.id))
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
            return View(categoryAnime);
        }

        // GET: CategoryAnimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryAnime = await _context.CategoryAnime
                .FirstOrDefaultAsync(m => m.id == id);
            if (categoryAnime == null)
            {
                return NotFound();
            }

            return View(categoryAnime);
        }

        // POST: CategoryAnimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryAnime = await _context.CategoryAnime.FindAsync(id);
            _context.CategoryAnime.Remove(categoryAnime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryAnimeExists(int id)
        {
            return _context.CategoryAnime.Any(e => e.id == id);
        }
    }
}
