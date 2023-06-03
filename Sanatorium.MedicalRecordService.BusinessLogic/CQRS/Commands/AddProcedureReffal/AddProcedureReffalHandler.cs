using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddProcedureReffal
{
	public class AddProcedureReffalHandler : RequestHandlerBase, IRequestHandler<AddProcedureReffal, ProcedureReffalDTO>
	{
		public AddProcedureReffalHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<ProcedureReffalDTO> Handle(AddProcedureReffal request, CancellationToken cancellationToken)
		{
			var reffal = new ProcedureReffal()
			{
				DateTime = request.CreateProceduralReffalDTO.DateTime,
				Id = Guid.NewGuid(),
				PatientId = request.CreateProceduralReffalDTO.PatientId,
				ProcedureTypeId = request.CreateProceduralReffalDTO.ProcedureTypeId,
				ProcedureType = await _procedureTypeRepository.GetById(request.CreateProceduralReffalDTO.ProcedureTypeId,cancellationToken),
			};

			await _procedureRepository.Create(reffal, cancellationToken);
			await _procedureRepository.SaveChanges(cancellationToken);

			return _mapper.Map<ProcedureReffalDTO>(reffal);
		}
	}
}
