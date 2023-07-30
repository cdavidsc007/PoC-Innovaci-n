using System;
using System.Collections.Generic;

namespace Domain;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Direccion { get; set; }

    public string? Telefono { get; set; }

    public double Cupo { get; set; }

    public double Deuda { get; set; }

    public virtual ICollection<Credito> Creditos { get; set; } = new List<Credito>();
}
