using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class VeterinarioRepository : IVeterinarioRepository
    {
        private lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Veterinario vetAtualizado)
        {
            Veterinario vetBuscado = ctx.Veterinarios.Find(id);

            if (vetAtualizado.IdClinica >0)
            {
                vetBuscado.IdClinica = vetAtualizado.IdClinica;
            }

            if (vetAtualizado.Crmv != null)
            {
                vetBuscado.Crmv = vetAtualizado.Crmv;
            }

            if (vetAtualizado.NomeVeterinario != null)
            {
                vetBuscado.NomeVeterinario = vetAtualizado.NomeVeterinario;
            }

            if (vetAtualizado.IdUsuario >0)
            {
                vetBuscado.IdUsuario = vetAtualizado.IdUsuario;
            }

            ctx.Veterinarios.Update(vetBuscado);
            ctx.SaveChanges();
        }

        public Veterinario BuscarPorID(int id)
        {
            return ctx.Veterinarios.FirstOrDefault(v => v.IdVeterinario == id);
        }

        public void Cadastrar(Veterinario novoVet)
        {
            ctx.Veterinarios.Add(novoVet);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Veterinarios.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Veterinario> Listar()
        {
            return ctx.Veterinarios.ToList();
        }
    }
}
