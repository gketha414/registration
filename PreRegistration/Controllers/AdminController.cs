using PreRegistration.BL;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.ViewModels;
using System.Configuration;
using System.Web.Mvc;

namespace PreRegistration.Controllers
{
    public class AdminController : Controller
    {
        private AdminBL _adminBL = new AdminBL();
        public string testUserId = ConfigurationManager.AppSettings["TestUser"];
        private static string _devMode = ConfigurationManager.AppSettings["DevelopmentMode"];
        Logger log = new Logger();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AccidentTypeMaint(bool? success)
        {
            AccidentTypeViewModel model = new AccidentTypeViewModel
            {
                AllAccidentTypes = _adminBL.GetAllAccidentTypes().Result
            };

            return View(model);
        }

        public ActionResult CreateAccidentType(AccidentTypeViewModel viewModel)
        {
            bool success = _adminBL.CreateAccidentType(viewModel).Result;
            return RedirectToAction("AccidentTypeMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateAccidentType(int id, string description, bool active)
        {
            bool success = _adminBL.UpdateAccidentType(id, description, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HospitalMaint(bool? success)
        {
            HospitalViewModel model = new HospitalViewModel
            {
                AllHospitals = _adminBL.GetAllHospitals().Result
            };

            return View(model);
        }

        public ActionResult CreateHospital(HospitalViewModel viewModel)
        {
            bool success = _adminBL.CreateHospital(viewModel).Result;
            return RedirectToAction("HospitalMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateHospital(int id, string hospitalName, bool active)
        {
            bool success = _adminBL.UpdateHospital(id, hospitalName, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ResponsiblePartyMaint(bool? success)
        {
            ResponsiblePartyViewModel model = new ResponsiblePartyViewModel
            {
                AllResponsibleParties = _adminBL.GetAllResponsibleParties().Result
            };

            return View(model);
        }

        public ActionResult CreateResponsibleParty(ResponsiblePartyViewModel viewModel)
        {
            bool success = _adminBL.CreateResponsibleParty(viewModel).Result;
            return RedirectToAction("ResponsiblePartyMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateResponsibleParty(int id, string responsiblePartyDescription, bool active)
        {
            bool success = _adminBL.UpdateResponsibleParty(id, responsiblePartyDescription, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult StateMaint(bool? success)
        {
            StateViewModel model = new StateViewModel
            {
                AllStates = _adminBL.GetAllStates().Result
            };

            return View(model);
        }

        public ActionResult CreateState(StateViewModel viewModel)
        {
            bool success = _adminBL.CreateState(viewModel).Result;
            return RedirectToAction("StateMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateState(string id, string stateName, bool active)
        {
            bool success = _adminBL.UpdateState(id, stateName, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EthnicityMaint(bool? success)
        {
            EthnicityViewModel model = new EthnicityViewModel
            {
                AllEthnicities = _adminBL.GetAllEthnicities().Result
            };

            return View(model);
        }

        public ActionResult CreateEthnicity(EthnicityViewModel viewModel)
        {
            bool success = _adminBL.CreateEthnicity(viewModel).Result;
            return RedirectToAction("EthnicityMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateEthnicity(int id, string description, bool active)
        {
            bool success = _adminBL.UpdateEthnicity(id, description, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GenderMaint(bool? success)
        {
            GenderViewModel model = new GenderViewModel
            {
                AllGenders = _adminBL.GetAllGenders().Result
            };

            return View(model);
        }

        public ActionResult CreateGender(GenderViewModel viewModel)
        {
            bool success = _adminBL.CreateGender(viewModel).Result;
            return RedirectToAction("GenderMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateGender(int id, string name, bool active)
        {
            bool success = _adminBL.UpdateGender(id, name, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RaceMaint(bool? success)
        {
            RaceViewModel model = new RaceViewModel
            {
                AllRaces = _adminBL.GetAllRaces().Result
            };

            return View(model);
        }

        public ActionResult CreateRace(RaceViewModel viewModel)
        {
            bool success = _adminBL.CreateRace(viewModel).Result;
            return RedirectToAction("RaceMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateRace(int id, string description, bool active)
        {
            bool success = _adminBL.UpdateRace(id, description, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult MaritalStatusMaint(bool? success)
        {
            MaritalStatusViewModel model = new MaritalStatusViewModel
            {
                AllMaritalStatuses = _adminBL.GetAllMaritalStatus().Result
            };

            return View(model);
        }

        public ActionResult CreateMaritalStatus(MaritalStatusViewModel viewModel)
        {
            bool success = _adminBL.CreateMaritalStatus(viewModel).Result;
            return RedirectToAction("MaritalStatusMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateMaritalStatus(int id, string description, bool active)
        {
            bool success = _adminBL.UpdateMaritalStatus(id, description, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult HospitalServiceMaint(bool? success)
        {
            HospitalServiceViewModel model = new HospitalServiceViewModel
            {
                AllHospitalServices = _adminBL.GetAllHospitalServices().Result
            };

            return View(model);
        }

        public ActionResult CreateHospitalService(HospitalServiceViewModel viewModel)
        {
            bool success = _adminBL.CreateHospitalService(viewModel).Result;
            return RedirectToAction("HospitalServiceMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateHospitalService(int id, string description, bool active)
        {
            bool success = _adminBL.UpdateHospitalService(id, description, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BirthGenderMaint(bool? success)
        {
            BirthGenderViewModel model = new BirthGenderViewModel
            {
                AllBirthGenders = _adminBL.GetAllBirthGenders().Result
            };

            return View(model);
        }

        public ActionResult CreateBirthGender(BirthGenderViewModel viewModel)
        {
            bool success = _adminBL.CreateBirthGender(viewModel).Result;
            return RedirectToAction("BirthGenderMaint", "Admin", new { success = success });
        }

        public JsonResult UpdateBirthGender(int id, string description, bool active)
        {
            bool success = _adminBL.UpdateBirthGender(id, description, active).Result;
            return Json(success, JsonRequestBehavior.AllowGet);
        }
    }
}