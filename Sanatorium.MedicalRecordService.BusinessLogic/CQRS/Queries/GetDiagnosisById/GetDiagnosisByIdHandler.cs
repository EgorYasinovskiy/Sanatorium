using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetDiagnosisById
{
	public class GetDiagnosisByIdHandler : RequestHandlerBase, IRequestHandler<GetDiagnosisById, DiagnosisDTO>
	{
		public GetDiagnosisByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<DiagnosisDTO> Handle(GetDiagnosisById request, CancellationToken cancellationToken)
		{
			var res = _diagnosisRepository.GetById(request.Id, cancellationToken);
			return _mapper.Map<DiagnosisDTO>(res);
		}
	}
}
