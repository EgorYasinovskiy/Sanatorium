using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using Sanatorium.Common.Mappings;
using Sanatorium.RoomService.Api.Repositories;
using Sanatorium.RoomService.BusinessLogic.Interfaces;

namespace Sanatorium.RoomService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<IRoomServiceDbContext, RoomServiceDbContext>(opt =>
			{
				opt.UseNpgsql(builder.Configuration.GetConnectionString("RoomServiceDB"));
			});
			builder.Services.AddScoped<IRoomRepository, RoomRepository>();
			builder.Services.AddScoped<IBookingRepository, BookingRepository>();
			builder.Services.AddScoped<IRoomMoveRepository, RoomMoveRepository>();
			builder.Services.AddAutoMapper(cfg =>
			{
				cfg.AddProfile(new AssemblyMappingsProfile(typeof(IRoomServiceDbContext).Assembly));
			});
			builder.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(typeof(IRoomServiceDbContext).Assembly);
			});
			builder.Services.AddControllers();

			builder.Services.AddDateOnlyTimeOnlyStringConverters();
			builder.Services.AddSwaggerGen(cfg =>
			{
				cfg.MapType<DateOnly>(() => new OpenApiSchema { Type = "string", Format = "date" });
				cfg.MapType<DateOnly?>(() => new OpenApiSchema { Type = "string", Format = "date" });
				cfg.SwaggerDoc("v1", new OpenApiInfo() { Title = "RoomServiceApi", Version = "v1" });
				cfg.UseDateOnlyTimeOnlyStringConverters();
			});
			builder.Services.AddOpenApiDocument();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseSwagger(o => o.DocumentName = "RoomServiceApi");
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "RoomServiceApi V1");
			});

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}