using System.Text.Json;

using Sanatorium.Common.DTO;
using Sanatorium.InvoiceService.BusinessLogic.Interfaces;

namespace Sanatorium.InvoiceService.Api.ConnectionChannels
{
	public class InventoryServiceChannel : IInventoryServiceChannel
	{
		private readonly IHttpClientFactory _httpFactory;
		private string _connectionString { get; set; }

		public InventoryServiceChannel(IHttpClientFactory httpFactory, string connectionString)
		{
			_httpFactory = httpFactory;
			_connectionString = connectionString;
		}
		public async Task<InvoiceDTO> GetInvoice(CancellationToken cancellationToken)
		{
			var client = _httpFactory.CreateClient();
			client.BaseAddress = new Uri(_connectionString);
			HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "/api/report/invoice");
			message.Content = new StringContent("", System.Text.Encoding.UTF8, "application/json");
			var response = await client.SendAsync(message);//await client.GetAsync("/api/report/invoice",cancellationToken);
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
