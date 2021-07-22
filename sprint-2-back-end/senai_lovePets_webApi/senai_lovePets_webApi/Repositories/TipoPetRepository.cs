using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoPetRepository : ITipoPetRepository
    {
        private lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, TipoPet tipopetAtualizado)
        {
            TipoPet tipoBuscado = ctx.TipoPets.Find(id);

            if (tipopetAtualizado.NomeTipoPet != null)
            {
                tipoBuscado.NomeTipoPet = tipopetAtualizado.NomeTipoPet;
            }

            ctx.TipoPets.Update(tipoBuscado);
            ctx.SaveChanges();
        }

        public TipoPet BuscarPorID(int id)
        {
            return ctx.TipoPets.FirstOrDefault(tp => tp.IdTipoPet == id);
        }

        public void Cadastrar(TipoPet novoTipoPet)
        {
            ctx.TipoPets.Add(novoTipoPet);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoPets.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<TipoPet> Listar()
        {
            return ctx.TipoPets.ToList();
        }
    }
}
