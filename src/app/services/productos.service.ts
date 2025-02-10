import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Productos } from '../models/productos';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductosService {

  private Url: string;
  constructor(private http: HttpClient, private config: ConfigService) {
    this.Url = this.config.ApiUrl + '/api/Productos'
  }
  GetProducto(productos: Productos): Observable<Productos> {
    return this.http.put<Productos>(this.Url + "/Detalle", productos);
  }
  InsertProducto(productos: Productos): Observable<any> {
    const token = localStorage.getItem('token');
    // console.log(token)
    if (!token) {
      console.error('No hay token disponible');
      return throwError(() => new Error('No token found'));
    }
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    // console.log(productos,this.Url+"/Crear")
    return this.http.post(this.Url + "/Crear", productos, { headers });
  }
  ListProducto(): Observable<Productos[]> {
    const token = localStorage.getItem('token');
    // console.log(token)
    if (!token) {
      console.error('No hay token disponible');
      return throwError(() => new Error('No token found'));
    }

    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<Productos[]>(this.Url + "/Listar", { headers });
  }
  EditProducto(): Observable<Productos> {
    return this.http.get<Productos>(this.Url + "/Editar");
  }
}
