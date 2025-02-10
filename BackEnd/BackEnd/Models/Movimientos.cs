namespace BackEnd.Models
{
  public class Movimientos
  {
    public int? Id { get; set; }
    public int? IdProducto { get; set; }
    public int? IdTipo { get; set; }
    public int? Cantidad { get; set; }
    public DateTime? Fecha { get; set; }
    public int? IdUsuario { get; set; }

    public TipoMovimiento? TipoMovimiento { get; set; }
  }
}
