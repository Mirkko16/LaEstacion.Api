using Hangfire;
using LaEstacion.Data;
using LaEstacion.Repository.Productos;
using LaEstacion.Services.Pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// ... (otros servicios)

var sqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
{
    options.UseSqlServer(sqlConnectionString);
});

builder.Services.AddHangfire(config => config.UseSqlServerStorage(sqlConnectionString));

builder.Services.AddScoped<IPdfService, PdfService>();

// Agrega tu servicio de repositorio u otros servicios necesarios
builder.Services.AddScoped<IProductoRepository, ProductosRepository>();

var app = builder.Build();

// ... (configuración CORS y otros middleware)

if (app.Environment.IsDevelopment())
{
    // ... (middleware de desarrollo)
}

// Inicia Hangfire en el inicio de la aplicación
GlobalConfiguration.Configuration.UseSqlServerStorage(sqlConnectionString);

// Configura la tarea programada para ejecutarse al inicio
BackgroundJob.Enqueue<IProductoRepository>(repo => repo.VerificarStockMinimo());

app.Run();
