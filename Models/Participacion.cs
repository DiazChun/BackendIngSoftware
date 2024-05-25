using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Participacion
{
    public int Id { get; set; }

    public int? MiembroId { get; set; }

    public int? ProyectoId { get; set; }

    public string? Rol { get; set; }

}
