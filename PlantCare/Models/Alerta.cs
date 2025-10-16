namespace PlantCare.Models
{
    public class Alerta
    {
        public int IdAlerta { get; set; }
        public DateTime DataRegistro { get; set; }
        public string TipoAlerta { get; set; }
        public string Mensagem { get; set; }
        public int IdPlanta { get; set; }
    }
}
