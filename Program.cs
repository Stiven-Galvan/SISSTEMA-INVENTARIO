// Nexo Inventario: host ASP.NET Core para la aplicación web.
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapGet("/health", () => Results.Ok(new { status = "ok", application = "Nexo Inventario" }));
app.Run();
