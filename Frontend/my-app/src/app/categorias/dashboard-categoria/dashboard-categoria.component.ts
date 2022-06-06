import { Component, OnInit } from '@angular/core';
import { Categoria } from '../categoria';
import { CategoriasService } from '../categorias.service';

@Component({
  selector: 'app-dashboard-categoria',
  templateUrl: './dashboard-categoria.component.html',
  styleUrls: ['./dashboard-categoria.component.css']
})
export class DashboardCategoriaComponent implements OnInit {

  categorias: Categoria[] = [];
  constructor(private categoriasService: CategoriasService) { }

  ngOnInit(): void {
    this.getCategorias();
  }
  getCategorias(): void {
    this.categoriasService.getCategorias()
      .subscribe(categorias => this.categorias = categorias.slice(1, 5));
  }

}
