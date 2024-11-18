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

        //public async Task<bool> SubmitPreRegistrationForm(PatientViewModel patientViewModel)
        //{
        //    return await _preRegistrationDAL.SubmitPreRegistrationForm(patientViewModel);
        //}

        public async Task<int> submitPatient(PatientViewModel patientViewModel,int updateId)
        {
            return await _preRegistrationDAL.SubmitPatientDetail(patientViewModel, updateId);
        }
        public async Task<int> submitSpouse(SpouseInformationViewModel patientViewModel,int updateId)
        {
            return await _preRegistrationDAL.SubmitSpouseInfo(patientViewModel, updateId);
        }
        public async Task<Dictionary<string, int>> submitMinor(MinorInformationViewModel patientViewModel,int fatherId, int motherId)
        {
            return await _preRegistrationDAL.SubmitMinorInfo(patientViewModel, fatherId, motherId);
        }
        public async Task<Dictionary<string, int>> submitEmergency(EmergencyContactViewModel patientViewModel, int emergencyContactOneId,
         int emergencyContactTwoId,
         int emergencyContactThreeId)
        {
            return await _preRegistrationDAL.SubmitEmergencyContact(patientViewModel,emergencyContactOneId,emergencyContactTwoId,emergencyContactThreeId);
        }
        public async Task<Dictionary<string, int>> submitInsurance(InsuranceMultipleViewModel patientViewModel, int insuranceid1, int insuranceid2, int insuranceid3)
        {
            return await _preRegistrationDAL.SubmitInsuranceInfo(patientViewModel,insuranceid1,insuranceid2,insuranceid3);
        }
        public async Task<int> submitAccident(AccidentDetailViewModel patientViewModel,int updateId)
        {
            return await _preRegistrationDAL.SubmitAccidentDetail(patientViewModel, updateId);
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
