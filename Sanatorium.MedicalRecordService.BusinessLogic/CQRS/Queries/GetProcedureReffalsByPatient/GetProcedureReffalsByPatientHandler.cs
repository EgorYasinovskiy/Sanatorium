using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureReffalsByPatient
{
	public class GetProcedureReffalsByPatientHandler : RequestHandlerBase, IRequestHandler<GetProcedureReffalsByPatient, ProcedureReffalsListDTO>
	{
		public GetProcedureReffalsByPatientHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureReffalsListDTO> Handle(GetProcedureReffalsByPatient request, CancellationToken cancellationToken)
		{
			var reffals = await _procedureRepository.GetReffalsByPatient(request.PatientId, request.Start, request.End, cancellationToken);
			var result = new ProcedureReffalsListDTO()
			{
				ProcedureReffals = _mapper.Map<IEnumerable<ProcedureReffalDTO>>(reffals)
			};
			return result;
		}
	}
}
