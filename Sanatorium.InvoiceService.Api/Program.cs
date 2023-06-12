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
				cfg.UseNpgsql(builder.Configuration.GetConnectionString("invoiceServiceDb"));
			});
			builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

			builder.Services.AddRoomServiceChannel(builder.Configuration.GetConnectionString("roomService"));
			builder.Services.AddMedicalServiceChannel(builder.Configuration.GetConnectionString("medicalService"));
			builder.Services.AddStaffServiceChannel(builder.Configuration.GetConnectionString("staffService"));
			builder.Services.AddInventoryServiceChannel(builder.Configuration.GetConnectionString("inventoryService"));

			builder.Services.AddControllers();

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}