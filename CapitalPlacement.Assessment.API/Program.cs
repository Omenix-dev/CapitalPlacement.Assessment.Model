using CapitalPlacement.Assessment.API.Extension;
using CapitalPlacement.Assessment.DataAccess.Repository;
using Serilog;

try 
{ 
    var builder = WebApplication.CreateBuilder(args);
    var config = builder.Configuration;
    // Add services to the container.
    Log.Logger = AddLogger.SerilogRegister(config);
    Log.Logger.Information("the server has started well");

    builder.Services.AddSingleton(Log.Logger);
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.RegisterServices();
    builder.Services.AddDataStoreConfiguration(config);

    var app = builder.Build();
    // comment this part out if you have already the created 
    // docume and database matching the settings in the appsettings
    await DatabaseInitializer.Initialize(app, config);
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
