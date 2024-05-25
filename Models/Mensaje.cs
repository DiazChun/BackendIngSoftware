using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Mensaje
{
    public int Id { get; set; }

    public int? RemitenteId { get; set; }

    public int? DestinatarioId { get; set; }

    public string? Asunto { get; set; }

    public string? Cuerpo { get; set; }

    public DateTime? FechaEnvio { get; set; }

   
}
