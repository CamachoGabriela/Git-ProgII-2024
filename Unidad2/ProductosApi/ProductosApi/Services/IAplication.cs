using ProductosApi.Models;

namespace ProductosApi.Services
{
    public interface IAplication
    {
        List<Producto> GetProductos();
        bool SaveProducto(Producto oProducto);
        bool DeleteProducto(int id);
        Producto? GetById(int id);
    }
}
