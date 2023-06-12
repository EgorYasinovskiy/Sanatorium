using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.Api.ConnectionChannels
{
	public static class ConnectionChannelExtensions
	{
		public static void AddInventoryServiceChannel(this IServiceCollection services, string serviceUrl)
		{
			services.AddScoped<IInventoryServiceChannel, InventoryServiceChannel>(provider =>
			{
				var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
				return new InventoryServiceChannel(clientFactory, serviceUrl);
			});
		}
		public static void AddMedicalServiceChannel(this IServiceCollection services, string serviceUrl)
		{
			services.AddScoped<IMedicalRecordServiceChannel, MedicalRecordServiceChannel>(provider =>
			{
				var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
				return new MedicalRecordServiceChannel(clientFactory, serviceUrl);
			});
		}
		public static void AddStaffServiceChannel(this IServiceCollection services, string serviceUrl)
		{
			services.AddScoped<IStaffServiceChannel, StaffServiceChannel>(provider =>
			{
				var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
				return new StaffServiceChannel(clientFactory, serviceUrl);
			});
		}
		public static void AddRoomServiceChannel(this IServiceCollection services, string serviceUrl)
		{
			services.AddScoped<IRoomServiceChannel, RoomServiceChannel>(provider =>
			{
				var clientFactory = provider.GetRequiredService<IHttpClientFactory>();
				return new RoomServiceChannel(clientFactory, serviceUrl);
			});
		}
	}
}
