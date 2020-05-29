using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.Service.Service;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using Xunit;

namespace Ex.Service.Tests
{
    public class PessoaServiceTest
    {
        [Fact]
        public void EhMenorDeIdadeTest()
        {
            // arrange
            var dataNascimento = new DateTime(2010, 9, 12);

            var context = CreateDbContext();

            var service = new PessoaService(context.Object);

            // act
            var retorno = service.EhMenorDeIdade(dataNascimento);

            // assert
            Assert.True(retorno);
        }

        [Fact]
        public void ObterIdadeTest()
        {
            // arrange
            var dataNascimento = new DateTime(1982, 2, 27);

            var context = CreateDbContext();

            var service = new PessoaService(context.Object);

            // act
            var retorno = service.ObterIdade(dataNascimento);

            // assert
            Assert.Equal(38, retorno);
        }

        private Mock<DesafioContext> CreateDbContext()
        {
            var dbSet = new Mock<DbSet<Pessoa>>();

            var context = new Mock<DesafioContext>();
            context.Setup(c => c.Pessoa).Returns(dbSet.Object);
            return context;
        }
    }
}
