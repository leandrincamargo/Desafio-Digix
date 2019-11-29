using Ex.DataContext;
using Ex.DataModel.Model;

namespace Ex.Business.CriteriosAvaliacao
{
    public class Pretendente : ICriterioAvaliacao
    {
        private const int UmPonto = 1;
        private const int DoisPontos = 2;
        private const int TresPontos = 3;
        private readonly FamiliaBusiness _familiaBusiness;
        private readonly PessoaBusiness _pessoaBusiness;

        public Pretendente(DesafioContext desafioContext)
        {
            _familiaBusiness = new FamiliaBusiness(desafioContext);
            _pessoaBusiness = new PessoaBusiness(desafioContext);
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
