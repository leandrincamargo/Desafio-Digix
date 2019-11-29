using System;
using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;

namespace Ex.Business
{
    public class RendaBusiness
    {
        private readonly DesafioContext _desafioContext;

        public RendaBusiness(DesafioContext desafioContext)
        {
            _desafioContext = desafioContext;
        }

        public Renda Converter(RendaDto rendaDto, int pessoaId)
        {
            var renda = new Renda
            {
                Valor = rendaDto.Valor,
                PessoaId = pessoaId
            };

            this.Adicionar(renda);

            return renda;
        }

        private void Adicionar(Renda renda)
        {
            renda.Ativo = true;
            renda.DataInclusaoRegistro = DateTime.Now;

            _desafioContext.Add(renda);
            _desafioContext.SaveChanges();
        }

        public RendaDto ConverterParaDto(Renda renda)
        {
            var rendaDto = new RendaDto
            {
                Valor = renda.Valor
            };

            return rendaDto;
        }
    }
}
