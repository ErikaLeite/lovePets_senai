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
    }
}
