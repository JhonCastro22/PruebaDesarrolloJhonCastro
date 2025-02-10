import { Component, EventEmitter, Output } from '@angular/core';
import { InventariosService } from '../../../services/inventarios.service';
import { MovimientosService } from '../../../services/movimientos.service';
import { Productos } from '../../../models/productos';
import { ProductosService } from '../../../services/productos.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { TipoMovimiento } from '../../../models/tipoMovimiento';
import { Movimientos } from '../../../models/movimientos';
import { Inventario } from '../../../models/inventario';
import { switchMap } from 'rxjs';

@Component({
  selector: 'app-movimiento-detalle',
  templateUrl: './movimiento-detalle.component.html',
  styleUrl: './movimiento-detalle.component.css'
})
export class MovimientoDetalleComponent {
  @Output() movimientoRealizado:EventEmitter<void>= new EventEmitter();
  listaProductos!: Productos[];
  listaTipos!: TipoMovimiento[];
  registroMovimiento!: FormGroup;
  constructor(private inventarioService: InventariosService, private movimientoService: MovimientosService, private productosService: ProductosService, private fb: FormBuilder) { }

  ngOnInit() {
    this.initFormMovimiento();
    this.listarProductos();
    this.listarTipos();
  }
  ngOnChange() { }
  initFormMovimiento() {
    this.registroMovimiento = this.fb.group({
      producto: [''],
      tipo: [''],
      cantidad: ['']
    });
  }
  listarProductos() {
    this.productosService.ListProducto().subscribe(data => {
      // console.log(data);
      this.listaProductos = data ?? [];
    });
  }
  listarTipos() {
    this.movimientoService.ListarMovimientos().subscribe(data => {
      this.listaTipos = data ?? [];
      // console.log(this.listaTipos)
    });
  }
  guardarMovimiento() {
    // var cantidad=0;
    var tipo=this.registroMovimiento.value.tipo.id;
    var cantidad=Number(this.registroMovimiento.value.cantidad)
    if(tipo==2){
      cantidad=cantidad*-1
    }
    else{
      cantidad=cantidad
    }
    const movimiento: Movimientos = {
      idProducto: this.registroMovimiento.value.producto.id,
      cantidad: Number(this.registroMovimiento.value.cantidad),
      idTipo: this.registroMovimiento.value.tipo.id,
      fecha: new Date(),
      id: 1,
      idUsuario: 1
    };
    
    const inv: Inventario = {
      idProducto: this.registroMovimiento.value.producto.id,
      cantidad: cantidad,
      id: 1,
      idUsuario: 1
    };
  
    this.movimientoService.InsertMovimiento(movimiento)
      .pipe(
        switchMap(() => this.inventarioService.InsertInvenario(inv))
      )
      .subscribe(() => {
        console.log('Movimiento e inventario insertados correctamente');
      }, error => {
        console.error('Error al insertar movimiento o inventario', error);
      });
  }  
}
