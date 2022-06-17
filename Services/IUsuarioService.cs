using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;

namespace api.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task CreateUsuario(Usuario usuario);
        Task UpdateUsuario(Usuario usuario);
        Task DeleteUsuario(Usuario usuario);
    }
}