using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsById
{
	public class GetTestReffalsByIdHandler : RequestHandlerBase, IRequestHandler<GetTestReffalsById, TestReffalDTO>
	{
		public GetTestReffalsByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestReffalDTO> Handle(GetTestReffalsById request, CancellationToken cancellationToken)
		{
			var reffal = await _testRepository.GetById(request.Id, cancellationToken);
			return reffal == null ? null : _mapper.Map<TestReffalDTO>(reffal);
		}
	}
}
