import { CategoriasService } from './../categorias.service';
import { Categoria } from './../categoria';
import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
@Component({
  selector: 'app-detalhe-categoria',
  templateUrl: './detalhe-categoria.component.html',
  styleUrls: ['./detalhe-categoria.component.css']
})
export class DetalheCategoriaComponent implements OnInit {
  @Input() categoria?: Categoria;
  constructor(private categoriaService: CategoriasService,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.getCategoriaById();
  }
  getCategoriaById(): void {
    const id = Number(this.route.snapshot.paramMap.get('id'));

    this.categoriaService.getCategoriaById(id)
      .subscribe(categoria => this.categoria = categoria);
  }
  goBack(): void {
    this.location.back();
  }
  save(): void {
    if (this.categoria) {
      this.categoriaService.updateCategoria(this.categoria)
        .subscribe(() => this.goBack());
    }
  }
}
