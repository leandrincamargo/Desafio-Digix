using Ex.DataModel.Mapping;
using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ex.DataContext
{
    public class DesafioContext : DbContext
    {
        public DesafioContext(DbContextOptions<DesafioContext> options) : base(options) { }
        public DesafioContext() { }

        public virtual DbSet<AvaliacaoFamiliar> AvaliacaoFamiliar { get; set; }
        public virtual DbSet<Familia> Familia { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Renda> Renda { get; set; }
        public virtual DbSet<Dominio> Dominio { get; set; }
        public virtual DbSet<DominioCategoria> DominioCategoria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AvaliacaoFamiliarMapping());
            modelBuilder.ApplyConfiguration(new FamiliaMapping());
            modelBuilder.ApplyConfiguration(new PessoaMapping());
            modelBuilder.ApplyConfiguration(new RendaMapping());
            modelBuilder.ApplyConfiguration(new DominioMapping());
            modelBuilder.ApplyConfiguration(new DominioCategoriaMapping());

            
            modelBuilder.Entity<DominioCategoria>()
                .HasData(
                    new DominioCategoria
                    {
                        DominioCategoriaId = 1,
                        Nome = "Tipo Pessoa",
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                        
                    },
                    new DominioCategoria
                    {
                        DominioCategoriaId = 2,
                        Nome = "Status Familia",
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    }
                );

            modelBuilder.Entity<Dominio>()
                .HasData(
                    new Dominio
                    {
                        DominioId = 1,
                        Nome = "Pretendente",
                        DominioCategoriaId = 1,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    },
                    new Dominio
                    {
                        DominioId = 2,
                        Nome = "Conjuge",
                        DominioCategoriaId = 1,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    },
                    new Dominio
                    {
                        DominioId = 3,
                        Nome = "Dependente",
                        DominioCategoriaId = 1,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    },

                    new Dominio
                    {
                        DominioId = 4,
                        Nome = "Cadastro Válido",
                        DominioCategoriaId = 2,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    },
                    new Dominio
                    {
                        DominioId = 5,
                        Nome = "Possui Uma Casa",
                        DominioCategoriaId = 2,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    },
                    new Dominio
                    {
                        DominioId = 6,
                        Nome = "Selecionada Em Outro Processo",
                        DominioCategoriaId = 2,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    },
                    new Dominio
                    {
                        DominioId = 7,
                        Nome = "Cadastro Incompleto",
                        DominioCategoriaId = 2,
                        DataInclusaoRegistro = DateTime.Now,
                        Ativo = true
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
