using LaEstacion.Data;
using LaEstacion.AutoMapper;
using LaEstacion.Repository.Clientes;
using LaEstacion.Repository.Proveedores;
using LaEstacion.Repository.Productos;
using Microsoft.EntityFrameworkCore;
using LaEstacion.Repository.Marcas;
using LaEstacion.Repository.Familias;
using LaEstacion.Repository.Rubros;
using LaEstacion.Repository.Unidades;
using LaEstacion.Repository.Ventas;
using Hangfire;
using Microsoft.Extensions.Hosting;
using LaEstacion.Repository.Users;
using LaEstacion.Repository.Usuarios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(CustomProfile));

builder.Services.AddScoped<IClienteRepository, ClientesRepository>();
builder.Services.AddScoped<IProductoRepository, ProductosRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedoresRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcasRepository>();
builder.Services.AddScoped<IFamiliaRepository, FamiliasRepository>();
builder.Services.AddScoped<IRubroRepository, RubrosRepository>();
builder.Services.AddScoped<IUnidadRepository, UnidadesRepository>();
builder.Services.AddScoped<IProductoVendidoRepository, ProductosVendidosRepository>();
builder.Services.AddScoped<IVentaRepository, VentasRepository>();
builder.Services.AddScoped<IUserRepository, UsersRepository>();



var sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.UseSqlServer(sqlConnectionString);
});

var app = builder.Build();
app.UseCors(policy => policy.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                            .WithOrigins("http://localhost:5173"));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();