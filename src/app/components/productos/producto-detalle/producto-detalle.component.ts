import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ProductosService } from '../../../services/productos.service';
import { Productos } from '../../../models/productos';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
@Component({
  selector: 'app-producto-detalle',
  templateUrl: './producto-detalle.component.html',
  styleUrl: './producto-detalle.component.css'
})
export class ProductoDetalleComponent {
  @Input() productoInput!: Productos;
  @Output() productoOutput: EventEmitter<void> = new EventEmitter<void>();
  registroProducto!: FormGroup;
  constructor(private productoService: ProductosService, private fb: FormBuilder) { }
  ngOnInit() { 
    this.initFormProductos();
  }
  ngOnChanges() { }

  initFormProductos() {
    this.registroProducto = this.fb.group({
      nombre: [this.productoInput?.nombre||''],
      descripcion: [this.productoInput?.descripcion||''],
      codigo: [this.productoInput?.codigo||'']
    });
  }
  guardarProductos() {
    const Producto: Productos = {
      id:1,
      nombre: this.registroProducto.value.nombre,
      descripcion: this.registroProducto.value.descripcion,
      codigo: this.registroProducto.value.codigo,
      fechaCreacion:new Date(),
      fechaModificacion:new Date(),
      idUsuario:1
    }
    // console.log(Producto);
    this.productoService.InsertProducto(Producto).subscribe();
    this.productoOutput.emit();
  }
}
