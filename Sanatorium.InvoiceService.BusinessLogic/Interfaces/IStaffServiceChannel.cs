using Sanatorium.Common.DTO;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IStaffServiceChannel
	{
		public Task<InvoiceDTO> GetStaffInvoice(Guid staffId, DateOnly dateFrom, CancellationToken cancellationToken);
	}
}
