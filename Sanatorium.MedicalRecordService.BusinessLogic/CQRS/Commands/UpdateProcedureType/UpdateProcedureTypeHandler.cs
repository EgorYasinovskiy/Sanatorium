using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.UpdateProcedureType
{
	public class UpdateProcedureTypeHandler : RequestHandlerBase, IRequestHandler<UpdateProcedureType>
	{
		public UpdateProcedureTypeHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task Handle(UpdateProcedureType request, CancellationToken cancellationToken)
		{
			var ptype = await _procedureTypeRepository.GetById(request.Update.Id, cancellationToken);
			if (ptype != null)
			{
				ptype.Price = request.Update.Price;
				ptype.Name = request.Update.Name;

				await _procedureTypeRepository.Update(ptype, cancellationToken);
				await _procedureTypeRepository.SaveChanges(cancellationToken);
			}
		}
	}
}
