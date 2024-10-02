using ModeloParcialWebApi.Models;

namespace ModeloParcialWebApi.Repositories
{
    public interface IPeliculaRepository
    {
        List<Pelicula> GetAll();
        List<Pelicula> GetAllEstrenos();
        bool Create(Pelicula oPelicula);
        bool Update(int id);
        bool Delete(int id, string motivo);
    }
}
