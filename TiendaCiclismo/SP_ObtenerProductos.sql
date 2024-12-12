CREATE PROCEDURE ObtenerProductos
AS
BEGIN
    SELECT Id, Nombre, Descripcion, Precio, Stock
    FROM Productos;
END;