import { Component } from '@angular/core';
import { Inventario } from '../../models/inventario';
import { InventariosService } from '../../services/inventarios.service';
import { Movimientos } from '../../models/movimientos';
import { Modal } from 'bootstrap';

@Component({
  selector: 'app-inventario',
  templateUrl: './inventario.component.html',
  styleUrl: './inventario.component.css'
})
export class InventarioComponent {
Inventarios!:Inventario[];
  constructor(private inventarioService:InventariosService){}
  ngOnInit(){
    this.GetInventario();
  }
  GetInventario(){
    this.inventarioService.ListarInventario().subscribe(data=>{
      this.Inventarios=data??[];
    });
  }
  onCreateMovimiento(){
    this.cerrarModal();
    this.GetInventario();
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
