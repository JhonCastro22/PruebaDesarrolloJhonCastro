import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Inventario } from '../models/inventario';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InventariosService {
  private Url: string;

  constructor(private http: HttpClient, private config: ConfigService) {
    this.Url = this.config.ApiUrl + '/api/Inventario'
  }
  GetInventario(inventario: Inventario): Observable<Inventario> {
    return this.http.put<Inventario>(this.Url + "/Detalle", inventario);
  }
  EditInventario(inventario: Inventario) {
    return this.http.post(this.Url + "/Editar", inventario)
  }
  InsertInvenario(inventario: Inventario): Observable<any> {
    const token = localStorage.getItem('token');
    // console.log(token)
    if (!token) {
      console.error('No hay token disponible');
      return throwError(() => new Error('No token found'));
    }

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.Url + "/Crear", inventario,{headers});
  }
  ListarInventario(): Observable<Inventario[]> {
    const token = localStorage.getItem('token');
    // console.log(token)
    if (!token) {
      console.error('No hay token disponible');
      return throwError(() => new Error('No token found'));
    }

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<Inventario[]>(this.Url + "/Listar", { headers });
  }

}
