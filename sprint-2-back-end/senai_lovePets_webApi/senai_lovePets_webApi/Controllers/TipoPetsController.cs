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
    public class TipoPetsController : ControllerBase
    {
        private ITipoPetRepository _tipoPetRepository { get; set; }

        public TipoPetsController()
        {
            _tipoPetRepository = new TipoPetRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_tipoPetRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{idTipoPet}")]
        public IActionResult BuscarPorId(int idTipoPet)
        {
            try
            {
                return Ok(_tipoPetRepository.BuscarPorID(idTipoPet));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoPet novoTipo)
        {
            try
            {
                _tipoPetRepository.Cadastrar(novoTipo);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idTipoPet}")]
        public IActionResult Atualizar(int idTipoPet, TipoPet tipoPetAtualizado)
        {
            try
            {
                _tipoPetRepository.Atualizar(idTipoPet, tipoPetAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
