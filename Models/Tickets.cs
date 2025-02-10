using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La prioridad es obligatoria.")]
        public string Prioridad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El asunto es obligatorio.")]
        public string Asunto { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El tiempo invertido debe ser un valor positivo.")]
        public double TiempoInvertido { get; set; }

        [ForeignKey("TecnicoId")]
        [Required(ErrorMessage = "El ID del técnico es obligatorio.")]
        public int TecnicoId { get; set; }
        public Tecnicos? Tecnico { get; set; }

        [Required(ErrorMessage = "El ID del técnico es obligatorio.")]
        [ForeignKey("ClientesId")]
        public int ClientesId { get; set; }
        public Clientes? Cliente { get; set; }
    }
}
