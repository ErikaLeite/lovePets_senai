using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IVeterinarioRepository
    {
        List<Veterinario> Listar();

        Veterinario BuscarPorID(int id);

        void Cadastrar(Veterinario novoVet);

        void Atualizar(int id, Veterinario vetAtualizado);

        void Deletar(int id);
    }
}
