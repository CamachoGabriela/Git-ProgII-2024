namespace CashApplication.Models
{
    public class Cash
    {
        public string Nombre { get; set; }

        public float Valor { get; set; }

        public override string ToString()
        {
            return Nombre + " [" + Valor + "]";
        }

        public Cash()
        {

        }

        public Cash(string nombre, float valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
}
