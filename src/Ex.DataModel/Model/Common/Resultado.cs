using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Ex.DataModel.Model.Common
{

    public class Resultado
    {
        public bool Success { get { return !PossuiErros(); } }
        public List<string> Erros { get; private set; } = new List<string>();
        public Resultado() { }
        public void AdicionarErro(string descricao) => Erros.Add(descricao);
        public bool PossuiErros() => Erros.Any();
        public void AdicionarErros(List<ValidationFailure> erros) => erros.ForEach(x => AdicionarErro(x.ErrorMessage));
    }
}
