import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from './components/inicio/inicio.component';
import { InventarioComponent } from './components/inventario/inventario.component';
import { ProductosComponent } from './components/productos/productos.component';
import { MovimientoDetalleComponent } from './components/inventario/movimiento-detalle/movimiento-detalle.component';
import { LoginComponent } from './components/login/login.component';

const routes: Routes = [
  {path:'',redirectTo:'/login',pathMatch:'full'},
{path:'inicio', component:InicioComponent},
{path:'inventario',component:InventarioComponent},
{path:'productos',component:ProductosComponent},
{path:'login',component:LoginComponent},
{path:'*',redirectTo:'/inicio',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
