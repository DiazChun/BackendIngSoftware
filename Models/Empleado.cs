using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Empleado
{
    public int Id { get; set; }

    public int? PersonaId { get; set; }

    public string? Puesto { get; set; }

    public DateTime? FechaContratacion { get; set; }

    public decimal? Salario { get; set; }

    public string? Departamento { get; set; }

}
