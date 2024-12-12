public class Pedido
{
    public int Id { get; set; }
    public string Cedula { get; set; }
    public string DireccionEntrega { get; set; }
    public DateTime FechaPedido { get; set; }
    public decimal Total { get; set; }
}
