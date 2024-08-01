using System.Collections.Generic;
using System.Web.Mvc;

namespace PreRegistration.Models.ViewModels
{
    public class PatientViewModel : IViewModel
    {
        public PatientViewModel()
        {
            Hospitals = new List<SelectListItem>();
            States = new List<SelectListItem>();
            Race = new List<SelectListItem>();
            MaritalStatus = new List<SelectListItem>();
            PatientDemographicsViewModel = new PatientDemographicsViewModel();
            YesNo = new List<string>();
            HospitalService = new List<string>();
            Gender = new List<string>();
            Guarantors = new List<SelectListItem>();
            SpouseInformation = new SpouseInformationViewModel();
            MinorInformation = new MinorInformationViewModel();
            EmergencyContact = new EmergencyContactViewModel();
            InsuranceInformation = new InsuranceInformationViewModel();
            AccidentDetail = new AccidentDetailViewModel();
            AccidentTypes = new List<string>();
        }
        public PatientDemographicsViewModel PatientDemographicsViewModel { get; set; }
        public string UserGroup { get; set; }
        public List<SelectListItem> Hospitals { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Race { get; set; }
        public List<SelectListItem> MaritalStatus { get; set; }
        public List<string> YesNo { get; set; }
        public List<string> HospitalService { get; set; }
        public List<string> Gender { get; set; }
        public List<SelectListItem> Guarantors { get; set; }
        public List<string> AccidentTypes { get; set; }

        public SpouseInformationViewModel SpouseInformation { get; set; }
        public MinorInformationViewModel MinorInformation { get; set; }
        public EmergencyContactViewModel EmergencyContact { get; set; }
        public InsuranceInformationViewModel InsuranceInformation { get; set; }
        public AccidentDetailViewModel AccidentDetail { get; set; }
    }
}
