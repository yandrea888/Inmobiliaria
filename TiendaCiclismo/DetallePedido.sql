CREATE TABLE DetallePedido (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT,
    ProductoId INT,
    Cantidad INT NOT NULL,
    Precio DECIMAL(18,2) NOT NULL,
    CONSTRAINT FK_Pedido FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
    CONSTRAINT FK_Producto FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);