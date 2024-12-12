namespace Inmobiliaria.Models
{
    public class DetallePedido
    {
        public int Id { get; set; } 
        public int PedidoId { get; set; } 
        public int ProductoId { get; set; } 
        public int Cantidad { get; set; } 
        public decimal Precio { get; set; } 
    }
}