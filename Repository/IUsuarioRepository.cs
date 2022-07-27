using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_.NET6_WebApi.Models;

namespace Crud_.NET6_WebApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> BuscarUsuarios();
        Task<Usuario> BuscarUsuarioPeloId(int id);
        void AdicionarUsuario(Usuario usuario);
        void AtualizarUsuario(Usuario usuario);
        void DeletarUsuario(Usuario usuario);
        Task<bool> SaveChangesAsync();

    }
}