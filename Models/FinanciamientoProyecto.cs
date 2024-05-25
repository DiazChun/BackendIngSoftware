using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class FinanciamientoProyecto
{
    public int Id { get; set; }

    public int? ProyectoId { get; set; }

    public int? FinanciamientoId { get; set; }

    public decimal? MontoAsignado { get; set; }

}
