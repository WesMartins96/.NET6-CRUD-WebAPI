using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Crud_.NET6_WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Crud_.NET6_WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>
            {
                new Usuario{ Id = 1, Nome = "Wesley", DataNascimento = new DateTime(1996, 06, 16)},
                new Usuario{ Id = 2, Nome = "Beatriz", DataNascimento = new DateTime(1997, 08, 07)},
                new Usuario{ Id = 3, Nome = "Gael", DataNascimento = new DateTime(2020, 04, 19)}
            };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }

        // Adicionar
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            var usuarios = Usuarios();
            usuarios.Add(usuario);
            return Ok(usuarios);
        }
    }
}