using System;
using Xunit;

namespace Ex.Business.Tests.CriterioAvaliacaoTests
{
    public class PessoaBusinessTest
    {
        private readonly PessoaBusiness _pessoaBusiness;

        public PessoaBusinessTest()
        {
            _pessoaBusiness = new PessoaBusiness();
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
