using EFWebApi.Data.Repository;
using EFWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EFWebApi.Data.Repositories
{
    public class LibroRepository : ILibroRepository
    {
        private db_librosContext _context;

        public LibroRepository(db_librosContext context)
        {
            _context = context;
        }
        //public void SetContex(db_librosContext context)
        //{
        //    _context=context;
        //}
        public void Create(Libro libro)
        {
            _context.Libros.Add(libro);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var libroDeleted = GetById(id);
            if(libroDeleted != null)
            {
                _context.Libros.Remove(libroDeleted);
                _context.SaveChanges();
            }
            
        }

        public List<Libro> GetAll()
        {
            return _context.Libros.ToList();
        }

        public Libro? GetById(int id)
        {
            return _context.Libros.Find(id);
        }

        public void Update(Libro libro)
        {
            if (libro != null)
            {
                _context.Entry(libro).State = EntityState.Detached;
                _context.SaveChanges();
            }
        }
    }
}
