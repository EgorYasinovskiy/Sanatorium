using AutoMapper;

using MediatR;

using Sanatorium.MedicalRecordService.BusinessLogic.DTO;
using Sanatorium.MedicalRecordService.BusinessLogic.Interfaces;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.CQRS.Commands.AddPatientDiagnosis
{
	public class AddPatientDiagnosisHandler : RequestHandlerBase, IRequestHandler<AddPatientDiagnosis, PatientDiagnosisDTO>
	{
		public AddPatientDiagnosisHandler(IDiagnosisRepository diagnosisRepository, IPatientDiagnosisRepository patientDiagnosisRepository, ITestReffalsRepository testRepository, ITestResultsRepository testResultsRepository, ITestTypesRepository testTypesRepository, IProcedureReffalsRepository procedureRepository, IProcedureTypeRepository procedureTypeRepository, IMapper mapper) : base(diagnosisRepository, patientDiagnosisRepository, testRepository, testResultsRepository, testTypesRepository, procedureRepository, procedureTypeRepository, mapper)
		{
		}

		public async Task<PatientDiagnosisDTO> Handle(AddPatientDiagnosis request, CancellationToken cancellationToken)
		{
			var diagnosis = new PatientDaignosis()
			{
				Date = request.CreatePatientDiagnosisDTO.Date,
				DiagnosisId = request.CreatePatientDiagnosisDTO.DiagnosisId,
				Diagnosis = await _diagnosisRepository.GetById(request.CreatePatientDiagnosisDTO.DiagnosisId,cancellationToken),
				PatientId = request.CreatePatientDiagnosisDTO.PatientId,
				Id = Guid.NewGuid()
			};
			await _patientDiagnosisRepository.Create(diagnosis, cancellationToken);
			await _patientDiagnosisRepository.SaveChanges(cancellationToken);

			return _mapper.Map<PatientDiagnosisDTO>(diagnosis);
		}
	}
}
