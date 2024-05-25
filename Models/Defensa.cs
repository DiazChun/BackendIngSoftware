using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Defensa
{
    public int Id { get; set; }

    public int? MiembroId { get; set; }

    public int? DerechoId { get; set; }

    public DateTime? Fecha { get; set; }

    public string? Detalles { get; set; }

}
