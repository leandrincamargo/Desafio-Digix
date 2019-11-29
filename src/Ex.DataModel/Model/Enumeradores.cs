namespace Ex.DataModel.Model
{
    public class Enumeradores
    {
        public enum DominioCategoriaId
        {
            TipoPessoa = 1,
            StatusFamilia = 2
        }

        public enum TipoPessoa
        {
            Pretendente = 1,
            Conjuge = 2,
            Dependente = 3
        }

        public enum StatusFamilia
        {
            CadastroValido = 4,
            PossuiUmaCasa = 5,
            SelecionadaEmOutroProcesso = 6,
            CadastroIncompleto = 7
        }
    }
}
