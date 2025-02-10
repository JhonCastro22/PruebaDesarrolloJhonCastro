using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("JwtSettings");

// Verificar que SecretKey no sea nula
var secretKey = jwtSettings["SecretKey"];
if (string.IsNullOrEmpty(secretKey))
{
  throw new InvalidOperationException("JWT SecretKey is missing in configuration.");
}

var keyBytes = Encoding.UTF8.GetBytes(secretKey);

// 1️⃣ Agregar servicios
builder.Services.AddControllers();
builder.Services.AddCors(options => options.AddPolicy("AllowAll",
    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
      };
    });

// 2️⃣ Agregar autorización
builder.Services.AddAuthorization();

var app = builder.Build();

// 3️⃣ Configurar middleware
if (app.Environment.IsDevelopment())
{
  app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection(); // Mejora de seguridad
app.UseCors("AllowAll");
app.UseAuthentication(); // 🔹 Primero autenticación
app.UseAuthorization();  // 🔹 Luego autorización

app.MapControllers(); // 🔹 Solo esto, elimina app.UseEndpoints()

app.Run();
