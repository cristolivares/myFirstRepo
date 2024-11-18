// Services/ProductoService.cs
using SoapApi.Models;
using SoapApi.Data;

namespace SoapApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly AppDbContext _context;

        public ProductoService(AppDbContext context)
        {
            _context = context;
        }

        public List<Producto> ObtenerProductos()
        {
            return _context.Productos.ToList();
        }

        public Producto ObtenerProductoPorId(int id)
        {
            return _context.Productos.FirstOrDefault(p => p.Id == id);
        }

        public void CrearProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }
    }

}
