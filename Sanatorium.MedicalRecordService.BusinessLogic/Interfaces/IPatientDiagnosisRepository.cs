using Sanatorium.Common;
using Sanatorium.MedicalRecordService.Model;

namespace Sanatorium.MedicalRecordService.BusinessLogic.Interfaces
{
	public interface IPatientDiagnosisRepository : IRepositoryBase<PatientDaignosis>
	{
		public Task<IEnumerable<PatientDaignosis>> GetByPatientId(Guid patientId, CancellationToken cancellationToken);
	}
}
