using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.DeleteTestType
{
	public class DeleteTestTypeHandler : RequestHandlerBase, IRequestHandler<DeleteTestType>
	{
		public DeleteTestTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(DeleteTestType request, CancellationToken cancellationToken)
		{
			await _testTypesRepository.DeleteById(request.Id, cancellationToken);
			await _testTypesRepository.SaveChanges(cancellationToken);
		}
	}
}
