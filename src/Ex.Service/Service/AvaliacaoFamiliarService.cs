using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;
using Ex.Service.Interface;
using Ex.Service.Service.CriteriosAvaliacao;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex.Service.Service
{
    public class AvaliacaoFamiliarService: IAvalicaoFamiliarService
    {
        private readonly DesafioContext _desafioContext;
        private readonly IFamiliaService _familiaService;

        public AvaliacaoFamiliarService(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
            _familiaService = new FamiliaService(_desafioContext);
        }

        public List<AvaliacaoFamiliarDto> ClassificarFamilias()
        {
            var avaliacoesFamiliares = new List<AvaliacaoFamiliarDto>();
            var familias = _familiaService.ObterTodosValidos();

            foreach (Familia familia in familias)
                avaliacoesFamiliares.Add(ClassificarFamilia(familia));

            return avaliacoesFamiliares.OrderByDescending(a => a.Pontuacao).ToList();
        }

        public AvaliacaoFamiliarDto ClassificarFamiliaPorId(int familiaId)
        {
            return ClassificarFamilia(_familiaService.ObterFamilia(familiaId));
        }

        private AvaliacaoFamiliarDto ClassificarFamilia(Familia familia)
        {
            var pontuacao = Pontuar(familia, new RendaFamiliarService(_desafioContext));
            pontuacao += Pontuar(familia, new PretendenteService(_desafioContext));
            pontuacao += Pontuar(familia, new DependenteService(_desafioContext));

            var avaliacao = new AvaliacaoFamiliar
            {
                Familia = familia,
                Pontuacao = pontuacao
            };

            Adicionar(avaliacao);

            return ConverterParaDto(avaliacao);
        }

        private int Pontuar(Familia familia, ICriterioAvaliacaoService criterioAvaliacao)
        {
            return criterioAvaliacao.ObterPontuacao(familia);
        }

        private AvaliacaoFamiliarDto ConverterParaDto(AvaliacaoFamiliar avaliacao)
        {
            var avaliacaoDto = new AvaliacaoFamiliarDto
            {
                Pontuacao = avaliacao.Pontuacao
            };

            avaliacaoDto.Familia = new FamiliaService(_desafioContext).ConverterParaDto(avaliacao.Familia);


            return avaliacaoDto;
        }

        private void Adicionar(AvaliacaoFamiliar avaliacao)
        {
            avaliacao.Ativo = true;
            avaliacao.DataInclusaoRegistro = DateTime.Now;

            _desafioContext.Add(avaliacao);
            _desafioContext.SaveChanges();
        }
    }
}
