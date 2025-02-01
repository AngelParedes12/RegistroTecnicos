using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }

    [Required(ErrorMessage = "La Fecha de ingreso es obligatoria.")]
    public DateTime FechaIngreso { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten números en el nombre.")]
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "La dirección es obligatoria.")]
    public string? Direccion { get; set; }

    [Required(ErrorMessage = "El RNC es obligatorio.")]
    [RegularExpression(@"^\d{9}$", ErrorMessage = "El RNC debe ser un número de 9 dígitos.")]
    public string? Rnc { get; set; }

    [Required(ErrorMessage = "El límite de crédito es obligatorio.")]
    [Range(1, 10000000, ErrorMessage = "El límite de crédito debe estar entre 1 y 10,000,000.")]
    public float LimiteCredito { get; set; }

    [System.ComponentModel.DataAnnotations.Schema.ForeignKey("Técnicoid")]
    public int TecnicoId { get; set; }
    public Tecnicos? Tecnico { get; set; }
}