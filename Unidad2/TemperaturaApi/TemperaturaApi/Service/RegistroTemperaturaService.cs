using TemperaturaApi.Models;

namespace TemperaturaApi.Service
{
    public class RegistroTemperaturaService
    {
        private static RegistroTemperaturaService? _instance;
        private List<Temperatura> lstTemperaturas;

        private RegistroTemperaturaService()
        {
            lstTemperaturas = new List<Temperatura>();
        }

        public static RegistroTemperaturaService GetInstance()
        {
            if (_instance == null)
                _instance = new RegistroTemperaturaService();
            return _instance;
        }
        public List<Temperatura> GetTemperaturas()
        {
            return lstTemperaturas;
        }
        public Temperatura? GetTemperaturaById(int id)
        {
            var temperatura = lstTemperaturas.Find(temp => temp.Identificador == id);
            return temperatura;
        }


        public bool SaveTemperatura(Temperatura t)
        {
            bool result = false;
            if (t != null)
            {
                lstTemperaturas.Add(t);
                result = true;
            }
            return result;
        }
    }
}
