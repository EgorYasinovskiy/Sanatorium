using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateProcedureReffal
{
	public class UpdateProcedureReffalHandler : RequestHandlerBase, IRequestHandler<UpdateProcedureReffal>
	{
		public UpdateProcedureReffalHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(UpdateProcedureReffal request, CancellationToken cancellationToken)
		{
			var reffal = await _procedureRepository.GetById(request.Update.Id, cancellationToken);
			if (reffal != null)
			{
				reffal.ProcedureTypeId = request.Update.ProcedureTypeId;
				reffal.DateTime = request.Update.DateTime;
				reffal.PatientId = request.Update.PatientId;

				await _procedureRepository.Update(reffal,cancellationToken);
				await _procedureRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
