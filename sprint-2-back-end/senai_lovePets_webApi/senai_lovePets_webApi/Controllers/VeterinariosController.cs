using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using senai_lovePets_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinariosController : ControllerBase
    {
        private IVeterinarioRepository _vetRepository { get; set; }

        public VeterinariosController()
        {
            _vetRepository = new VeterinarioRepository();
        }

        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_vetRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpGet("{idVet}")]
        public IActionResult BuscarPorId(int idVet)
        {
            try
            {
                return Ok(_vetRepository.BuscarPorID(idVet));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Veterinario novoVet)
        {
            try
            {
                _vetRepository.Cadastrar(novoVet);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idVet}")]
        public IActionResult Atualizar(int idVet, Veterinario vetAtualizado)
        {
            try
            {
                _vetRepository.Atualizar(idVet, vetAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{idVet}")]
        public IActionResult Deletar(int idVet)
        {
            try
            {
                _vetRepository.Deletar(idVet);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
