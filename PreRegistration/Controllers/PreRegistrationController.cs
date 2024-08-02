using Newtonsoft.Json;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.ViewModels;
using RespiratoryProtectionProgram.BL;
using System;
using System.Configuration;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PreRegistration.Controllers
{
    public class PreRegistrationController : Controller
    {
        private PreRegistrationBL _preRegistrationBL = new PreRegistrationBL();
        public string testUserId = ConfigurationManager.AppSettings["TestUser"];
        private static string _devMode = ConfigurationManager.AppSettings["DevelopmentMode"];
        Logger log = new Logger();

        // GET: PreRegistration
        public ActionResult Index()
        {

        //    ECRespiratoryProtectionFormViewModel respiratoryProtectionFormViewModel = new ECRespiratoryProtectionFormViewModel();
            string userId = string.Empty;

            if (_devMode == "true")
            {
                userId = testUserId;
            }
            else
            {
                userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                userId = userId.Substring(userId.IndexOf("\\") + 1);
            }
            return RedirectToAction("OnlinePreRegistration", "PreRegistration");
            //respiratoryProtectionFormViewModel.UserGroup = PreRegistrationBL.GetADGroup(userId);

            // if ((respiratoryProtectionFormViewModel.UserGroup == "Admin") || (respiratoryProtectionFormViewModel.UserGroup == "Contributor"))
            //{
            //  return RedirectToAction("LandingPage", "PreRegistration");
            //}
            //else
            //{
            //    return RedirectToAction("NoEntry", "PreRegistration");
            //}
        }

        public ActionResult OnlinePreRegistration()
        {
            //    ECRespiratoryProtectionFormViewModel respiratoryProtectionFormViewModel = new ECRespiratoryProtectionFormViewModel();

            string userId = string.Empty;

            if (_devMode == "true")
            {
                userId = testUserId;
                //    respiratoryProtectionFormViewModel.EmpADID = testUserId;
            }
            else
            {
                userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                userId = userId.Substring(userId.IndexOf("\\") + 1);
                // respiratoryProtectionFormViewModel.EmpADID = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                //  respiratoryProtectionFormViewModel.EmpADID = respiratoryProtectionFormViewModel.EmpADID.Substring(respiratoryProtectionFormViewModel.EmpADID.IndexOf("\\") + 1);
            }

            //   var userGroup = PreRegistrationBL.GetADGroup(userId);

            //if ((userGroup == "Admin") || (userGroup == "Contributor"))
            //{
            //    log.Log("Creating AdId " + respiratoryProtectionFormViewModel.EmpADID);

            //    respiratoryProtectionFormViewModel.UserGroup = userGroup;
            //}
            //else
            //{
            //    return RedirectToAction("NoEntry", "PreRegistration");
            //}

            return View();
        }

        public ActionResult LandingPage()
        {
            PatientViewModel patientModel = new PatientViewModel();
            string userId = string.Empty;

            patientModel = _preRegistrationBL.GetPatientModel().Result;

            if (_devMode == "true")
            {
                userId = testUserId;
            //    respiratoryProtectionFormViewModel.EmpADID = testUserId;
            }
            else
            {
                userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                userId = userId.Substring(userId.IndexOf("\\") + 1);
               // respiratoryProtectionFormViewModel.EmpADID = System.Web.HttpContext.Current.User.Identity.Name.ToString();
              //  respiratoryProtectionFormViewModel.EmpADID = respiratoryProtectionFormViewModel.EmpADID.Substring(respiratoryProtectionFormViewModel.EmpADID.IndexOf("\\") + 1);
            }

         //   var userGroup = PreRegistrationBL.GetADGroup(userId);

            //if ((userGroup == "Admin") || (userGroup == "Contributor"))
            //{
            //    log.Log("Creating AdId " + respiratoryProtectionFormViewModel.EmpADID);

            //    respiratoryProtectionFormViewModel.UserGroup = userGroup;
            //}
            //else
            //{
            //    return RedirectToAction("NoEntry", "PreRegistration");
            //}

            return View(patientModel);
        }

        public ActionResult ReleaseInfo()
        {
            //    ECRespiratoryProtectionFormViewModel respiratoryProtectionFormViewModel = new ECRespiratoryProtectionFormViewModel();

            string userId = string.Empty;

            if (_devMode == "true")
            {
                userId = testUserId;
                //    respiratoryProtectionFormViewModel.EmpADID = testUserId;
            }
            else
            {
                userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                userId = userId.Substring(userId.IndexOf("\\") + 1);
                // respiratoryProtectionFormViewModel.EmpADID = System.Web.HttpContext.Current.User.Identity.Name.ToString();
                //  respiratoryProtectionFormViewModel.EmpADID = respiratoryProtectionFormViewModel.EmpADID.Substring(respiratoryProtectionFormViewModel.EmpADID.IndexOf("\\") + 1);
            }

            //   var userGroup = PreRegistrationBL.GetADGroup(userId);

            //if ((userGroup == "Admin") || (userGroup == "Contributor"))
            //{
            //    log.Log("Creating AdId " + respiratoryProtectionFormViewModel.EmpADID);

            //    respiratoryProtectionFormViewModel.UserGroup = userGroup;
            //}
            //else
            //{
            //    return RedirectToAction("NoEntry", "PreRegistration");
            //}

            return View();
        }

        public ActionResult NoEntry()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<JsonResult> SubmitECRespiratoryProtectionForm(PatientViewModel patientViewModel)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);

            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                //if (respiratoryProtectionFormViewModel.EmpNumber == 0)
                //{
                //    errorMsg.Append("<li>").Append("Employee is not valid.").Append(" </li>");
                //    errorCount++;
                //}

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }

            bool successSubmit = await _preRegistrationBL.SubmitPreRegistrationForm(patientViewModel);

            return Json(successSubmit, JsonRequestBehavior.AllowGet);
        }
    }
}