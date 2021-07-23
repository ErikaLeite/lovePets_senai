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
    public class SituacoesController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository { get; set; }

        public SituacoesController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

       [HttpGet]
       public IActionResult ListarTodos()
       {
           try
           {
               return Ok(_situacaoRepository.Listar());
           }
           catch (Exception erro)
           {
               return BadRequest(erro);
           }
       }


        [HttpGet("{idSituacao}")]
        public IActionResult BuscarPorId(int idSituacao)
        {
            try
            {
                return Ok(_situacaoRepository.BuscarPorID(idSituacao));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Situacao novaSituacao)
        {
            try
            {
                _situacaoRepository.Cadastrar(novaSituacao);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{idSituacao}")]
        public IActionResult Atualizar(int idSituacao, Situacao situacaoAtualizada)
        {
            try
            {
                _situacaoRepository.Atualizar(idSituacao, situacaoAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
