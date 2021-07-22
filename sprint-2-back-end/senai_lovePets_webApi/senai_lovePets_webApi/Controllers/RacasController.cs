using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class RacasController : ControllerBase
    {
        private IRacaRepository _racaRepository { get; set; }

        public RacasController()
        {
            _racaRepository = new RacaRepository();
        }
    }
}
