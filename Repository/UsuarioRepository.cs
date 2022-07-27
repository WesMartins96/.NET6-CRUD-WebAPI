using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_.NET6_WebApi.Data;
using Crud_.NET6_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_.NET6_WebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public void AdicionarUsuario(Usuario usuario)
        {
            _context.Add(usuario);
            
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> BuscarUsuarioPeloId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Usuario>> BuscarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public void DeletarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
                                                // retorna 0 ou 1, se for amior do q 0 é salvo, caso não retorna False.
            return await _context.SaveChangesAsync() > 0;
        }
    }
}