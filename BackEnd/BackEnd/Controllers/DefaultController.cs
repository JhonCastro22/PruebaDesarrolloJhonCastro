using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DefaultController : Controller
  {
    [HttpGet]
    public string Get()
    {
      return "Aplicacion Corriendo";
    }
  }
}
