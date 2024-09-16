namespace FechaApi.Models
{
    public class Fecha
    {
        public int Numero { get; set; }
        public string Dia { get; set; }
        public string Mes { get; set; }
        public int Anho { get; set; }

        DateTime date = DateTime.Today;
    }
}
