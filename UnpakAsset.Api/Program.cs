using Serilog;
using UnpakAsset.Common.Application;
using UnpakAsset.Common.Infrastructure;
using UnpakAsset.Api.Extensions;
using UnpakAsset.Api.Middleware;
using UnpakAsset.Modules.Asset.Infrastructure;
using UnpakTag.Modules.Tag.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddControllers();

//builder.Configuration.AddModuleConfiguration(["Asset"]);
builder.Services.AddApplication([
    UnpakAsset.Modules.Asset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.Tag.Application.AssemblyReference.Assembly
]);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);
builder.Services.AddAssetModule(builder.Configuration);
builder.Services.AddTagModule(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();


var app = builder.Build();
AssetModule.MapEndpoints(app);
TagModule.MapEndpoints(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllers();

app.Run();
