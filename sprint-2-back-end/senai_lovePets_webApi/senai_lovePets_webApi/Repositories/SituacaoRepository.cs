using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        private lovePetsContext ctx = new lovePetsContext();
        public void Atualizar(int id, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = ctx.Situacaos.Find(id);

            if (situacaoAtualizada.NomeSituacao != null)
            {
                situacaoBuscada.NomeSituacao = situacaoAtualizada.NomeSituacao;
            }

            ctx.Situacaos.Update(situacaoBuscada);
            ctx.SaveChanges();
        }

        public Situacao BuscarPorID(int id)
        {
            return ctx.Situacaos.FirstOrDefault(s => s.IdSituacao == id);
        }

        public void Cadastrar(Situacao novaSitaucao)
        {
            ctx.Situacaos.Add(novaSitaucao);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Situacaos.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Situacao> Listar()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
