using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crud_.NET6_WebApi.Models;
using Crud_.NET6_WebApi.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Crud_.NET6_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usuarios = await _usuarioRepository.BuscarUsuarios();
            return usuarios.Any() 
                ? Ok(usuarios) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> PegarPeloId(int id)
        {
            var usuario = await _usuarioRepository.BuscarUsuarioPeloId(id);
            return usuario != null 
                ? Ok(usuario) : NotFound("Usuario não encontrado");
        }

        // Adicionar
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
            return await _usuarioRepository.SaveChangesAsync()
                ? Ok("Usuario Adicionado com Sucesso!") : BadRequest("Erro ao Salvar o Usuario!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Usuario usuario)
        {
            var usuarioBanco = await _usuarioRepository.BuscarUsuarios();
            if (usuarioBanco == null) return NotFound("Usuario não encontrado");

            usuarioBanco.Nome = usuario.Nome ?? usuarioBanco.Nome;
            usuarioBanco.DataNascimento = usuario.DataNascimento != new DateTime()
                ? usuario.DataNascimento : usuarioBanco.DataNascimento;

            _usuarioRepository.AtualizarUsuario(usuarioBanco);

             return await _usuarioRepository.SaveChangesAsync()
                ? Ok("Usuario Atualizado com Sucesso!") : BadRequest("Erro ao Atualizar o Usuario!");
        }   
    }
}