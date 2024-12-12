namespace Inmobiliaria.Models
{
    public class PedidoDto
    {
        // La propiedad puede ser nula si no se inicializa
        public string Cedula { get; set; } = string.Empty;  
        public string Direccion { get; set; } = string.Empty;
        public List<DetallePedidoDto> Detalles { get; set; } = new List<DetallePedidoDto>();
    }

    public class DetallePedidoDto
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
    }
}
