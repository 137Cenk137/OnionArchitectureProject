using Youtube.Persistence;
using Youtube.Application;
using Youtube.Mapper;
using Youtube.Application.Exceptions;
using Youtube.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>{
    o.SwaggerDoc("v1",new OpenApiInfo{Title = "Youtube Api",Version = "v1",Description = "Youtube Api swagger client."});
    o.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme(){
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        In = ParameterLocation.Header
      ,Description = "'Bearer' yazıp bosluk bırakıldıktan sonra Token ı girebilirsiniz \r\n\r\n Örneğin \"Bearer kfnlkngqlkgqerggknqergepr34kn\" "
    });
    o.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme (){
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
var env = builder.Environment;


builder.Configuration.SetBasePath(env.ContentRootPath)
                        .AddJsonFile("appsettings.json",optional:false) 
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json",optional:true);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddInfrastructure (builder.Configuration);
builder.Services.AddCustomMapper();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandlingMiddleware();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
