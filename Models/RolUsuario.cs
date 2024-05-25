using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class RolUsuario
{
    public int Id { get; set; }

    public int? UsuarioId { get; set; }

    public int? RolId { get; set; }

}
