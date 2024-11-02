using PreRegistration.DAL;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreRegistration.BL
{
    public class AdminBL
    {
        private AdminDAL _adminDAL;
        private Logger _log = new Logger();

        public AdminBL()
        {
            _adminDAL = new AdminDAL();
        }

        public async Task<List<AccidentTypeViewModel>> GetAllAccidentTypes()
        {
            return await _adminDAL.GetAllAccidentTypes();
        }

        public async Task<bool> CreateAccidentType(AccidentTypeViewModel model)
        {
            return await _adminDAL.CreateAccidentType(model);
        }

        public async Task<bool> UpdateAccidentType(int id, string description, bool active)
        {
            return await _adminDAL.UpdateAccidentType(id, description, active);
        }

        public async Task<List<HospitalViewModel>> GetAllHospitals()
        {
            return await _adminDAL.GetAllHospitals();
        }

        public async Task<bool> CreateHospital(HospitalViewModel model)
        {
            return await _adminDAL.CreateHospital(model);
        }

        public async Task<bool> UpdateHospital(int id, string hospitalName, bool active)
        {
            return await _adminDAL.UpdateHospital(id, hospitalName, active);
        }

        public async Task<List<ResponsiblePartyViewModel>> GetAllResponsibleParties()
        {
            return await _adminDAL.GetAllResponsibleParties();
        }

        public async Task<bool> CreateResponsibleParty(ResponsiblePartyViewModel model)
        {
            return await _adminDAL.CreateResponsibleParty(model);
        }

        public async Task<bool> UpdateResponsibleParty(int id, string responsiblePartyDescription, bool active)
        {
            return await _adminDAL.UpdateResponsibleParty(id, responsiblePartyDescription, active);
        }

        public async Task<List<StateViewModel>> GetAllStates()
        {
            return await _adminDAL.GetAllStates();
        }

        public async Task<bool> CreateState(StateViewModel model)
        {
            return await _adminDAL.CreateState(model);
        }

        public async Task<bool> UpdateState(string id, string stateName, bool active)
        {
            return await _adminDAL.UpdateState(id, stateName, active);
        }

        public async Task<List<EthnicityViewModel>> GetAllEthnicities()
        {
            return await _adminDAL.GetAllEthnicities();
        }

        public async Task<bool> CreateEthnicity(EthnicityViewModel model)
        {
            return await _adminDAL.CreateEthnicity(model);
        }

        public async Task<bool> UpdateEthnicity(int id, string description, bool active)
        {
            return await _adminDAL.UpdateEthnicity(id, description, active);
        }

        public async Task<List<GenderViewModel>> GetAllGenders()
        {
            return await _adminDAL.GetAllGenders();
        }

        public async Task<bool> CreateGender(GenderViewModel model)
        {
            return await _adminDAL.CreateGender(model);
        }

        public async Task<bool> UpdateGender(int id, string name, bool active)
        {
            return await _adminDAL.UpdateGender(id, name, active);
        }

        public async Task<List<RaceViewModel>> GetAllRaces()
        {
            return await _adminDAL.GetAllRaces();
        }

        public async Task<bool> CreateRace(RaceViewModel model)
        {
            return await _adminDAL.CreateRace(model);
        }

        public async Task<bool> UpdateRace(int id, string description, bool active)
        {
            return await _adminDAL.UpdateRace(id, description, active);
        }

        public async Task<List<MaritalStatusViewModel>> GetAllMaritalStatus()
        {
            return await _adminDAL.GetAllMaritalStatus();
        }

        public async Task<bool> CreateMaritalStatus(MaritalStatusViewModel model)
        {
            return await _adminDAL.CreateMaritalStatus(model);
        }

        public async Task<bool> UpdateMaritalStatus(int id, string description, bool active)
        {
            return await _adminDAL.UpdateMaritalStatus(id, description, active);
        }

        public async Task<List<HospitalServiceViewModel>> GetAllHospitalServices()
        {
            return await _adminDAL.GetAllHospitalServices();
        }

        public async Task<bool> CreateHospitalService(HospitalServiceViewModel model)
        {
            return await _adminDAL.CreateHospitalService(model);
        }

        public async Task<bool> UpdateHospitalService(int id, string description, bool active)
        {
            return await _adminDAL.UpdateHospitalService(id, description, active);
        }

        public async Task<List<BirthGenderViewModel>> GetAllBirthGenders()
        {
            return await _adminDAL.GetAllBirthGenders();
        }

        public async Task<bool> CreateBirthGender(BirthGenderViewModel model)
        {
            return await _adminDAL.CreateBirthGender(model);
        }

        public async Task<bool> UpdateBirthGender(int id, string description, bool active)
        {
            return await _adminDAL.UpdateBirthGender(id, description, active);
        }
    }
}
