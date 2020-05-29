using Ex.DataContext;
using Ex.DataModel.Model;
using Ex.Service.Interface;

namespace Ex.Service.Service.CriteriosAvaliacao
{
    public class PretendenteService : ICriterioAvaliacaoService
    {
        private const int UmPonto = 1;
        private const int DoisPontos = 2;
        private const int TresPontos = 3;
        private readonly FamiliaService _familiaBusiness;
        private readonly PessoaService _pessoaBusiness;

        public PretendenteService(DesafioContext desafioContext)
        {
            _familiaBusiness = new FamiliaService(desafioContext);
            _pessoaBusiness = new PessoaService(desafioContext);
        }

        public int ObterPontuacao(Familia familia)
        {
            var pretendente = _familiaBusiness.ObterPretendente(familia);
            int idadeDoPretendente = _pessoaBusiness.ObterIdade(pretendente.DataDeNascimento);

            if (idadeDoPretendente < 30)
                return UmPonto;
            if (idadeDoPretendente <= 44)
                return DoisPontos;

            return TresPontos;
        }
    }
}
