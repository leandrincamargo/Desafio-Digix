using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;
using Ex.Service.Interface;
using System;
using System.Collections.Generic;

namespace Ex.Service.Service
{
    public class PessoaService : IPessoaService
    {
        private readonly RendaService _rendaService;
        private readonly DesafioContext _desafioContext;

        public PessoaService(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
            _rendaService = new RendaService(_desafioContext);
        }

        public bool EhMenorDeIdade(DateTime dataDeNascimento)
        {
            const int maiorIdade = 18;

            return ObterIdade(dataDeNascimento) < maiorIdade;
        }

        public int ObterIdade(DateTime dataDeNascimento)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - dataDeNascimento.Year;
            var naoFezAniversarioEsteAno = dataDeNascimento.Date.AddYears(idade) > hoje;

            if (naoFezAniversarioEsteAno)
                idade--;

            return idade;
        }

        public Pessoa Converter(PessoaDto pessoaDto, int familiaId)
        {
            var pessoa = new Pessoa
            {
                Nome = pessoaDto.Nome,
                DataDeNascimento = pessoaDto.DataDeNascimento,
                DominioIdTipo = pessoaDto.TipoId,
                FamiliaId = familiaId
            };

            Adicionar(pessoa);

            foreach (var rendaDto in pessoaDto.Rendas)
                pessoa.Rendas.Add(_rendaService.Converter(rendaDto, pessoa.PessoaId));

            return pessoa;
        }

        private void Adicionar(Pessoa pessoa)
        {
            pessoa.Ativo = true;
            pessoa.DataInclusaoRegistro = DateTime.Now;

            _desafioContext.Add(pessoa);
            _desafioContext.SaveChanges();
        }

        public PessoaDto ConverterParaDto(Pessoa pessoa)
        {
            var pessoaDto = new PessoaDto
            {
                Nome = pessoa.Nome,
                TipoId = pessoa.DominioIdTipo,
                DataDeNascimento = pessoa.DataDeNascimento,
                Rendas = new List<RendaDto>()
            };

            foreach (var renda in pessoa.Rendas)
                pessoaDto.Rendas.Add(_rendaService.ConverterParaDto(renda));

            return pessoaDto;
        }
    }
}
