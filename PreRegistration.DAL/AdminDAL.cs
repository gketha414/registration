using PreRegistration.Models;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreRegistration.DAL
{
    public class AdminDAL
    {
        private PatientPreRegistrationEntities _context;
        private Logger _log = new Logger();
        public string userid;

        public AdminDAL()
        {
            _context = new PatientPreRegistrationEntities();
        }

        public async Task<List<AccidentTypeViewModel>> GetAllAccidentTypes()
        {
            List<AccidentTypeViewModel> periodMasterViewModels = new List<AccidentTypeViewModel>();
            try
            {
                var accidentTypes = _context.AccidentTypes.Where(a=>a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<AccidentTypeViewModel, AccidentType>();
                periodMasterViewModels = AutoMapper.Mapper.Map<List<AccidentType>, List<AccidentTypeViewModel>>(accidentTypes);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllAccidentTypes: " + ex);
            }

            return periodMasterViewModels;
        }

        public async Task<bool> CreateAccidentType(AccidentTypeViewModel model)
        {
            try
            {
                AccidentType accidentType = new AccidentType
                {
                    Description = model.NewDescription,
                    IsActive = true
                };
                _context.AccidentTypes.Add(accidentType);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create Accident Type: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateAccidentType(int id, string description, bool active)
        {
            try
            {
                var accidentType = _context.AccidentTypes.FirstOrDefault(x => x.AccidentTypeID == id);
                accidentType.Description = description;
                accidentType.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing Accident Type record - UpdateAccidentType  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<HospitalViewModel>> GetAllHospitals()
        {
            List<HospitalViewModel> periodMasterViewModels = new List<HospitalViewModel>();
            try
            {
                var accidentTypes = _context.Hospitals.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<HospitalViewModel, Hospital>();
                periodMasterViewModels = AutoMapper.Mapper.Map<List<Hospital>, List<HospitalViewModel>>(accidentTypes);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllHospitals: " + ex);
            }

            return periodMasterViewModels;
        }

        public async Task<bool> CreateHospital(HospitalViewModel model)
        {
            try
            {
                Hospital hospital = new Hospital
                {
                    HospitalName = model.NewHospitalName,
                    IsActive = true
                };
                _context.Hospitals.Add(hospital);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create Hospital: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateHospital(int id, string hospitalName, bool active)
        {
            try
            {
                var hospital = _context.Hospitals.FirstOrDefault(x => x.HospitalID == id);
                hospital.HospitalName = hospitalName;
                hospital.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing Accident Type record - UpdateHospital  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<ResponsiblePartyViewModel>> GetAllResponsibleParties()
        {
            List<ResponsiblePartyViewModel> periodMasterViewModels = new List<ResponsiblePartyViewModel>();
            try
            {
                var responsibleParties = _context.ResponsibleParties.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<ResponsiblePartyViewModel, ResponsibleParty>();
                periodMasterViewModels = AutoMapper.Mapper.Map<List<ResponsibleParty>, List<ResponsiblePartyViewModel>>(responsibleParties);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllResponsibleParties: " + ex);
            }

            return periodMasterViewModels;
        }

        public async Task<bool> CreateResponsibleParty(ResponsiblePartyViewModel model)
        {
            try
            {
                ResponsibleParty responsibleParty = new ResponsibleParty
                {
                    ResponsiblePartyDescription = model.NewResponsiblePartyDescription,
                    IsActive = true
                };
                _context.ResponsibleParties.Add(responsibleParty);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create ResponsibleParty: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateResponsibleParty(int id, string responsiblePartyDescription, bool active)
        {
            try
            {
                var responsibleParty = _context.ResponsibleParties.FirstOrDefault(x => x.ResponsiblePartyID == id);
                responsibleParty.ResponsiblePartyDescription = responsiblePartyDescription;
                responsibleParty.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing ResponsibleParty record - UpdateResponsibleParty  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<StateViewModel>> GetAllStates()
        {
            List<StateViewModel> periodMasterViewModels = new List<StateViewModel>();
            try
            {
                var states = _context.States.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<StateViewModel, State>();
                periodMasterViewModels = AutoMapper.Mapper.Map<List<State>, List<StateViewModel>>(states);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllStates: " + ex);
            }

            return periodMasterViewModels;
        }

        public async Task<bool> CreateState(StateViewModel model)
        {
            try
            {
                State state = new State
                {
                    StateName = model.NewStateName,
                    StateID = model.NewStateName.Substring(0,1),
                    IsActive = true
                };
                _context.States.Add(state);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create State: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateState(string id, string stateName, bool active)
        {
            try
            {
                var state = _context.States.FirstOrDefault(x => x.StateID == id);
                state.StateName = stateName;
                state.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing State record - UpdateState  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<EthnicityViewModel>> GetAllEthnicities()
        {
            List<EthnicityViewModel> ethnicities = new List<EthnicityViewModel>();
            try
            {
                var ethnicitiesResp = _context.Ethnicities.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<EthnicityViewModel, Ethnicity>();
                ethnicities = AutoMapper.Mapper.Map<List<Ethnicity>, List<EthnicityViewModel>>(ethnicitiesResp);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllEthnicities: " + ex);
            }

            return ethnicities;
        }

        public async Task<bool> CreateEthnicity(EthnicityViewModel model)
        {
            try
            {
                Ethnicity ethnicity = new Ethnicity
                {
                    Description = model.NewDescription,
                    IsActive = true
                };
                _context.Ethnicities.Add(ethnicity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create Ethnicity: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateEthnicity(int id, string description, bool active)
        {
            try
            {
                var ethincity = _context.Ethnicities.FirstOrDefault(x => x.EthnicityID == id);
                ethincity.Description = description;
                ethincity.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing Ethnicity record - UpdateEthnicity  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<GenderViewModel>> GetAllGenders()
        {
            List<GenderViewModel> genderViewModels = new List<GenderViewModel>();
            try
            {
                var genders = _context.Genders.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<GenderViewModel, Gender>();
                genderViewModels = AutoMapper.Mapper.Map<List<Gender>, List<GenderViewModel>>(genders);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllGenders: " + ex);
            }

            return genderViewModels;
        }

        public async Task<bool> CreateGender(GenderViewModel model)
        {
            try
            {
                Gender gender = new Gender
                {
                    Name = model.NewName,
                    IsActive = true
                };
                _context.Genders.Add(gender);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create Gender: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateGender(int id, string name, bool active)
        {
            try
            {
                var gender = _context.Genders.FirstOrDefault(x => x.GenderID == id);
                gender.Name = name;
                gender.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing Gender record - UpdateGender  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<RaceViewModel>> GetAllRaces()
        {
            List<RaceViewModel> races = new List<RaceViewModel>();
            try
            {
                var respone = _context.Races.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<RaceViewModel, Race>();
                races = AutoMapper.Mapper.Map<List<Race>, List<RaceViewModel>>(respone);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllRaces: " + ex);
            }

            return races;
        }

        public async Task<bool> CreateRace(RaceViewModel model)
        {
            try
            {
                Race race = new Race
                {
                    Description = model.NewDescription,
                    IsActive = true
                };
                _context.Races.Add(race);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create Race: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateRace(int id, string description, bool active)
        {
            try
            {
                var race = _context.Races.FirstOrDefault(x => x.RaceID == id);
                race.Description = description;
                race.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing Race record - UpdateRace  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<MaritalStatusViewModel>> GetAllMaritalStatus()
        {
            List<MaritalStatusViewModel> maritalStatuses = new List<MaritalStatusViewModel>();
            try
            {
                var respone = _context.MaritalStatus.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<MaritalStatusViewModel, MaritalStatu>();
                maritalStatuses = AutoMapper.Mapper.Map<List<MaritalStatu>, List<MaritalStatusViewModel>>(respone);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllMaritalStatus: " + ex);
            }

            return maritalStatuses;
        }

        public async Task<bool> CreateMaritalStatus(MaritalStatusViewModel model)
        {
            try
            {
                MaritalStatu maritalStatus = new MaritalStatu
                {
                    Description = model.NewDescription,
                    IsActive = true
                };
                _context.MaritalStatus.Add(maritalStatus);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create MaritalStatus: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateMaritalStatus(int id, string description, bool active)
        {
            try
            {
                var race = _context.MaritalStatus.FirstOrDefault(x => x.ID == id);
                race.Description = description;
                race.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing MaritalStatus record - UpdateMaritalStatus  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<HospitalServiceViewModel>> GetAllHospitalServices()
        {
            List<HospitalServiceViewModel> hospitalServices = new List<HospitalServiceViewModel>();
            try
            {
                var respone = _context.HospitalServices.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<HospitalServiceViewModel, HospitalService>();
                hospitalServices = AutoMapper.Mapper.Map<List<HospitalService>, List<HospitalServiceViewModel>>(respone);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllHospitalServices: " + ex);
            }

            return hospitalServices;
        }

        public async Task<bool> CreateHospitalService(HospitalServiceViewModel model)
        {
            try
            {
                HospitalService hospitalService = new HospitalService
                {
                    Description = model.NewDescription,
                    IsActive = true
                };
                _context.HospitalServices.Add(hospitalService);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create HospitalService: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateHospitalService(int id, string description, bool active)
        {
            try
            {
                var race = _context.HospitalServices.FirstOrDefault(x => x.ID == id);
                race.Description = description;
                race.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing HospitalService record - UpdateHospitalService  :  " + ex);
                return false;
            }

            return true;
        }

        public async Task<List<BirthGenderViewModel>> GetAllBirthGenders()
        {
            List<BirthGenderViewModel> birthGenders = new List<BirthGenderViewModel>();
            try
            {
                var respone = _context.BirthGenders.Where(a => a.IsActive).ToList();

                AutoMapper.Mapper.CreateMap<BirthGenderViewModel, BirthGender>();
                birthGenders = AutoMapper.Mapper.Map<List<BirthGender>, List<BirthGenderViewModel>>(respone);

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetAllBirthGenders: " + ex);
            }

            return birthGenders;
        }

        public async Task<bool> CreateBirthGender(BirthGenderViewModel model)
        {
            try
            {
                BirthGender birthGender = new BirthGender
                {
                    Description = model.NewDescription,
                    IsActive = true
                };
                _context.BirthGenders.Add(birthGender);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                _log.Log("Failed to Create BirthGender: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateBirthGender(int id, string description, bool active)
        {
            try
            {
                var race = _context.BirthGenders.FirstOrDefault(x => x.ID == id);
                race.Description = description;
                race.IsActive = active;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                _log.Log("Error updating existing BirthGenders record - UpdateBirthGender  :  " + ex);
                return false;
            }

            return true;
        }
    }
}
