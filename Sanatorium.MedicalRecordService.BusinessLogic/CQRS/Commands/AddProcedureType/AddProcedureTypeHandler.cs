using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddProcedureType
{
	public class AddProcedureTypeHandler : RequestHandlerBase, IRequestHandler<AddProcedureType, ProcedureTypeDTO>
	{
		public AddProcedureTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureTypeDTO> Handle(AddProcedureType request, CancellationToken cancellationToken)
		{
			var type = new ProcedureType()
			{
				Id = Guid.NewGuid(),
				Name = request.CreateProcedureTypeDTO.Name,
				Price = request.CreateProcedureTypeDTO.Price
			};
			await _procedureTypeRepository.Create(type, cancellationToken);
			await _procedureTypeRepository.SaveChanges(cancellationToken);

			return _mapper.Map<ProcedureTypeDTO>(type);
		}
	}
}
