using System.Text.Json;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.Api.ConnectionChannels
{
	public class StaffServiceChannel : IStaffServiceChannel
	{
		private readonly IHttpClientFactory _httpFactory;
		private string _connectionString { get; set; }

		public StaffServiceChannel(IHttpClientFactory httpFactory, string connectionString)
		{
			httpFactory = httpFactory;
			_connectionString = connectionString;
		}

		public async Task<InvoiceDTO> GetStaffInvoice(Guid staffId, DateOnly dateFrom, CancellationToken cancellationToken)
		{
			var client = _httpFactory.CreateClient();
			client.BaseAddress = new Uri(_connectionString);
			var response = await client.GetAsync($"/api/report/invoice/{staffId}/{dateFrom}", cancellationToken);
			if (response.StatusCode == System.Net.HttpStatusCode.OK)
			{
				var data = await response.Content.ReadAsStringAsync(cancellationToken);
				var invoice = JsonSerializer.Deserialize<InvoiceDTO>(data);
				if (invoice != null)
					return invoice;
			}
			return null;
		}
	}
}
