using Ex.DataModel.Model;
using Ex.DataModel.Model.Dto;
using System;

namespace Ex.Service.Interface
{
    public interface IPessoaService
    {
        bool EhMenorDeIdade(DateTime dataDeNascimento);
        int ObterIdade(DateTime dataDeNascimento);
        Pessoa Converter(PessoaDto pessoaDto, int familiaId);
    }
}
