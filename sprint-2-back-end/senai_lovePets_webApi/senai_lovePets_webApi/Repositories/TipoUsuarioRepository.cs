using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, TipoUsuario tipoUsuarioAtualizado)
        {
            TipoUsuario tipoBuscado = ctx.TipoUsuarios.Find(id);

            if (tipoUsuarioAtualizado.NomeTipoUsuario != null)
            {
                tipoBuscado.NomeTipoUsuario = tipoUsuarioAtualizado.NomeTipoUsuario;
            }

            ctx.TipoUsuarios.Update(tipoBuscado);
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorID(int id)
        {
            return ctx.TipoUsuarios.FirstOrDefault(tu => tu.IdTipoUsuario == id);
        }

        public void Cadastrar(TipoUsuario novoTipoUsuario)
        {
            ctx.TipoUsuarios.Add(novoTipoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TipoUsuarios.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<TipoUsuario> Listar()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
