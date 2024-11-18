// Services/IProductoService.cs
using System.ServiceModel;
using SoapApi.Models;

[ServiceContract]
public interface IProductoService
{
    [OperationContract]
    List<Producto> ObtenerProductos();

    [OperationContract]
    Producto ObtenerProductoPorId(int id);

    [OperationContract]
    void CrearProducto(Producto producto);

    [OperationContract]
    void EliminarProductoPorId(int id);
}
