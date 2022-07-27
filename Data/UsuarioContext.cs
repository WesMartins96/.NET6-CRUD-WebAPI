using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crud_.NET6_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_.NET6_WebApi.Data
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}