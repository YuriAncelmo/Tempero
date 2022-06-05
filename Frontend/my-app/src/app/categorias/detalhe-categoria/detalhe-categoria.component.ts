import { Categoria } from './../categoria';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-detalhe-categoria',
  templateUrl: './detalhe-categoria.component.html',
  styleUrls: ['./detalhe-categoria.component.css']
})
export class DetalheCategoriaComponent implements OnInit {
  @Input() categoria?: Categoria;
  constructor() { }

  ngOnInit(): void {
  }

}
