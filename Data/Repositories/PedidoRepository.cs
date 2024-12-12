using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Inmobiliaria.Models; 

namespace YourProject.Data.Repositories
{
    public class PedidoRepository
    {
        private readonly string _connectionString;

        public PedidoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Método para agregar un pedido
        public void AgregarPedido(string cedula, string direccion, decimal total, List<DetallePedido> detalles)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("AgregarPedido", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Cedula", cedula);
                command.Parameters.AddWithValue("@DireccionEntrega", direccion);
                command.Parameters.AddWithValue("@Total", total);

                command.ExecuteNonQuery(); // Ejecutamos el procedimiento para agregar el pedido

                // Aquí se deben agregar los detalles del pedido
                foreach (var detalle in detalles)
                {
                    var detalleCommand = new SqlCommand("AgregarDetallePedido", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    detalleCommand.Parameters.AddWithValue("@PedidoId", detalle.PedidoId);
                    detalleCommand.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                    detalleCommand.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                    detalleCommand.Parameters.AddWithValue("@Precio", detalle.Precio);

                    detalleCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
