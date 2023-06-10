using Sanatorium.Common;
using Sanatorium.InvoiceService.Model;

namespace Sanatorium.InvoiceService.BusinessLogic.Interfaces
{
	public interface IInvoiceRepository : IRepositoryBase<Invoice>
	{
		public Task<Invoice> GetInfoiceByPatientIdAndDate(Guid patientId, DateOnly from, CancellationToken cancellationToken);
	}
}
