﻿using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class FuenteFinanciamiento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public decimal? Monto { get; set; }

}
