namespace Ex.DataModel.Model.Dto
{
    public class AvaliacaoFamiliarDto
    {
        public int Pontuacao { get; set; }

        public virtual FamiliaDto Familia { get; set; }
    }
}
