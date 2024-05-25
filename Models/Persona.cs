using System;
using System.Collections.Generic;

namespace API_SGAMI.Models;

public partial class Persona
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public string? CorreoElectronico { get; set; }

    public string? Genero { get; set; }

    public string? EstadoCivil { get; set; }

    public string? Nacionalidad { get; set; }

}
