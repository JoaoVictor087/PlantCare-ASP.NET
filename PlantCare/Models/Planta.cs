using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlantCare.Models
{
    [Table("T_PC_PLANTA")]
    public class Planta
    {
        [Key]
        [Column("ID_PLANTA")]
        public int IdPlanta { get; set; }

        [Required]
        [Column("NM_PLANTA")]
        public string NmPlanta { get; set; }

        [Required]
        [Column("TIPO_PLANTA")]
        public string TipoPlanta { get; set; }

        [Column("ID_USUARIO")]
        public int? IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario? Usuario { get; set; }

        [Required]
        [Column("DT_CADASTRO")]
        public DateTime DtCadastro { get; set; } = DateTime.Now;
    }
}
