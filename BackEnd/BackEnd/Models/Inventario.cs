namespace BackEnd.Models
{
  public class Inventario
  {
    public int? Id { get; set; }
    public int? IdProducto { get; set; }
    public int? Cantidad { get; set; }
    public int? IdUsuario { get; set; }
    public Productos? Producto { get; set; }
  }
}
