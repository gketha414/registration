using PreRegistration.Models.ViewModels;

namespace PreRegistration.Models.UI
{
    public class PatientModel : IViewModel
    {
        public PatientModel()
        {
          //  PatientDemographicsModel = new PatientDemographicsModel();
        }

        public string UserGroup { get; set; }
        public PatientDemographicsModel PatientDemographicsModel { get; set; }
        public SpouseInformationModel SpouseInformationModel { get; set; }
        public MinorInformationModel MinorInformationModel { get; set; }
        public EmergencyContactModel EmergencyContactModel { get; set; }
        public InsuranceInformationModel InsuranceInformationModel { get; set; }
        public AccidentDetailModel AccidentDetailModel { get; set; }
    }
}
