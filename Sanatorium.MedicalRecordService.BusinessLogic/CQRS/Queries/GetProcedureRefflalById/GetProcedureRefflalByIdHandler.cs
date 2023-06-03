using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetProcedureRefflalById
{
	public class GetProcedureRefflalByIdHandler : RequestHandlerBase, IRequestHandler<GetProcedureRefflalById, ProcedureReffalDTO>
	{
		public GetProcedureRefflalByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureReffalDTO> Handle(GetProcedureRefflalById request, CancellationToken cancellationToken)
		{
			var reffal = await _procedureRepository.GetById(request.Id, cancellationToken);
			return reffal == null ? null : _mapper.Map<ProcedureReffalDTO>(reffal);
		}
	}
} 
