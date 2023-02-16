using System.Reflection;
using System.Text;
using CBD.ShoppingService.Core.Models;
using CBD.ShoppingService.Core.Options;
using CBD.ShoppingService.Core.Services;
using CBD.ShoppingService.Port.Contexts;
using CBD.ShoppingService.Port.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace CBD.ShoppingService.WebAPI;

public static class Program {
	public static async Task Main(string[] args) {
		var builder = WebApplication.CreateBuilder(args);
		Program.ConfigureServices(builder);
		var app = builder.Build();
		Program.ConfigurePipeline(app);

		using (var scope = app.Services.CreateScope()) {
			var context = scope.ServiceProvider.GetRequiredService<ShoppingContext>();
			await context.Database.EnsureCreatedAsync();
		}
		await app.RunAsync();
	}

	private static void ConfigureServices(WebApplicationBuilder builder) {
		builder.Configuration.AddEnvironmentVariables();

		Program.ConfigureOptions(builder, out var jwtIssuingOptions);
		Program.ConfigureControllers(builder);
		Program.ConfigureScopedServices(builder);
		Program.ConfigureEntityFramework(builder);
		Program.ConfigureJwtAuthentication(builder, jwtIssuingOptions);
		
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(swaggerOptions => {
				swaggerOptions.SwaggerDoc("v1", new OpenApiInfo {
					Title = "ShoppingService",
					Version = "v1",
					Description =
						"ShoppingService for CBD",
					Contact = new OpenApiContact {
						Name = "Dustin Eikmeier",
						Email = "s0569494@htw-berlin.de",
						Url = new Uri("https://github.com/orgs/ConcupiscenceBusinessDepartmentstore/CBD.ShoppingService")
					}
				});
				swaggerOptions.CustomSchemaIds(type => type.FullName);
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				swaggerOptions.IncludeXmlComments(xmlPath);
			}
			);
	}

	private static void ConfigureControllers(WebApplicationBuilder builder) {
		builder.Services.AddControllers();
	}
	
	private static void ConfigureScopedServices(WebApplicationBuilder builder) {
		builder.Services.AddScoped<IJwtIssuingService, JwtIssuingService>();
		builder.Services.AddScoped<IEmailService, EmailService>();
		builder.Services.AddScoped<IIdentityService, IdentityService>();
		builder.Services.AddScoped<IProductService, ProductService>();
	}

	private static void ConfigureEntityFramework(WebApplicationBuilder builder) {
		builder.Services.AddDbContext<ShoppingContext>(
			(serviceProvider, optionsBuilder) => optionsBuilder
				.UseNpgsql(
					builder.Configuration.GetConnectionString("postgres")
						.Replace("$POSTGRES_USER", Environment.GetEnvironmentVariable("POSTGRES_USER"))
						.Replace("$POSTGRES_PASSWORD", Environment.GetEnvironmentVariable("POSTGRES_PASSWORD"))
						.Replace("$POSTGRES_DB", Environment.GetEnvironmentVariable("POSTGRES_DB")),
					optionsBuilder => {
						optionsBuilder.MigrationsAssembly(typeof(Program).Assembly.GetName().Name);
					})
		);
	}

	private static void ConfigureJwtAuthentication(WebApplicationBuilder builder, JwtIssuingOptions jwtIssuingOptions) {
		builder.Services.AddAuthentication(
			options => {
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}
		).AddJwtBearer(
			options => {
				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters {
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtIssuingOptions.Secret)),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true
				};
			}
		);
	}
	
	private static void ConfigureOptions(WebApplicationBuilder builder, out JwtIssuingOptions jwtIssuingOptions) {
		builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
		jwtIssuingOptions = new JwtIssuingOptions();
		builder.Configuration.Bind(JwtIssuingOptions.AppSettingsKey, jwtIssuingOptions);
		builder.Services.Configure<JwtIssuingOptions>(builder.Configuration.GetSection(JwtIssuingOptions.AppSettingsKey));
		builder.Services.Configure<EmailHostOptions>(builder.Configuration.GetSection(EmailHostOptions.AppSettingsKey));
	}

	private static void ConfigurePipeline(WebApplication app) {
		if (app.Environment.IsDevelopment()) {
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

		app.UseAuthentication();
		app.UseAuthorization();

		app.MapControllers();
	}
}