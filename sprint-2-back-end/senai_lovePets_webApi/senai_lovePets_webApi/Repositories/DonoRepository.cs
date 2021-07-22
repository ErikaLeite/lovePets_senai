using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class DonoRepository : IDonoRepository
    {
        private lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Dono donoAtualizado)
        {
            Dono donoBuscado = ctx.Donos.Find(id);

            if (donoAtualizado.NomeDono != null)
            {
                donoBuscado.NomeDono = donoAtualizado.NomeDono;
            }

            ctx.Donos.Update(donoBuscado);

            ctx.SaveChanges();
        }

        public Dono BuscarPorID(int id)
        {
            // return ctx.Instituicoes.FirstOrDefault(i => i.IdInstituicao == id);
            return ctx.Donos.FirstOrDefault(d => d.IdDono == id);
        }

        public void Cadastrar(Dono novoDono)
        {
            ctx.Donos.Add(novoDono);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Donos.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Dono> Listar()
        {
            return ctx.Donos.ToList();
        }
    }
}
