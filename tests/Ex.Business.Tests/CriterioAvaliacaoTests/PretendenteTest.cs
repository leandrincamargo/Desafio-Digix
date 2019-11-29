using Ex.Business.CriteriosAvaliacao;
using Ex.DataContext;
using Ex.DataModel.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;
using static Ex.DataModel.Model.Enumeradores;

namespace Ex.Business.Tests.CriterioAvaliacaoTests
{
    public class PretendenteTest
    {
        private readonly Pretendente _pretendente;

        public PretendenteTest()
        {
            DbContextOptions<DesafioContext> options;
            var builder = new DbContextOptionsBuilder<DesafioContext>();
            builder.UseInMemoryDatabase("DesafioContext");
            options = builder.Options;
            var desafioContext = new DesafioContext(options);
            desafioContext.Database.EnsureDeleted();
            desafioContext.Database.EnsureCreated();

            _pretendente = new Pretendente(desafioContext);
        }

        [Fact]
        public void PontuarTest()
        {
            var pontuacao = _pretendente.ObterPontuacao(NovaFamilia());
            var resultadoEsperado = 3;

            Assert.Equal(resultadoEsperado, pontuacao);
        }

        #region Dados Com Pontuacao
        private static Familia NovaFamilia()
        {
            return new Familia
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
