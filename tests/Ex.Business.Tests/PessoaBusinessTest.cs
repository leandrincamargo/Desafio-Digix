using Ex.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace Ex.Business.Tests.CriterioAvaliacaoTests
{
    public class PessoaBusinessTest
    {
        private readonly PessoaBusiness _pessoaBusiness;

        public PessoaBusinessTest()
        {
            DbContextOptions<DesafioContext> options;
            var builder = new DbContextOptionsBuilder<DesafioContext>();
            builder.UseInMemoryDatabase("DesafioContext");
            options = builder.Options;
            var desafioContext = new DesafioContext(options);
            desafioContext.Database.EnsureDeleted();
            desafioContext.Database.EnsureCreated();

            _pessoaBusiness = new PessoaBusiness(desafioContext);
        }

        [Fact]
        public void EhMenorDeIdadeTest()
        {
            DateTime dataNascimento = new DateTime(2010, 9, 12);
            bool retorno = _pessoaBusiness.EhMenorDeIdade(dataNascimento);

            Assert.True(retorno);
        }

        [Fact]
        public void ObterIdadeTest()
        {
            DateTime dataNascimento = new DateTime(1982, 2, 27);
            int retorno = _pessoaBusiness.ObterIdade(dataNascimento);

            Assert.Equal(37, retorno);
        }
    }
}
