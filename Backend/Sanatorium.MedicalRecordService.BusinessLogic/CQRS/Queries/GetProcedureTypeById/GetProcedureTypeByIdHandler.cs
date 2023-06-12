using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureTypeById
{
	public class GetProcedureTypeByIdHandler : RequestHandlerBase, IRequestHandler<GetProcedureTypeById, ProcedureTypeDTO>
	{
		public GetProcedureTypeByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureTypeDTO> Handle(GetProcedureTypeById request, CancellationToken cancellationToken)
		{
			var type = await _procedureTypeRepository.GetById(request.Id, cancellationToken);
			if (type == null)
				return null;
			return _mapper.Map<ProcedureTypeDTO>(type);
		}
	}
}
