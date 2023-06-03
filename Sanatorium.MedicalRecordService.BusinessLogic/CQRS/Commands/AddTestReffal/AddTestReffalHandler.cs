using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestReffal
{
	public class AddTestReffalHandler : RequestHandlerBase, IRequestHandler<AddTestReffal, TestReffalDTO>
	{
		public AddTestReffalHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestReffalDTO> Handle(AddTestReffal request, CancellationToken cancellationToken)
		{
			var reffal = new TestReffal()
			{
				Id = Guid.NewGuid(),
				DateTime = request.CreateTestReffalDTO.DateTime,
				PatientId = request.CreateTestReffalDTO.PatientId,
				TestTypeId = request.CreateTestReffalDTO.TestTypeId,
				TestType = await _testTypesRepository.GetById(request.CreateTestReffalDTO.TestTypeId, cancellationToken)
			};
			await _testRepository.Create(reffal, cancellationToken);
			await _testRepository.SaveChanges(cancellationToken);

			return _mapper.Map<TestReffalDTO>(reffal);
		}
	}
}
