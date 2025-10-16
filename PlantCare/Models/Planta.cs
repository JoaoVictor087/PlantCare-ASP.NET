namespace PlantCare.Models
{
    public class Planta
    {
        public int IdPlanta { get; set; }
        public string Nome {get; set; }
        public string TipoPlanta { get; set; }
        public DateTime DataCadastro { get; set; }
        public int IdUsuario { get; set; }

    }
}
