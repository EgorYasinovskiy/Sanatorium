using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddTestType
{
	public class AddTestTypeHandler : RequestHandlerBase, IRequestHandler<AddTestType, TestTypeDTO>
	{
		public AddTestTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestTypeDTO> Handle(AddTestType request, CancellationToken cancellationToken)
		{
			var type = new TestType()
			{
				Id = Guid.NewGuid(),
				Name = request.CreateTestType.Name,
				Price = request.CreateTestType.Price
			};

			await _testTypesRepository.Create(type, cancellationToken);
			await _testTypesRepository.SaveChanges(cancellationToken);

			return _mapper.Map<TestTypeDTO>(type);
		}
	}
}
