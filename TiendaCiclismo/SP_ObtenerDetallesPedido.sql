CREATE PROCEDURE ObtenerDetallesPedido
    @PedidoId INT
AS
BEGIN
    SELECT p.Nombre, dp.Cantidad, dp.Precio, (dp.Cantidad * dp.Precio) AS Subtotal
    FROM DetallePedido dp
    JOIN Productos p ON dp.ProductoId = p.Id
    WHERE dp.PedidoId = @PedidoId;
END;
