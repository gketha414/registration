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

        }
    }
}