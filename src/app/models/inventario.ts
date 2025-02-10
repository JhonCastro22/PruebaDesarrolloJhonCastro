import { Productos } from "./productos";

export class Inventario {
    id?: number | null = null;
    idProducto?: number | null = null;
    cantidad?: number | null = null;
    idUsuario?: number | null = null;
    producto?: Productos | null = null;
}