using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class RacaRepository : IRacaRepository
    {
        private lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Raca racaAtualizada)
        {
            Raca racaBuscada = ctx.Racas.Find(id);

            if (racaAtualizada.IdTipoPet > 0)
            {
                racaBuscada.IdTipoPet = racaAtualizada.IdTipoPet;
            }

            if (racaAtualizada.NomeRaca != null)
            {
                racaBuscada.NomeRaca = racaAtualizada.NomeRaca;
            }

            ctx.Racas.Update(racaBuscada);

            ctx.SaveChanges();
        }

        public Raca BuscarPorID(int id)
        {
            return ctx.Racas.FirstOrDefault(r => r.IdRaca == id);
        }

        public void Cadastrar(Raca novaRaca)
        {
            ctx.Racas.Add(novaRaca);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Racas.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Raca> Listar()
        {
            return ctx.Racas.ToList();
        }
    }
}
