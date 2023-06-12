using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace app.Models
{
    public class FilmoviDbContext : DbContext
    {
        public FilmoviDbContext()
        {
        }

        public DbSet<Film> Filmovi { get; set; }
        public DbSet<Zanr> Zanrovi { get; set; }
        public DbSet<Drzava> Drzave { get; set; }

        public DbSet<Glumci> Glumci { get; set; }
    }

}