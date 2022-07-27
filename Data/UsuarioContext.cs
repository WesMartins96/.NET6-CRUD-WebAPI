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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var usuario = modelBuilder.Entity<Usuario>();

            usuario.ToTable("tb_usuario");

            usuario.HasKey(u => u.Id);

            usuario.Property(u => u.Id).HasColumnName("id").ValueGeneratedOnAdd();
            usuario.Property(u => u.Nome).HasColumnName("nome").IsRequired();
            usuario.Property(u => u.DataNascimento).HasColumnName("data_nascimento");
        }
    }
}