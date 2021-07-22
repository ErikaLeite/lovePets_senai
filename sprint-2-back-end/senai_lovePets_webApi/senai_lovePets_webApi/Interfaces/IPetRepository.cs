using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IPetRepository
    {
        List<Pet> Listar();

        Pet BuscarPorID(int id);

        void Cadastrar(Pet novoPet);

        void Atualizar(int id, Pet petAtualizado);
            
        void Deletar(int id);
    }
}
