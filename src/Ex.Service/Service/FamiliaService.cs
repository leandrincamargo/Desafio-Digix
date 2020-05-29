using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.DataModel.Model.Common;
using Ex.DataModel.Model.Dto;
using Ex.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using static Ex.DataModel.Model.Enumeradores;

namespace Ex.Service.Service
{
    public class FamiliaService : IFamiliaService
    {
        private readonly PessoaService _pessoaService;
        private readonly DesafioContext _desafioContext;

        public FamiliaService(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
            _pessoaService = new PessoaService(_desafioContext);
        }

        public IQueryable<Familia> ObterTodos()
        {
            return _desafioContext.Familia;
        }

        public Familia ObterFamilia(int familiaId)
        {
            return _desafioContext.Familia.Where(x => x.FamiliaId == familiaId).FirstOrDefault();
        }

        public List<Familia> ObterTodosValidos()
        {
            return _desafioContext.Familia.Where(x => x.DominioIdStatus == (int)StatusFamilia.CadastroValido).ToList();
        }

        public decimal ObterRendaFamiliar(Familia familia)
        {
            return familia.Pessoas.Sum(p => p.Rendas.Sum(r => r.Valor));
        }

        public Pessoa ObterPretendente(Familia familia)
        {
            return familia.Pessoas.Where(p => p.DominioIdTipo == (int)TipoPessoa.Pretendente).FirstOrDefault();
        }

        public Resultado Adicionar(FamiliaDto familiaDto)
        {
            var resultado = new Resultado();

            try
            {
                Converter(familiaDto);
            }
            catch (Exception e)
            {
                resultado.AdicionarErro(e.Message);
            }

            return resultado;
        }

        public int ObterQuantidadeDependentesMenoresDeIdade(Familia familia)
        {
            return familia.Pessoas.Count(p => p.DominioIdTipo == (int)TipoPessoa.Dependente && _pessoaService.EhMenorDeIdade(p.DataDeNascimento));
        }

        private Familia Converter(FamiliaDto familiaDto)
        {
            var familia = new Familia
            {
                DominioIdStatus = (int)StatusFamilia.CadastroIncompleto
            };

            Adicionar(familia);

            foreach (var pessoaDto in familiaDto.Pessoas)
                familia.Pessoas.Add(_pessoaService.Converter(pessoaDto, familia.FamiliaId));

            Validar(familia);

            return familia;
        }

        public FamiliaDto ConverterParaDto(Familia familia)
        {
            var familiaDto = new FamiliaDto
            {
                Pessoas = new List<PessoaDto>()
            };

            foreach (var pessoa in familia.Pessoas)
                familiaDto.Pessoas.Add(_pessoaService.ConverterParaDto(pessoa));

            return familiaDto;
        }

        private void Adicionar(Familia familia)
        {
            familia.Ativo = true;
            familia.DataInclusaoRegistro = DateTime.Now;

            _desafioContext.Add(familia);
            _desafioContext.SaveChanges();
        }

        private void Validar(Familia familia)
        {
            if (familia.Pessoas != null && familia.Pessoas.Any(p => p.DominioIdTipo == (int)TipoPessoa.Pretendente))
                familia.DominioIdStatus = (int)StatusFamilia.CadastroValido;

            _desafioContext.Update(familia);
            _desafioContext.SaveChanges();
        }

        private void Atualizar(Familia familia)
        {
            familia.DataAlteracaoRegistro = DateTime.Now;

            _desafioContext.Update(familia);
            _desafioContext.SaveChanges();
        }
    }
}
