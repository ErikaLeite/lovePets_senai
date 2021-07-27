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
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

       [Authorize(Roles = "1")]
       [HttpGet]
       public IActionResult ListarTodos()
       {
           try
           {
               return Ok(_clinicaRepository.Listar());
           }
           catch (Exception erro)
           {
               return BadRequest(erro);
           }
       }

        [Authorize(Roles = "1")]
        [HttpGet("{idClinica}")]
        public IActionResult BuscarPorId(int idClinica)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorID(idClinica));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Clinica novaClinica )
        {
            try
            {
                _clinicaRepository.Cadastrar(novaClinica);

                return StatusCode(201);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPut("{idClinica}")]
        public IActionResult Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            try
            {
                _clinicaRepository.Atualizar(idClinica, clinicaAtualizada);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


        [Authorize(Roles = "1")]
        [HttpDelete("{idClinica}")]
        public IActionResult Deletar(int idClinica)
        {
            try
            {
                _clinicaRepository.Deletar(idClinica);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }

}
