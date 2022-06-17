using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class UsuariosService : IUsuarioService
    {
        private readonly UsuarioContext _context;

        public UsuariosService(UsuarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUsuario(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUsuario(Usuario usuario)
        {
            _context.Entry(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}