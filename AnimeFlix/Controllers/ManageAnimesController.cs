using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Anime.Data;
using AnimeFlix.Models;
using AnimeFlix.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace AnimeFlix.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManageAnimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageAnimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ManageAnimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anime.ToListAsync());
        }

        // GET: ManageAnimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageAnime = await _context.Anime
                .FirstOrDefaultAsync(m => m.id == id);
            if (manageAnime == null)
            {
                return NotFound();
            }

            return View(manageAnime);
        }

        // GET: ManageAnimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageAnimes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titleAnime,src,studion,author,descriptionAnime,ratingAnime,imgAnime,trailerAnime,runtime,categoryid")] ManageAnime manageAnime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manageAnime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manageAnime);
        }

        // GET: ManageAnimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageAnime = await _context.Anime.FindAsync(id);
            if (manageAnime == null)
            {
                return NotFound();
            }
            return View(manageAnime);
        }

        // POST: ManageAnimes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titleAnime,src,studion,author,descriptionAnime,ratingAnime,imgAnime,trailerAnime,runtime,categoryid")] ManageAnime manageAnime)
        {
            if (id != manageAnime.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manageAnime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManageAnimeExists(manageAnime.id))
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
            return View(manageAnime);
        }

        // GET: ManageAnimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageAnime = await _context.Anime
                .FirstOrDefaultAsync(m => m.id == id);
            if (manageAnime == null)
            {
                return NotFound();
            }

            return View(manageAnime);
        }

        // POST: ManageAnimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manageAnime = await _context.Anime.FindAsync(id);
            _context.Anime.Remove(manageAnime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManageAnimeExists(int id)
        {
            return _context.Anime.Any(e => e.id == id);
        }
    }
}
