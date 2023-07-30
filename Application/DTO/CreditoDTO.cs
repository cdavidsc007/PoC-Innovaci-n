namespace Application.DTO
{
    public class CreditoDTO
    {
        public int? IdCliente { get; set; }

        public int? IdComercio { get; set; }

        public double? Monto { get; set; }

        public DateTime? FechaApro { get; set; }

        public DateTime? FechaCierre { get; set; }
    }
}