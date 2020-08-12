using DesktopBuilds.Domain;
using Microsoft.EntityFrameworkCore;

namespace DesktopBuilds.Data
{
    public class DesktopBuildsContext : DbContext
    {
        public DbSet<CPU> CPUs { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<GraphicCard> GraphicCards { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Desktop> Desktops { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DANIEL-KRISTENS\\SQLEXPRESS; Database=DesktopBuildsData; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
