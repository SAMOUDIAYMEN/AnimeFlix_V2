using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimeFlix.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Anime.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }

        public DbSet<ManageAnime> Anime { get; set; }

        public DbSet<CategoryAnime> CategoryAnime { get; set; }
    }
}
