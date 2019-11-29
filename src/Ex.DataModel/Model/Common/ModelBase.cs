using System;

namespace Ex.DataModel.Model.Common
{
    public abstract class ModelBase<T>
    {
        public bool Ativo { get; set; }

        public DateTime DataInclusaoRegistro { get; set; }

        public DateTime? DataAlteracaoRegistro { get; set; }

        public void AlterarAtivo(bool ativo)
        {
            Ativo = ativo;
        }
    }
}
