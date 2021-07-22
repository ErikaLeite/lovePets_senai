using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        lovePetsContext ctx = new lovePetsContext();

        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            Usuario userBuscado = ctx.Usuarios.Find(id);

            if (usuarioAtualizado.IdTipoUsuario > 0)
            {
                userBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            if (usuarioAtualizado.Email != null)
            {
                userBuscado.Email = usuarioAtualizado.Email;
            }

            if (usuarioAtualizado.Senha != null)
            {
                userBuscado.Senha = usuarioAtualizado.Senha;
            }

            ctx.Usuarios.Find(id);
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuário existente através do seu e-mail e sua senha
        /// </summary>
        /// <param name="email">O valor do e-mail digitado pelo usuário</param>
        /// <param name="senha">O valor da senha digitada pelo usuário</param>
        /// <returns>Um usuário encontrado</returns>
        public Usuario BuscarPorEmailSenha(string email, string senha)

        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public Usuario BuscarPorID(int id)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Usuarios.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }
    }
    
}
