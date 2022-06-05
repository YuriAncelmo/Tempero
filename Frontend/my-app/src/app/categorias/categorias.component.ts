import { Component, OnInit } from '@angular/core';
import { Categoria } from './categoria';
import { CATEGORIAS } from './mock-categoria';
import { CategoriasService } from './categorias.service';
@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.css']
})
export class CategoriasComponent implements OnInit {
  selectedCategoria?: Categoria;
  categorias: Categoria[] = [];

  constructor(private categoriaService: CategoriasService) { }

  ngOnInit(): void {
    this.getCategorias();
  }

  onSelect(categoria: Categoria): void {
    this.selectedCategoria = categoria;
  }
  getCategorias(): void {
    this.categorias = this.categoriaService.getCategorias();
  }
}
