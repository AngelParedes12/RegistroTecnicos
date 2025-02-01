using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{

    
        public class Ticket
        {
            [Key]
            public int TicketId { get; set; }

            [Required]
            public DateTime Fecha { get; set; } = DateTime.Now;

            [Required]
            public string Prioridad { get; set; } = "Media";

            [Required]
            public int ClienteId { get; set; }

            [Required]
            [StringLength(100)]
            public string Asunto { get; set; }

            [Required]
            public string Descripcion { get; set; }

            public double TiempoInvertido { get; set; }

            public int? TecnicoId { get; set; }
        }
 
 }

