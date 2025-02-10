import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ConfigService } from './config.service';
import { Usuarios } from '../models/usuarios';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

    private Url: string;
    constructor(private http: HttpClient, private config: ConfigService) {
      this.Url = this.config.ApiUrl + '/api/Usuarios'
    }
    GetUsuarios(usuarios:Usuarios):Observable<Usuarios>{
      return this.http.put<Usuarios>(this.Url+"/Detalle",usuarios);
    }
    InsertUsuario(usuarios:Usuarios):Observable<any>{
      return this.http.post(this.Url+"/Crear",usuarios);
    }
    ListarUsuarios():Observable<Usuarios[]>{
      return this.http.get<Usuarios[]>(this.Url+"/Listar");
    }
}
