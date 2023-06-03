using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllPacientDiagnosis
{
	public class GetAllPacientDiagnosisHandler : RequestHandlerBase, IRequestHandler<GetAllPacientDiagnosis, PatientDiagnosisListDTO>
	{
		public GetAllPacientDiagnosisHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<PatientDiagnosisListDTO> Handle(GetAllPacientDiagnosis request, CancellationToken cancellationToken)
		{
			var diagnoses = await _patientDiagnosisRepository.GetByPatientId(request.PatientId,cancellationToken);
			return new PatientDiagnosisListDTO
			{
				Diagnoses = _mapper.Map<IEnumerable<PatientDiagnosisDTO>>(diagnoses)
			};
		}
	}
}
