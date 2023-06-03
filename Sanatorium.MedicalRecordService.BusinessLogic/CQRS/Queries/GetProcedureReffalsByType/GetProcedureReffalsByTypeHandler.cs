using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureReffalsByType
{
	public class GetProcedureReffalsByTypeHandler : RequestHandlerBase, IRequestHandler<GetProcedureReffalsByType, ProcedureReffalsListDTO>
	{
		public GetProcedureReffalsByTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureReffalsListDTO> Handle(GetProcedureReffalsByType request, CancellationToken cancellationToken)
		{
			var reffals = await _procedureRepository.GetReffalsByType(request.ProcedureTypeId, request.Start, request.End, cancellationToken);
			return new ProcedureReffalsListDTO()
			{
				ProcedureReffals = _mapper.Map<IEnumerable<ProcedureReffalDTO>>(reffals)
			};
		}
	}
}
