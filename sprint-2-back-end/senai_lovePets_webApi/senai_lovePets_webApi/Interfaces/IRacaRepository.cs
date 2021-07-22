﻿using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IRacaRepository
    {
        List<Raca> Listar();

        Raca BuscarPorID(int id);

        void Cadastrar(Raca novaRaca);

        void Atualizar(int id, Raca racaAtualizada);

        void Deletar(int id);
    }
}
