using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackEnd.Controllers
{
  public class UsuarioController : ControllerBase
  {
    private readonly IConfiguration _config;
    public UsuarioController(IConfiguration config) {
      _config = config;
    }
    [Route("api/Login")]
    [HttpPost()]
    public IActionResult Login([FromBody] Usuarios model)
    {
      using (BackEndContext context= new BackEndContext()) {
        var usuario = context.Usuarios.Where(u => u.Nombre==model.Nombre).FirstOrDefault();
      if (model.Nombre == usuario.Nombre && model.Password == usuario.Password) // Simulación
      {
        var jwtSettings = _config.GetSection("JwtSettings");
        var secretKey = Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]);

        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, model.Nombre),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256)
        );

        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
      }

      return Unauthorized();
    }
      }
  }
}
