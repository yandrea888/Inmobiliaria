import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PropiedadesService {
  private apiUrl = 'https://localhost:7233/api/propiedades';

  constructor(private http: HttpClient) { }

  getPropiedades(): Observable<any> {
    return this.http.get<any>(this.apiUrl);
  }
}
