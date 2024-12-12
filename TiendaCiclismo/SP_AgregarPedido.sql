CREATE PROCEDURE AgregarPedido
    @Cedula NVARCHAR(20),
    @DireccionEntrega NVARCHAR(255),
    @Productos XML 
AS
BEGIN
    -- Insertar el pedido
    INSERT INTO Pedidos (Cedula, DireccionEntrega, Total)
    VALUES (@Cedula, @DireccionEntrega, 0); 

    DECLARE @PedidoId INT = SCOPE_IDENTITY(); 

    DECLARE @Total DECIMAL(18,2) = 0;

    -- Insertar los detalles del pedido
    DECLARE @ProductoId INT, @Cantidad INT, @Precio DECIMAL(18,2);
    DECLARE ProductosCursor CURSOR FOR
        SELECT
            Producto.value('Id[1]', 'INT'),
            Producto.value('Cantidad[1]', 'INT'),
            Producto.value('Precio[1]', 'DECIMAL(18,2)')
        FROM @Productos.nodes('/Productos/Producto') AS X(Producto);

    OPEN ProductosCursor;
    FETCH NEXT FROM ProductosCursor INTO @ProductoId, @Cantidad, @Precio;

    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Insertar cada producto en el detalle
        INSERT INTO DetallePedido (PedidoId, ProductoId, Cantidad, Precio)
        VALUES (@PedidoId, @ProductoId, @Cantidad, @Precio);

        -- Calcular el total del pedido
        SET @Total = @Total + (@Cantidad * @Precio);

        FETCH NEXT FROM ProductosCursor INTO @ProductoId, @Cantidad, @Precio;
    END

    CLOSE ProductosCursor;
    DEALLOCATE ProductosCursor;

    -- Actualizar el total del pedido
    UPDATE Pedidos
    SET Total = @Total
    WHERE Id = @PedidoId;
END;
