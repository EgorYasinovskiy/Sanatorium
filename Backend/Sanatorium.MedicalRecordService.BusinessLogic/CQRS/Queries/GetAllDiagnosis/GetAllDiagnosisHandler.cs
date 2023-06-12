using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllDiagnosis
{
	public class GetAllDiagnosisHandler : RequestHandlerBase, IRequestHandler<GetAllDiagnosis, DiagnosisListDTO>
	{
		public GetAllDiagnosisHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<DiagnosisListDTO> Handle(GetAllDiagnosis request, CancellationToken cancellationToken)
		{
			var diagnosis = await _diagnosisRepository.GetAll(cancellationToken);
			var result = new DiagnosisListDTO()
			{
				Diagnoses = _mapper.Map<IEnumerable<DiagnosisDTO>>(diagnosis)
			};

			return result;
		}
	}
}
