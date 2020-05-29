using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.Service.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Ex.DataModel.Model.Enumeradores;

namespace Ex.Service.Tests
{
    public class FamiliaServiceTest
    {
        [Fact]
        public void ObterQuantidadeDependentesMenoresDeIdadeTest()
        {
            // arrange
            var familia = GetFamiliaComPontuacaoFake();

            var context = CreateDbContext(familia.AsQueryable());

            var service = new FamiliaService(context.Object);

            // act
            var resultado = service.ObterQuantidadeDependentesMenoresDeIdade(familia.First());

            // assert
            Assert.Equal(1, resultado);
        }

        [Fact]
        public void ObterRendaFamiliarTest()
        {
            // arrange
            var familia = GetFamiliaComPontuacaoFake();

            var context = CreateDbContext(familia.AsQueryable());

            var service = new FamiliaService(context.Object);

            // act
            var resultado = service.ObterRendaFamiliar(familia.First());

            // assert
            Assert.Equal(2500, resultado);
        }

        [Fact]
        public void ObterPretendenteTest()
        {
            // arrange
            var familia = GetFamiliaComPontuacaoFake();

            var context = CreateDbContext(familia.AsQueryable());

            var service = new FamiliaService(context.Object);

            // act
            var resultado = service.ObterPretendente(familia.First());

            // assert
            Assert.NotNull(resultado);
        }

        private Mock<DesafioContext> CreateDbContext(IQueryable<Familia> familia)
        {
            var dbSet = new Mock<DbSet<Familia>>();
            dbSet.As<IQueryable<Familia>>().Setup(m => m.Provider).Returns(familia.Provider);
            dbSet.As<IQueryable<Familia>>().Setup(m => m.Expression).Returns(familia.Expression);
            dbSet.As<IQueryable<Familia>>().Setup(m => m.ElementType).Returns(familia.ElementType);
            dbSet.As<IQueryable<Familia>>().Setup(m => m.GetEnumerator()).Returns(familia.GetEnumerator());

            var context = new Mock<DesafioContext>();
            context.Setup(c => c.Familia).Returns(dbSet.Object);
            return context;
        }

        #region Dados Com Pontuacao
        private IEnumerable<Familia> GetFamiliaComPontuacaoFake()
        {
            var retorno = new List<Familia>()
            {
                new Familia
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
                }
            };
            return retorno.AsQueryable();
        }
        #endregion
    }
}
