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
    public class AnimesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Anime.ToListAsync());
        }

        // GET: Animes/Details/5
        [Authorize]
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

    }
}
