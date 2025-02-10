import { Component } from '@angular/core';
import { ProductosService } from '../../services/productos.service';
import { Productos } from '../../models/productos';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css'
})
export class ProductosComponent {
  Productos!: Productos[];
  productoSeleccionado!: Productos;
  constructor(private productoService: ProductosService) { }
  ngOnInit() {
    this.GetProductos();
  }
  GetProductos() {
    this.productoService.ListProducto().subscribe(data => {
      this.Productos = data ?? [];
    });
  }
  onCreateProduct() {
    this.cerrarModal();
    this.GetProductos();
  }
  seleccionarProducto(producto: Productos) {
    console.log("PRODUCTO SELECCIONADO: ",producto)
    this.productoSeleccionado = producto; 
  }

  cerrarModal() {
    const modalElement = document.getElementById('exampleModal');
    if (modalElement) {
      const modalInstance = Modal.getInstance(modalElement) || new Modal(modalElement);
      modalInstance.hide();

      // Asegurar que la capa negra desaparezca
      document.body.classList.remove('modal-open');
      const backdrop = document.querySelector('.modal-backdrop');
      if (backdrop) {
        backdrop.remove();
      }
    }
  }
}
