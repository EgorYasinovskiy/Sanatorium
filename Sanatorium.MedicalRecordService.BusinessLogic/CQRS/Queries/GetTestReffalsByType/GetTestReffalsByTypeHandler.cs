using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsByType
{
	public class GetTestReffalsByTypeHandler : RequestHandlerBase, IRequestHandler<GetTestReffalsByType, TestReffalsListDTO>
	{
		public GetTestReffalsByTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestReffalsListDTO> Handle(GetTestReffalsByType request, CancellationToken cancellationToken)
		{
			var reffals = await _testRepository.GetByTypeId(request.TypeId, request.Start, request.End, cancellationToken);

			return new TestReffalsListDTO()
			{
				TestReffals = _mapper.Map<IEnumerable<TestReffalDTO>>(reffals)
			};
		}
	}
}
