using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestReffalsByPatient
{
	public class GetTestReffalsByPatientHandler : RequestHandlerBase, IRequestHandler<GetTestReffalsByPatient, TestReffalsListDTO>
	{
		public GetTestReffalsByPatientHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestReffalsListDTO> Handle(GetTestReffalsByPatient request, CancellationToken cancellationToken)
		{
			var reffals = await _testRepository.GetByPatientId(request.PatientId, request.Start, request.End, cancellationToken);
			return new TestReffalsListDTO()
			{
				TestReffals = _mapper.Map<IEnumerable<TestReffalDTO>>(reffals)
			};
		}
	}
}
