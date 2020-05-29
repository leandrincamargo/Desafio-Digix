using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.Service.Interface;

namespace Ex.Service.Service.CriteriosAvaliacao
{
    public class RendaFamiliarService : ICriterioAvaliacaoService
    {
        private const int CincoPontos = 5;
        private const int TresPontos = 3;
        private const int UmPonto = 1;
        private const int Zero = 0;
        private readonly FamiliaService _familiaBusiness;

        public RendaFamiliarService(DesafioContext desafioContext)
        {
            _familiaBusiness = new FamiliaService(desafioContext);
        }

        public int ObterPontuacao(Familia familia)
        {
            decimal rendaFamiliar = _familiaBusiness.ObterRendaFamiliar(familia);

            if (rendaFamiliar <= 900)
                return CincoPontos;
            if (rendaFamiliar <= 1500)
                return TresPontos;
            if (rendaFamiliar <= 2000)
                return UmPonto;

            return Zero;
        }
    }
}
