using Newtonsoft.Json;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.UI;
using PreRegistration.Models.ViewModels;
using RespiratoryProtectionProgram.BL;
using System;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
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

        public ActionResult PatientList()
        {
            PatientViewModel patientModel = new PatientViewModel();
            string userId = string.Empty;

            patientModel = _preRegistrationBL.GetPatientModel().Result;

            return View(patientModel);
        }

        public JsonResult GetPatientsByHospital(int hospitalId, int displayId)
        {
            var patientDemographics = _preRegistrationBL.GetPatientsByHospital(hospitalId, displayId).Result;

            return new JsonResult()
            {
                Data = patientDemographics,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                MaxJsonLength = int.MaxValue
            };
        }

        public ActionResult ViewPatient(int personId)
        {
            PatientModel model = new PatientModel();
            model = _preRegistrationBL.GetPatientById(personId).Result;

            return View(model);
        }

        public JsonResult Upload()
        {
            try
            {
                if (Request.Files.Count < 1)
                {
                    throw new HttpException(500, "No file to upload");
                }
                else
                {
                    Guid fileGuid = Guid.NewGuid();
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        HttpPostedFileBase file = Request.Files[i]; //Uploaded file
                        //HttpPostedFileBase file = Request.Files[0]; //Uploaded file
                        //Use the following properties to get file's name, size and MIMEType
                        int fileSize = file.ContentLength;
                        string fileName = file.FileName;
                        string mimeType = file.ContentType;
                        System.IO.Stream fileContent = file.InputStream;
                        string getFileName = Path.GetFileName(file.FileName);
                        //To save file, use SaveAs method
                        System.IO.Directory.CreateDirectory(Server.MapPath("../AttachedFiles/" + fileGuid + "/"));
                        file.SaveAs(Server.MapPath("../AttachedFiles/" + fileGuid + "/") + getFileName); //File will be saved in application root
                    }
                    return Json(fileGuid);
                }
            }
            catch
            {
                var error = "Error";
                return Json(error);
            }
        }

        public JsonResult DeleteFile(string fileId, int bridgeId)
        {
            var root = Server.MapPath("../AttachedFiles/" + fileId);

            if (System.IO.File.Exists(root))
            {
                // If file found, delete it    
                System.IO.File.Delete(root);
               // _mgr.DeleteUnitAttachment(bridgeId);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}