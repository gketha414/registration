using PreRegistration.Models.Helpers;
using PreRegistration.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PreRegistration.Models.ViewModels;
using PreRegistration.Models.UI;

namespace RespiratoryProtectionProgram.BL
{
    public class PreRegistrationBL
    {
        private readonly PreRegistrationDAL _preRegistrationDAL;
        Logger log = new Logger();

        public PreRegistrationBL()
        {
            _preRegistrationDAL = new PreRegistrationDAL();
        }

        public string GetADGroup(string userId)
        {
            SearchADGroups searchAdGroups = new SearchADGroups();
            return searchAdGroups.SearchAD(userId);
        }

        public async Task<PatientViewModel> GetPatientModel()
        {
            return await _preRegistrationDAL.GetPatientModel();
        }

        public async Task<bool> SubmitPreRegistrationForm(PatientViewModel patientViewModel)
        {
            return await _preRegistrationDAL.SubmitPreRegistrationForm(patientViewModel);
        }

        public async Task<List<PatientDemographicsViewModel>> GetPatientsByHospital(int hospitalId, int processed)
        {
            return await _preRegistrationDAL.GetPatientsByHospital(hospitalId, processed);
        }

        public async Task<PatientModel> GetPatientById(int personId)
        {
            return await _preRegistrationDAL.GetPatientById(personId);
        }
    }
}
