using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  public class ProductoController : ControllerBase
  {
    [Route("api/Productos/Detalle")]
    [HttpPut]
    [Authorize]
    // GET: ProductoController/Details/5
    public async Task<IActionResult> Details([FromBody] Productos productos)
    {
      using (BackEndContext context = new BackEndContext())
      {
        var producto = context.Productos.Where(prod => prod.Id == productos.Id).FirstOrDefault();
        return Ok(producto);
      }
    }
    [Route("api/Productos/Crear")]
    [HttpPost]
    [Authorize]
    // GET: ProductoController/Create
    public async Task<IActionResult> Create([FromBody]Productos productos)
    {
      using (BackEndContext context = new BackEndContext())
      {
        var listaProductos=context.Productos.ToList();
        var ultimoId = listaProductos.Last().Id;
        productos.Id = ultimoId + 1;
        context.Productos.Add(productos);
        context.SaveChanges();
        return Ok();
      }
    }

    // POST: ProductoController/Create
    [Route("api/Productos/Listar")]
    [HttpGet]
    [Authorize]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> List()
    {
      try
      {
        using (BackEndContext context = new BackEndContext())
        {
          var listaProductos = context.Productos.ToList();
          return Ok(listaProductos);
        }
      }
      catch
      {
        return BadRequest();
      }
    }
    [Route("api/Productos/Editar")]
    [HttpPost]
    // GET: ProductoController/Edit/5
    public async Task<IActionResult> Edit([FromBody] Productos productos)
    {
      using (BackEndContext context = new BackEndContext())
      {
        var producto = context.Productos.Where(prod => prod.Id == productos.Id).FirstOrDefault();
        if (producto != null)
        {
          producto.Nombre = productos.Nombre;
          producto.FechaModificacion = DateTime.Now;
          producto.Descripcion = productos.Descripcion;
          context.SaveChanges();
          return Ok();
        }
        else {
          return BadRequest("Producto no encontrado");
        }
      }
    }
  }
}
