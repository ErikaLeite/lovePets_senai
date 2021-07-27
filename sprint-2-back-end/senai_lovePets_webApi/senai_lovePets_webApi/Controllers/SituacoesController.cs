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
    public class SituacoesController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository { get; set; }

        public SituacoesController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        [Authorize(Roles = "1")]
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


        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
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

        [Authorize(Roles = "1")]
        [HttpDelete("{idSituacao}")]
        public IActionResult Deletar(int idSituacao)
        {
            try
            {
                _situacaoRepository.Deletar(idSituacao);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
