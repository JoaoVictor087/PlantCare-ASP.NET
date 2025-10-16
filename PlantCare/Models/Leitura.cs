namespace PlantCare.Models
{
    public class Leitura
    {
        public int IdLeitura { get; set; }
        public DateTime DataRegistro { get; set; }
        public double Valor { get; set; }
        public int IdSensor { get; set; }
    }
}
