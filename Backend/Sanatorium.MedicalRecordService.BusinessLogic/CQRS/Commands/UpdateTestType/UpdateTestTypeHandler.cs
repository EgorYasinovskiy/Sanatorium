using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateTestType
{
	public class UpdateTestTypeHandler : RequestHandlerBase, IRequestHandler<UpdateTestType>
	{
		public UpdateTestTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(UpdateTestType request, CancellationToken cancellationToken)
		{
			var type = await _testTypesRepository.GetById(request.UpdateTestTypeDTO.Id, cancellationToken);
			if (type != null)
			{
				type.Price = request.UpdateTestTypeDTO.Price;
				type.Name = request.UpdateTestTypeDTO.Name;

				await _testTypesRepository.Update(type, cancellationToken);
				await _testTypesRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
