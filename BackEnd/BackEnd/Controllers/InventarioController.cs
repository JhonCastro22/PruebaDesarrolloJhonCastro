using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Controllers
{
  public class InventarioController : ControllerBase
  {
    [Route("api/Inventario/Detalle")]
    [HttpPut]
    // GET: InventarioController/Details/5
    public async Task<IActionResult> Details([FromBody] Inventario inventario)
    {
      using (BackEndContext context = new BackEndContext())
      {
        var inv = context.Inventario.Where(inve => inve.Id == inventario.Id).FirstOrDefault();
        return Ok(inv);
      }
    }
    [Route("api/Inventario/Crear")]
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Inventario inventario)
    {
      using (BackEndContext context = new BackEndContext())
      {
        var inv = context.Inventario
            .FirstOrDefault(i => i.IdProducto == inventario.IdProducto);

        if (inv != null)
        {
          inv.Cantidad += inventario.Cantidad;
        }
        else
        {
          var invUltimo = context.Inventario
              .OrderByDescending(i => i.Id)  // Ordenar por Id de mayor a menor
              .FirstOrDefault();

          inventario.Id = (invUltimo != null) ? invUltimo.Id + 1 : 1;

          // Buscar el producto en la BD y asignarlo en lugar de crear una nueva instancia
          var prod = context.Productos
              .FirstOrDefault(i => i.Id == inventario.IdProducto);

          if (prod != null)
          {
            inventario.Producto = prod; // 🔹 Asignar la referencia existente en EF
          }

          context.Add(inventario);
        }

        context.SaveChanges();
      }

      return Ok();
    }



    // POST: InventarioController/Create
    [Route("api/Inventario/Editar")]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromBody] Inventario inventario)
    {
      try
      {
        using (BackEndContext context = new BackEndContext()) {
          var inv=context.Inventario.Where(i => i.Id == inventario.Id).FirstOrDefault();
          if (inv != null)
          {
            inv.Cantidad = inventario.Cantidad;
            inv.IdProducto = inventario.IdProducto;
            inv.IdUsuario = inventario.IdUsuario;
            context.SaveChanges();
            return Ok();
          }
          else {
        return BadRequest("No se encuentra el dato");
          }
        }
      }
      catch
      {
        return BadRequest();
      }
    }
    [Route("api/Inventario/Listar")]
    [HttpGet]
    [Authorize]
    // GET: InventarioController/Edit/5
    public async Task<IActionResult> List()
    {
      using (BackEndContext context = new BackEndContext()) {
        var listaInventario=context.Inventario.Include(i => i.Producto).ToList();
      return Ok(listaInventario);
      }
    }
  }
}
