using BackCine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackCine.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetClientes();
        Task<Cliente?> GetClienteById(int id);
        Task<Cliente?> FiltrarClientePorNombre(string nombre, string apellido);
        Task<bool> RegistrarCliente (Cliente cliente);
        Task<bool> Editar(int id, Cliente cliente);
        Task<bool> Eliminar (int id);
    }
}
