using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BotCarlaREST.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace BotCarlaREST.Models
{
    public partial class Datasql : DbContext
    {
        public Datasql()
        {

        }
        public Datasql(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=JOSSAN\SQLEXPRESS;Database=BotCarla;Trusted_Connection=True;");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Raid> raid { get; set; }

        public DbSet<BotCarlaREST.Models.Raiduser>? Raiduser { get; set; }
    }
}
