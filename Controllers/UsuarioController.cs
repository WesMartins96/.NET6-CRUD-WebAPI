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

        // Adicionar
        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            _usuarioRepository.AdicionarUsuario(usuario);
            return await _usuarioRepository.SaveChangesAsync()
                ? Ok("Usuario Adicionado com Sucesso!") : BadRequest("Erro ao Salvar o Usuario!");
        }
    }
}