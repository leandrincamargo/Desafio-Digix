using Ex.DataContext;
using Ex.DataModel.Model;

namespace Ex.Business.CriteriosAvaliacao
{
    public class Dependente : ICriterioAvaliacao
    {
        private const int ZeroPonto = 0;
        private const int DoisPontos = 2;
        private const int TresPontos = 3;
        private readonly FamiliaBusiness _familiaBusiness;

        public Dependente(DesafioContext desafioContext)
        {
            _familiaBusiness = new FamiliaBusiness(desafioContext);
        }

        public int ObterPontuacao(Familia familia)
        {
            int quantidadeDependentesMenoresDeIdade = _familiaBusiness.ObterQuantidadeDependentesMenoresDeIdade(familia);

            if (quantidadeDependentesMenoresDeIdade == 0)
                return ZeroPonto;

            if (quantidadeDependentesMenoresDeIdade <= 2)
                return DoisPontos;

            return TresPontos;
        }
    }
}
