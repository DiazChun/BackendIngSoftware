using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Miembro
{
    public int Id { get; set; }

    public int? PersonaId { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public bool? Activo { get; set; }

    
}
