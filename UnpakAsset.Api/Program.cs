using Serilog;
using UnpakAsset.Common.Application;
using UnpakAsset.Common.Infrastructure;
using UnpakAsset.Api.Middleware;
using UnpakAsset.Modules.Asset.Infrastructure;
using UnpakTag.Modules.Tag.Infrastructure;
using UnpakAsset.Modules.AssignAsset.Infrastructure;
using UnpakAsset.Modules.MoveAsset.Infrastructure;
using UnpakAsset.Modules.PhysicalAsset.Infrastructure;
using UnpakAsset.Modules.RepairAsset.Infrastructure;
using UnpakAsset.Modules.DisposalAsset.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
//builder.Services.AddControllers();

//builder.Configuration.AddModuleConfiguration(["Asset"]);
builder.Services.AddApplication([
    UnpakAsset.Modules.Asset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.MoveAsset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.AssignAsset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.PhysicalAsset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.RepairAsset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.DisposalAsset.Application.AssemblyReference.Assembly,
    UnpakAsset.Modules.Tag.Application.AssemblyReference.Assembly,
]);

builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("Database")!);
builder.Services.AddAssetModule(builder.Configuration);
builder.Services.AddMoveAssetModule(builder.Configuration);
builder.Services.AddAssignAssetModule(builder.Configuration);
builder.Services.AddPhysicalAssetModule(builder.Configuration);
builder.Services.AddRepairAssetModule(builder.Configuration);
builder.Services.AddDisposalAssetModule(builder.Configuration);
builder.Services.AddTagModule(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();


var app = builder.Build();
AssetModule.MapEndpoints(app);
MoveAssetModule.MapEndpoints(app);
AssignAssetModule.MapEndpoints(app);
PhysicalAssetModule.MapEndpoints(app);
RepairAssetModule.MapEndpoints(app);
DisposalAssetModule.MapEndpoints(app);
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
