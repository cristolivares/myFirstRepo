// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;
using SoapApi.Models;

namespace SoapApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}
