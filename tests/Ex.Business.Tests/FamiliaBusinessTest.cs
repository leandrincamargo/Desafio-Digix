using Ex.DataContext;
using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;
using static Ex.DataModel.Model.Enumeradores;

namespace Ex.Business.Tests.CriterioAvaliacaoTests
{
    public class FamiliaBusinessTest
    {
        private readonly FamiliaBusiness _familiaBusiness;

        public FamiliaBusinessTest()
        {
            DbContextOptions<DesafioContext> options;
            var builder = new DbContextOptionsBuilder<DesafioContext>();
            builder.UseInMemoryDatabase("DesafioContext");
            options = builder.Options;
            var desafioContext = new DesafioContext(options);
            desafioContext.Database.EnsureDeleted();
            desafioContext.Database.EnsureCreated();

            _familiaBusiness = new FamiliaBusiness(desafioContext);
        }

        [Fact]
        public void ObterQuantidadeDependentesMenoresDeIdadeTest()
        {
            decimal retorno = _familiaBusiness.ObterQuantidadeDependentesMenoresDeIdade(NovaFamilia());
            decimal resultadoEsperado = 1;

            Assert.Equal(resultadoEsperado, retorno);
        }

        [Fact]
        public void ObterRendaFamiliarTest()
        {
            decimal retorno = _familiaBusiness.ObterRendaFamiliar(NovaFamilia());
            decimal resultadoEsperado = 2500;

            Assert.Equal(resultadoEsperado, retorno);
        }

        [Fact]
        public void ObterPretendenteTest()
        {
            var retorno = _familiaBusiness.ObterPretendente(NovaFamilia());

            Assert.NotNull(retorno);
        }

        #region Dados Com Pontuacao
        private static FamiliaDto NovaFamilia()
        {
            return new FamiliaDto
            {
                DominioIdStatus = (int)StatusFamilia.CadastroValido,
                Pessoas = new List<Pessoa>
                {
                    new Pessoa
                    {
                        Nome = "Matheus",
                        DominioIdTipo = (int)TipoPessoa.Pretendente,
                        DataDeNascimento = new DateTime(1950, 3, 20),
                        Rendas = new List<Renda>
                        {
                            new Renda
                            {
                                Valor = 1250
                            }
                        }
                    },
                    new Pessoa
                    {
                        Nome = "Joana",
                        DominioIdTipo = (int)TipoPessoa.Conjuge,
                        DataDeNascimento = new DateTime(1952, 11, 9),
                        Rendas = new List<Renda>
                        {
                            new Renda
                            {
                                Valor = 1250
                            }
                        }
                    },
                    new Pessoa
                    {
                        Nome = "Leandro",
                        DominioIdTipo = (int)TipoPessoa.Dependente,
                        DataDeNascimento = new DateTime(2015, 7, 12)
                    }
                }
            };
        }
        #endregion
    }
}
