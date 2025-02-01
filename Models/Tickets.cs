using System.ComponentModel.DataAnnotations;
using static RegistroTecnicos.Components.Pages.Clientes.ClienteEdit;

namespace RegistroTecnicos.Models
{
    public enum Prioridad
    {
        Baja,
        Media,
        Alta,
        Urgente
    }

    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "La fecha es requerida.")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La prioridad es requerida.")]
        public Prioridad Prioridad { get; set; } = Prioridad.Media;

        [Required(ErrorMessage = "El ClienteId es requerido.")]
        [Range(1, int.MaxValue, ErrorMessage = "El ClienteId debe ser mayor que 0.")]
        public int ClienteId { get; set; }

        public Clientes? Cliente { get; set; } // Propiedad de navegación

        [Required(ErrorMessage = "El asunto es requerido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "El asunto debe tener entre 5 y 100 caracteres.")]
        public string Asunto { get; set; }

        [Required(ErrorMessage = "La descripción es requerida.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La descripción debe tener entre 10 y 500 caracteres.")]
        public string Descripcion { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El tiempo invertido no puede ser negativo.")]
        public double TiempoInvertido { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El TecnicoId debe ser mayor que 0.")]
        public int? TecnicoId { get; set; }

        public Tecnicos? Tecnico { get; set; } // Propiedad de navegación
    }
}