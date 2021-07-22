using senai_lovePets_webApi.Contexts;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class PetRepository : IPetRepository
    {
        private lovePetsContext ctx = new lovePetsContext();
        
        public void Atualizar(int id, Pet petAtualizado)
        {
            Pet petBuscado = ctx.Pets.Find(id);

            if (petAtualizado != null)
            {
                petBuscado.NomePet = petAtualizado.NomePet;
            }

            if (petAtualizado.Ra != null)
            {
                petBuscado.Ra = petAtualizado.Ra;
            }

            if (petAtualizado.DataNascimento >= DateTime.Today)
            {
                petBuscado.DataNascimento = petAtualizado.DataNascimento;
            }

            if (petAtualizado.IdDono > 0)
            {
                petBuscado.IdDono = petAtualizado.IdDono;
            }

            if (petAtualizado.IdRaca > 0)
            {
                petBuscado.IdRaca = petAtualizado.IdRaca;
            }

            if (petAtualizado.IdUsuario > 0)
            {
                petBuscado.IdUsuario = petAtualizado.IdUsuario;
            }

            ctx.Pets.Update(petBuscado);

            ctx.SaveChanges();

        }

        public Pet BuscarPorID(int id)
        {
            return ctx.Pets.FirstOrDefault(p => p.IdPet == id);
        }

        public void Cadastrar(Pet novoPet)
        {
            ctx.Pets.Add(novoPet);
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.Pets.Remove(BuscarPorID(id));
            ctx.SaveChanges();
        }

        public List<Pet> Listar()
        {
            return ctx.Pets.ToList();
        }
    }
}
