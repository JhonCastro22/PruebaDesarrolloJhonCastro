namespace BackEnd.Models
{
  public class Usuarios
  {
    public int? Id { get; set; }
    public string? Nombre { get; set; }
    public string? Password { get; set; }
    public DateTime FechaCreacion { get; set; }
  }
}
