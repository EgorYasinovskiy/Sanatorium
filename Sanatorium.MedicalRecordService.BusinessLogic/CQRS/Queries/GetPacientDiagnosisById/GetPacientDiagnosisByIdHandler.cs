using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetPacientDiagnosisById
{
	public class GetPacientDiagnosisByIdHandler : RequestHandlerBase, IRequestHandler<GetPacientDiagnosisById, PatientDiagnosisDTO>
	{
		public GetPacientDiagnosisByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<PatientDiagnosisDTO> Handle(GetPacientDiagnosisById request, CancellationToken cancellationToken)
		{
			var res = await _patientDiagnosisRepository.GetById(request.Id, cancellationToken);
			return _mapper.Map<PatientDiagnosisDTO>(res);
		}
	}
}
