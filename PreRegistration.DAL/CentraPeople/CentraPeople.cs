using CentraPeople;
using PreRegistration.Models.ViewModels;
using System.Linq;

namespace PreRegistration.DAL.CentraPeople
{
    public static class CentraPeople
    {
        public static CentraPeopleViewModel LookupEmployee(string adId)
        {
            using (CentraPeopleEntities cpcontext = new CentraPeopleEntities())
            {
                CentraPeople_VW centraPeople = cpcontext.CentraPeople_VW.FirstOrDefault(x => x.Ad_Id.Equals(adId));
                CentraPeopleViewModel model = new CentraPeopleViewModel();
                AutoMapper.Mapper.CreateMap<CentraPeopleViewModel, CentraPeople_VW>();
                model = AutoMapper.Mapper.Map<CentraPeople_VW, CentraPeopleViewModel>(centraPeople);
                return model;
            }
        }

        public static CentraPeopleViewModel LookupManager(int employeeId)
        {
            using (CentraPeopleEntities cpcontext = new CentraPeopleEntities())
            {
                CentraPeople_VW centraPeople = cpcontext.CentraPeople_VW.FirstOrDefault(x => x.Employee_Id.Equals(employeeId));
                CentraPeopleViewModel model = new CentraPeopleViewModel();
                AutoMapper.Mapper.CreateMap<CentraPeopleViewModel, CentraPeople_VW>();
                model = AutoMapper.Mapper.Map<CentraPeople_VW, CentraPeopleViewModel>(centraPeople);
                return model;
            }
        }
    }
}
