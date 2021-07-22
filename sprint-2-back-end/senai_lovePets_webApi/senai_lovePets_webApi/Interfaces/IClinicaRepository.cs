using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IClinicaRepository
    {
        List<Clinica> Listar();

        Clinica BuscarPorID(int id);

        void Cadastrar(Clinica novaClinica);

        void Atualizar(int id, Clinica clinicaAtualizada);

        void Deletar(int id);
    }
}
