using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class ArchivoCompartido
{
    public int Id { get; set; }

    public int? ProyectoId { get; set; }

    public string? NombreArchivo { get; set; }

    public string? RutaArchivo { get; set; }

    public DateTime? FechaSubida { get; set; }

    public int? SubidoPor { get; set; }

}
