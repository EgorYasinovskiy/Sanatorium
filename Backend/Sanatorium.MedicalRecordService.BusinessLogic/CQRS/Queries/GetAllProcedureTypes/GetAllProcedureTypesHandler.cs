using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetAllProcedureTypes
{
	public class GetAllProcedureTypesHandler : RequestHandlerBase, IRequestHandler<GetAllProcedureTypes, ProcedureTypesListDTO>
	{
		public GetAllProcedureTypesHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureTypesListDTO> Handle(GetAllProcedureTypes request, CancellationToken cancellationToken)
		{
			var types = await _procedureTypeRepository.GetAll(cancellationToken);
			var result = new ProcedureTypesListDTO()
			{
				ProcedureTypes = _mapper.Map<IEnumerable<ProcedureTypeDTO>>(types)
			};
			return result;
		}
	}
}