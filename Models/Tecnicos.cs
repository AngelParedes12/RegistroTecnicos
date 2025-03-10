﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]
    public int TecnicoId { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "No se permiten Numero")]
    [Required(ErrorMessage = "El Nombres obligatorio")]
    public string? Nombres { get; set; }

    [Required(ErrorMessage = "Favor de introducir el sueldo por hora del técnico.")]
    [Range(1, 200000, ErrorMessage = "Favor de introducir un sueldo mayor que 1 y menor que 200000.")]
    public float SueldoHora { get; set; }
}
