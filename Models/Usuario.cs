using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? PersonaId { get; set; }


}
