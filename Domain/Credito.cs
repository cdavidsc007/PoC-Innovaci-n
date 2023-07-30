using System;
using System.Collections.Generic;

namespace Domain;

public partial class Credito
{
    public int IdCredito { get; set; }

    public int? IdCliente { get; set; }

    public int? IdComercio { get; set; }

    public double? Monto { get; set; }

    public DateTime? FechaApro { get; set; }

    public DateTime? FechaCierre { get; set; }

    public virtual Cliente? IdClienteNavigation { get; set; }

    public virtual Comercio? IdComercioNavigation { get; set; }
}
