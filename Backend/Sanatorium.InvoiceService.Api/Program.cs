using Microsoft.EntityFrameworkCore;

using Sanatorium.InvoiceService.Api.ConnectionChannels;
using Sanatorium.InvoiceService.Api.Repositories;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddHttpClient();
			builder.Services.AddDbContext<IInvoiceDbContext, InvoiceServiceDbContext>(cfg =>
			{
				cfg.UseNpgsql(builder.Configuration.GetConnectionString("InvoiceDb"));
			});
			builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

			builder.Services.AddRoomServiceChannel(builder.Configuration.GetConnectionString("roomService"));
			builder.Services.AddMedicalServiceChannel(builder.Configuration.GetConnectionString("medicalService"));
			builder.Services.AddStaffServiceChannel(builder.Configuration.GetConnectionString("staffService"));
			builder.Services.AddInventoryServiceChannel(builder.Configuration.GetConnectionString("inventoryService"));

			builder.Services.AddControllers();
			builder.Services.AddSwaggerGen(cfg =>
			{
				cfg.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "InvoiceServiceApi", Version = "v1" });
			});
			builder.Services.AddOpenApiDocument();
			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseSwagger(o=>o.DocumentName = "InvoiceServiceApi");
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvoiceServiceApi V1");
			});
			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}