﻿using EventoPlus.Interfaces;
using EventPlus.Domains;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventoPlus.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        /// Endpoint para listar usuario por id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.BuscarPorId(id);
                if (usuarioBuscado != null)
                {
                    return Ok(usuarioBuscado);
                }
                return null!;
            }
            catch (Exception e)
            {

                return BadRequest(e);
            }
        }

        /// <summary>
        /// Endpoint para cadastrar usuario.
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult Post(Usuario usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Created();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet("BuscarPorEmailESenha/{email}, {senha}")]
        public IActionResult Get(string email, string senha)
        {
            try
            {
                Usuario novoUsuario = _usuarioRepository.BuscarPorEmailESenha(email, senha);
                return Ok(novoUsuario);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        }
}
