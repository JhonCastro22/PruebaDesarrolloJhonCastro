import { TipoMovimiento } from "./tipoMovimiento";

export class Movimientos{
    id?:number|null=null;
    idProducto?:number|null=null;
    idTipo?:number|null=null;
    cantidad?:number|null=null;
    fecha?:Date|null=null;
    idUsuario?:number|null=null;
    tipoMovimiento?:TipoMovimiento|null=null;
}