import { Component, OnInit } from '@angular/core';
import { PropiedadesService } from './services/propiedades.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  propiedades: any[] = [];

  constructor(private propiedadesService: PropiedadesService) { }

  ngOnInit(): void {
      this.propiedadesService.getPropiedades().subscribe((data) => {
      this.propiedades = data;
    });
  }
}
