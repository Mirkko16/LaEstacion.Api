using LaEstacion.Data;
using LaEstacion.AutoMapper;
using LaEstacion.Repository.Clientes;
using LaEstacion.Repository.Proveedores;
using LaEstacion.Repository.Productos;
using Microsoft.EntityFrameworkCore;
using LaEstacion.Repository.Marcas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(CustomProfile));

builder.Services.AddScoped<IClienteRepository, ClientesRepository>();
builder.Services.AddScoped<IProveedorRepository, ProveedoresRepository>();
builder.Services.AddScoped<IProductoRepository, ProductosRepository>();
builder.Services.AddScoped<IMarcaRepository, MarcasRepository>();



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
