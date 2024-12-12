import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../services/pedido.service';
import { ProductoService } from '../services/producto.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedido.component.html',
  styleUrls: ['./pedido.component.css']
})
export class PedidoComponent {
  cedula: string = '';
  direccion: string = '';
  detalles: any[] = [];
  productos: any[] = [];  // Para guardar los productos disponibles

  constructor(
    private pedidoService: PedidoService,
    private productoService: ProductoService
  ) { }

  ngOnInit(): void {
    // Obtener la lista de productos cuando se cargue el componente
    this.productoService.obtenerProductos().subscribe(
      (productos) => {
        this.productos = productos;
      },
      (error) => {
        console.error('Error al obtener los productos', error);
      }
    );
  }

  agregarProducto(producto: any): void {
    // Aquí se agrega el producto a la lista de detalles del pedido
    const detalle = { producto: producto.nombre, cantidad: 1, precio: producto.precio };
    this.detalles.push(detalle);
  }

  crearPedido(): void {
    this.pedidoService.crearPedido(this.cedula, this.direccion, this.detalles)
      .subscribe(response => {
        console.log('Pedido creado con éxito', response);
      }, error => {
        console.error('Error al crear el pedido', error);
      });
  }

}
