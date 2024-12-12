import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PedidoService {

  private apiUrl = 'https://localhost:5001/api/pedidos'; 

  constructor(private http: HttpClient) { }
  
  crearPedido(cedula: string, direccion: string, detalles: any[]): Observable<any> {
    const request = {
      cedula: cedula,
      direccion: direccion,
      detalles: detalles
    };

    return this.http.post(this.apiUrl, request);
  }  
}
