namespace BackEnd.Models
{
  public class Productos
  {
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Descripcion { get; set; }
    public string? Codigo { get; set; }
    public DateTime? FechaCreacion { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public int? IdUsuario { get; set; }

  }
}
