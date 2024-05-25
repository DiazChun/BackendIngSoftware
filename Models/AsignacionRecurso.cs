using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class AsignacionRecurso
{
    public int Id { get; set; }

    public int? EmpleadoId { get; set; }

    public int? ProyectoId { get; set; }

    public string? Rol { get; set; }

    public DateTime? FechaAsignacion { get; set; }

}
