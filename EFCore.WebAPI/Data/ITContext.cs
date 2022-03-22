using EFCore.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebAPI.Data
{
    public class ITContext : DbContext
    {
        //Padrão entityframework = quando criar uma entidade lista tem que ser plural, exemplo: equipamentos
        //DbSet = Lista

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Squad> Squads { get; set; }
        public DbSet<FuncSquad> FuncionariosSquads { get; set; }
        public DbSet<Gestor> Gestores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string de conexão

            optionsBuilder.UseSqlServer("Password=sa123456;Persist Security Info=True;User ID=sa;Initial Catalog=ITALB;Data Source=DESKTOP-9M0RIHB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //chave para gerar a Haskey composta
            modelBuilder.Entity<FuncSquad>(entity =>
              {
                  entity.HasKey(e => new { e.SquadId, e.FuncionarioId});
              });
        }
    }
}

