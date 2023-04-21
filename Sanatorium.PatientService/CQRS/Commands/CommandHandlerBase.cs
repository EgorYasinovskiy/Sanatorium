using MediatR;

namespace Sanatorium.PatientService.CQRS.Commands
{
	public class CommandHandlerBase
	{

		protected IPatientRepository _patientRepository;

		public CommandHandlerBase(IPatientRepository patientRepository)
		{
			_patientRepository = patientRepository;
		}
	}
}
