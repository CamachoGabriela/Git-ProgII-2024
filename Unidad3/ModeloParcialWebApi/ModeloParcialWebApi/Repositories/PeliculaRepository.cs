using ModeloParcialWebApi.Models;

namespace ModeloParcialWebApi.Repositories
{
    public class PeliculaRepository : IPeliculaRepository
    {
        private CineDBContext _context;
        public PeliculaRepository(CineDBContext context)
        {
            _context = context;
        }
        public bool Create(Pelicula oPelicula)
        {
            oPelicula.Estreno = true;
            _context.Peliculas.Add(oPelicula);
            return _context.SaveChanges() ==1;
        }

        public bool Delete(int id, string motivo)
        {
            var peliculaEliminada = _context.Peliculas.Find(id);
            peliculaEliminada.FechaBaja = DateTime.Now;
            peliculaEliminada.MotivoBaja = motivo;
            _context.Peliculas.Update(peliculaEliminada);
            return _context.SaveChanges() ==1;
        }

        public List<Pelicula> GetAll()
        {
            return _context.Peliculas.Where(x=>x.Estreno).ToList();
        }

        public List<Pelicula> GetAllEstrenos()
        {

            return _context.Peliculas.ToList();
        }


        public bool Update(int id)
        {
            var peliculaActualizada = _context.Peliculas.Find(id);
            if(peliculaActualizada != null)
            {
                peliculaActualizada.Estreno = false;
                return _context.SaveChanges() > 0;
            }
            return false;
        }
    }
}
