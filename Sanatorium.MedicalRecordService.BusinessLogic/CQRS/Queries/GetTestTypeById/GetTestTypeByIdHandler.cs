using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Queries.GetTestTypeById
{
	internal class GetTestTypeByIdHandler : RequestHandlerBase, IRequestHandler<GetTestTypeById, TestTypeDTO>
	{
		public GetTestTypeByIdHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<TestTypeDTO> Handle(GetTestTypeById request, CancellationToken cancellationToken)
		{
			var res = await _testTypesRepository.GetById(request.Id, cancellationToken);
			return res == null ? null : _mapper.Map<TestTypeDTO>(res);
		}
	}
}
