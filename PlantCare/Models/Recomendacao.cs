namespace PlantCare.Models
{
    public class Recomendacao
    {
        public int IdRecomendacao { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Mensagem { get; set; }
        public int IdPlanta { get; set; }
    }
}
