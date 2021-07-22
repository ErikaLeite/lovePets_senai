using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IDonoRepository
    {
        List<Dono> Listar();

        Dono BuscarPorID(int id);

        void Cadastrar(Dono novoDono);

        void Atualizar(int id, Dono donoAtualizado);

        void Deletar(int id);
    }
}
