using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestReffal
{
	public class UpdateTestReffalHandler : RequestHandlerBase, IRequestHandler<UpdateTestReffal>
	{
		public UpdateTestReffalHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(UpdateTestReffal request, CancellationToken cancellationToken)
		{
			var test = await _testRepository.GetById(request.UpdateTestReffalDTO.Id,cancellationToken);
			if (test != null)
			{
				test.TestResultId = request.UpdateTestReffalDTO.TestResultId;
				test.TestTypeId = request.UpdateTestReffalDTO.TestTypeId;
				test.DateTime =	request.UpdateTestReffalDTO.DateTime;
				test.PatientId = request.UpdateTestReffalDTO.PatientId;

				await _testRepository.Update(test,cancellationToken);
				await _testRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
