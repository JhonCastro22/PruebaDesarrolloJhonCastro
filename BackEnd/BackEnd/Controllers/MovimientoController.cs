using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
  public class MovimientoController : ControllerBase
  {
    [Route("api/Movimiento/Detalle")]
    [HttpPut]
    // GET: MovimientoController/Details/5
    public async Task<IActionResult> Details([FromBody] Movimientos movimientos)
    {
      using (BackEndContext context = new BackEndContext())
      {
        var movimiento = context.Movimientos.Where(mov => mov.Id == movimientos.Id).FirstOrDefault();
        return Ok(movimiento);

      }
    }
    [Route("api/Movimiento/Crear")]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Movimientos movimientos)
    {
      using (BackEndContext context = new BackEndContext())
      {
        try
        {
          // Obtener el último movimiento si existe
          var mov = context.Movimientos.ToList();
          if (mov.Count > 0)
          {
            var invUltimo = mov.Last();
            movimientos.Id = invUltimo.Id+1;
          }

          // Buscar el TipoMovimiento en la base de datos
          var tipoMovimientoExistente = context.TipoMovimiento
              .FirstOrDefault(i => i.Id == movimientos.IdTipo);

          if (tipoMovimientoExistente != null)
          {
            movimientos.TipoMovimiento = tipoMovimientoExistente;  // Usar la instancia existente
          }
          else
          {
            return BadRequest("El TipoMovimiento especificado no existe.");
          }

          // Guardar el movimiento
          context.Movimientos.Add(movimientos);
          context.SaveChanges();

          return Ok();
        }
        catch (DbUpdateException ex)
        {
          return BadRequest("Error al guardar cambios: " + ex.InnerException?.Message);
        }
      }
    }

    [Route("api/Movimiento/Listar")]
    [HttpGet]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> List()
    {
      try
      {
        using (BackEndContext context = new BackEndContext())
        {
          var lista = context.Movimientos.ToList();
          return Ok(lista);
        }
      }
      catch
      {
        return BadRequest();
      }
    }
    [Route("api/Movimiento/ListarMovimientos")]
    [HttpGet]
    [Authorize]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> ListMovimientos()
    {
      try
      {
        using (BackEndContext context = new BackEndContext())
        {
          var lista = context.TipoMovimiento.ToList();
          return Ok(lista);
        }
      }
      catch
      {
        return BadRequest();
      }
    }
  }
}
