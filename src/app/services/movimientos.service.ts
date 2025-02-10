import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Movimientos } from '../models/movimientos';
import { Observable, throwError } from 'rxjs';
import { TipoMovimiento } from '../models/tipoMovimiento';

@Injectable({
  providedIn: 'root'
})
export class MovimientosService {

   private Url: string;
   constructor(private http: HttpClient, private config: ConfigService) {
     this.Url = this.config.ApiUrl + '/api/Movimiento'
   }
   GetMovimientos(movimientos:Movimientos):Observable<Movimientos>{
     return this.http.put<Movimientos>(this.Url+"/Detalle",movimientos);
   }
   InsertMovimiento(movimientos:Movimientos):Observable<any>{
    const token = localStorage.getItem('token');
    // console.log(token)
      if (!token) {
        console.error('No hay token disponible');
        return throwError(() => new Error('No token found'));
      }
    
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
     return this.http.post(this.Url+"/Crear",movimientos,{headers});
   }
   Listar():Observable<Movimientos[]>{
     return this.http.get<Movimientos[]>(this.Url+"/Listar");
   }
   ListarMovimientos():Observable<TipoMovimiento[]>{
    const token = localStorage.getItem('token');
    // console.log(token)
      if (!token) {
        console.error('No hay token disponible');
        return throwError(() => new Error('No token found'));
      }
    
      const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
     return this.http.get<TipoMovimiento[]>(this.Url+"/ListarMovimientos",{headers});
   }
}
