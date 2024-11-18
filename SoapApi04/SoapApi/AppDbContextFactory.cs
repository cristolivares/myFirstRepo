using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SoapApi.Data;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlite("Data Source=database.db"); // Cambia a tu cadena de conexión

        return new AppDbContext(optionsBuilder.Options);
    }
}
