using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class DerechosHumano
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

}
