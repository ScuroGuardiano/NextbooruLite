using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NextbooruLite;
using NextbooruLite.Auth;
using NextbooruLite.Configuration;
using Serilog;
using NextbooruLite.Environment;
using NextbooruLite.Filters;
using NextbooruLite.Services;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Logging

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

builder.Services.AddSerilog((services, lc) => lc
    .ReadFrom.Configuration(builder.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext());
#endregion

#region Configuration
EnvironmentVariablesMapper.MapVariables(AppSettings.EnvMappings);
builder.Configuration.AddEnvironmentVariables(AppSettings.EnvPrefix);

builder.Services.AddOptions<DatabaseOptions>()
    .Bind(builder.Configuration.GetSection(DatabaseOptions.Key))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.AddOptions<NextbooruOptions>()
    .Bind(builder.Configuration.GetSection(NextbooruOptions.Key))
    .ValidateDataAnnotations()
    .ValidateOnStart();

builder.Services.Configure<PasswordHasherOptions>(opts =>
{
    // Latest PBKDF2 Iteration Count recommended by OWASP.
    opts.IterationCount = 210_000;
});

ValidatorOptions.Global.LanguageManager.Enabled = false;
#endregion

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddProblemDetails(opts =>
{
    opts.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Type =
            $"https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/{context.ProblemDetails.Status}";
    };
});

builder.Services.AddNextbooruAuthentication();
builder.Services.AddNextbooruAuthorization();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddScoped<IImageDtoMapper, ImageDtoMapper>();
builder.Services.AddScoped<IImageConvertionService, SixLaborsConvertionService>();
builder.Services.AddSingleton<IImageUrlService, ImageUrlService>();
builder.Services.AddSingleton<IMediaStore, LocalMediaStore>(); 
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IUploadService, UploadService>();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpExceptionsFilter>();
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opts =>
{
    opts.EnableAnnotations();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opts =>
    {
        opts.PreSerializeFilters.Add((swaggerDoc, _) =>
        {
            var paths = new OpenApiPaths();
            foreach (var path in swaggerDoc.Paths) 
            {
                paths.Add($"{AppConstants.ApiRoutePrefix}{path.Key}", path.Value);
            }
            
            swaggerDoc.Paths = paths;
        });
    });
    
    app.UseSwaggerUI();
}

// TODO: Add frontend serving here uwu

app.UseSerilogRequestLogging();

app.UsePathBase(AppConstants.ApiRoutePrefix);
app.Use((ctx, next) =>
{
    if (ctx.Request.PathBase == string.Empty)
    {
        ctx.Response.StatusCode = 404;
        return Task.CompletedTask;
    }

    return next(ctx);
});

app.UseStatusCodePages();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{ 
    NextbooruOptions opts = app.Services.GetRequiredService<IOptions<NextbooruOptions>>().Value;
    Log.Logger.Information("AllowedExtetions: {AllowedExtetions}", opts.AllowedUploadExtensions);
    
    app.Run();
}
catch (Exception ex)
{
    if (ex is OptionsValidationException optionsValidationException)
    {
        Log.Logger.Fatal("@@@@@@@@@ CONFIGURATION ERROR @@@@@@@@@");
        // I am intentionally not including exception message here, because I want last message seen to be Exception Message and not stack trace.
        Log.Logger.Fatal("Exception message: {Exception}", optionsValidationException.Message);
    }
    else
    {
        Log.Logger.Fatal(ex, "Some fatal exception occured during application startup, {Exception}", ex.Message);
    }

    Environment.Exit(-1);
}
