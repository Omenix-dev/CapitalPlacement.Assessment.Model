using CapitalPlacement.Assessment.API.Extension;
using Serilog;

try 
{ 
    var builder = WebApplication.CreateBuilder(args);
    var config = builder.Configuration;
    // Add services to the container.
    Log.Logger = AddLogger.SerilogRegister(config);
    Log.Logger.Information("the server has started well");

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDataStoreConfiguration(config);

    var app = builder.Build();

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

}
catch (Exception ex)
{
    Log.Logger.Fatal(ex.StackTrace, "the application has failed to startup well");
    Log.CloseAndFlush();
}
