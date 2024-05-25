using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Actividad
{
    public int Id { get; set; }

    public int? ProyectoId { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public DateTime? FechaInicio { get; set; }

    public DateTime? FechaFin { get; set; }

    public string? Estado { get; set; }

}
