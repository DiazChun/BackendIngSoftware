using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_SGAMI.Models;

public partial class SgamiContext : DbContext
{
    public SgamiContext()
    {
    }

    public SgamiContext(DbContextOptions<SgamiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actividad> Actividad { get; set; }

    public virtual DbSet<ArchivoCompartido> ArchivoCompartido { get; set; }

    public virtual DbSet<AsignacionRecurso> AsignacionRecurso { get; set; }

    public virtual DbSet<Defensa> Defensa { get; set; }

    public virtual DbSet<DerechosHumano> DerechosHumanos { get; set; }

    public virtual DbSet<Empleado> Empleado { get; set; }

    public virtual DbSet<FinanciamientoProyecto> FinanciamientoProyecto { get; set; }

    public virtual DbSet<FuenteFinanciamiento> FuenteFinanciamiento { get; set; }

    public virtual DbSet<Mensaje> Mensaje { get; set; }

    public virtual DbSet<Miembro> Miembro { get; set; }

    public virtual DbSet<Participacion> Participacion { get; set; }

    public virtual DbSet<Persona> Persona { get; set; }

    public virtual DbSet<Proyecto> Proyecto { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<RolUsuario> RolUsuario { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

}
