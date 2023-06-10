using AutoMapper;

using MediatR;

using Sanatorium.Common.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetInvoice
{
	public class GetInvoiceHandler : RequestHandlerBase, IRequestHandler<GetInvoice, InvoiceDTO>
	{
		public GetInvoiceHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<InvoiceDTO> Handle(GetInvoice request, CancellationToken cancellationToken)
		{
			var invoiceList = new List<InvoiceItemDTO>();
			var procedures = _procedureRepository.GetReffalsByPatient(request.PatientId, request.From.ToDateTime(new TimeOnly(0)), DateTime.Now, cancellationToken);
			var tests = _testRepository.GetByPatientId(request.PatientId, request.From.ToDateTime(new TimeOnly(0)), DateTime.Now, cancellationToken);
			foreach (var procedure in (await procedures).GroupBy(x => x.ProcedureTypeId))
			{
				invoiceList.Add(new InvoiceItemDTO()
				{
					Name = procedure.FirstOrDefault().ProcedureType.Name,
					Price = procedure.FirstOrDefault().ProcedureType.Price,
					Quanitity = procedure.Count()
				});
			}
			foreach (var test in (await tests).GroupBy(x => x.TestTypeId))
			{
				invoiceList.Add(new InvoiceItemDTO()
				{
					Name = test.FirstOrDefault().TestType.Name,
					Price = test.FirstOrDefault().TestType.Price,
					Quanitity = test.Count()
				});
			}
			return new InvoiceDTO() { Items = invoiceList };
		}
	}
}
