namespace WebProductos.Models
{
    public class Producto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set;}
        public float Precio { get; set;}

        public override string ToString()
        {
            return Nombre + " [" + Precio + "]";
        }
    }
}
