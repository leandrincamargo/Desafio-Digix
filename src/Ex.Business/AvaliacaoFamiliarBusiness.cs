using Ex.Business.CriteriosAvaliacao;
using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex.Business
{
    public class AvaliacaoFamiliarBusiness
    {
        private readonly DesafioContext _desafioContext;

        public AvaliacaoFamiliarBusiness(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
        }

        public List<AvaliacaoFamiliarDto> ClassificarFamilias(List<Familia> familias)
        {
            List<AvaliacaoFamiliarDto> avaliacoesFamiliares = new List<AvaliacaoFamiliarDto>();

            foreach (Familia familia in familias)
                avaliacoesFamiliares.Add(ClassificarFamilia(familia));

            return avaliacoesFamiliares.OrderByDescending(a => a.Pontuacao).ToList();
        }

        public AvaliacaoFamiliarDto ClassificarFamilia(Familia familia)
        {
            int pontuacao = Pontuar(familia, new RendaFamiliar(_desafioContext));
            pontuacao += Pontuar(familia, new Pretendente(_desafioContext));
            pontuacao += Pontuar(familia, new Dependente(_desafioContext));

            var avaliacao = new AvaliacaoFamiliar
            {
                Familia = familia,
                Pontuacao = pontuacao
            };

            this.Adicionar(avaliacao);

            return ConverterParaDto(avaliacao);
        }

        public int Pontuar(Familia familia, ICriterioAvaliacao criterioAvaliacao)
        {
            return criterioAvaliacao.ObterPontuacao(familia);
        }

        public AvaliacaoFamiliarDto ConverterParaDto(AvaliacaoFamiliar avaliacao)
        {
            var avaliacaoDto = new AvaliacaoFamiliarDto
            {
                Pontuacao = avaliacao.Pontuacao
            };

            avaliacaoDto.Familia = new FamiliaBusiness(_desafioContext).ConverterParaDto(avaliacao.Familia);


            return avaliacaoDto;
        }

        internal void Adicionar(AvaliacaoFamiliar avaliacao)
        {
            avaliacao.Ativo = true;
            avaliacao.DataInclusaoRegistro = DateTime.Now;

            _desafioContext.Add(avaliacao);
            _desafioContext.SaveChanges();
        }
    }
}
