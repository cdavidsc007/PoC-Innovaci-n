using System;
using System.Collections.Generic;

namespace Domain;

public partial class Comercio
{
    public int IdComercio { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();
}
