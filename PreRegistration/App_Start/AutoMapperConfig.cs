using AutoMapper;
using CentraPeople;
using PreRegistration.Models;
using PreRegistration.Models.ViewModels;

namespace PreRegistration.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<CentraPeopleViewModel, CentraPeople_VW>();
            Mapper.CreateMap<CentraPeople_VW, CentraPeopleViewModel>();

            Mapper.CreateMap<MinorInformationViewModel, MinorInformation>();
            Mapper.CreateMap<MinorInformation, MinorInformationViewModel>();

            Mapper.CreateMap<EmergencyContactViewModel, EmergencyContact>();
            Mapper.CreateMap<EmergencyContact, EmergencyContactViewModel>();

            Mapper.CreateMap<InsuranceInformationViewModel, InsuranceInformation>();
            Mapper.CreateMap<InsuranceInformation, InsuranceInformationViewModel>();

            Mapper.CreateMap<AccidentDetailViewModel, AccidentDetail>();
            Mapper.CreateMap<AccidentDetail, AccidentDetailViewModel>();

            Mapper.CreateMap<PatientDemographicsViewModel, PatientDemographic>();
            Mapper.CreateMap<PatientDemographic, PatientDemographicsViewModel>();

            Mapper.CreateMap<AccidentTypeViewModel, AccidentType>();
            Mapper.CreateMap<AccidentType, AccidentTypeViewModel>();

            Mapper.CreateMap<HospitalViewModel, Hospital>();
            Mapper.CreateMap<Hospital, HospitalViewModel>();

            Mapper.CreateMap<ResponsiblePartyViewModel, ResponsibleParty>();
            Mapper.CreateMap<ResponsibleParty, ResponsiblePartyViewModel>();

            Mapper.CreateMap<StateViewModel, State>();
            Mapper.CreateMap<State, StateViewModel>();

            Mapper.CreateMap<EthnicityViewModel, Ethnicity>();
            Mapper.CreateMap<Ethnicity, EthnicityViewModel>();

            Mapper.CreateMap<GenderViewModel, Gender>();
            Mapper.CreateMap<Gender, GenderViewModel>();

            Mapper.CreateMap<RaceViewModel, Race>();
            Mapper.CreateMap<Race, RaceViewModel>();

            Mapper.CreateMap<MaritalStatusViewModel, MaritalStatu>();
            Mapper.CreateMap<MaritalStatu, MaritalStatusViewModel>();

            Mapper.CreateMap<HospitalServiceViewModel, HospitalService>();
            Mapper.CreateMap<HospitalService, HospitalServiceViewModel>();

            Mapper.CreateMap<BirthGenderViewModel, BirthGender>();
            Mapper.CreateMap<BirthGender, BirthGenderViewModel>();
        }
    }
}