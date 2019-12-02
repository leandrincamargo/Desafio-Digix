using Ex.Business.CriteriosAvaliacao;
using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Xunit;
using static Ex.DataModel.Model.Enumeradores;

namespace Ex.Business.Tests.CriterioAvaliacaoTests
{
    public class DependenteTest
    {
        private readonly Dependente _dependente;

        public DependenteTest()
        {
            DbContextOptions<DesafioContext> options;
            var builder = new DbContextOptionsBuilder<DesafioContext>();
            builder.UseInMemoryDatabase("DesafioContext");
            options = builder.Options;
            var desafioContext = new DesafioContext(options);
            desafioContext.Database.EnsureDeleted();
            desafioContext.Database.EnsureCreated();

            _dependente = new Dependente(desafioContext);
        }

        [Fact]
        public void PontuarTest()
        {
            var pontuacao = _dependente.ObterPontuacao(NovaFamilia());
            var resultadoEsperado = 2;

            Assert.Equal(resultadoEsperado, pontuacao);

            pontuacao = _dependente.ObterPontuacao(NovaFamiliaSemPontuacao());
            resultadoEsperado = 5;
            Assert.NotEqual(resultadoEsperado, pontuacao);
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

        #region Dados Sem Pontuação
        private static Familia NovaFamiliaSemPontuacao()
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
                }
            };
        }
        #endregion
    }
}
