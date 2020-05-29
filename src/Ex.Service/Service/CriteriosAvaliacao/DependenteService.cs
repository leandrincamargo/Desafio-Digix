using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.Service.Interface;

namespace Ex.Service.Service.CriteriosAvaliacao
{
    public class DependenteService : ICriterioAvaliacaoService
    {
        private const int ZeroPonto = 0;
        private const int DoisPontos = 2;
        private const int TresPontos = 3;
        private readonly FamiliaService _familiaBusiness;

        public DependenteService(DesafioContext desafioContext)
        {
            _familiaBusiness = new FamiliaService(desafioContext);
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
