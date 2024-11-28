
using PreRegistration.Models.Helpers;
using PreRegistration.Models.UI;
using PreRegistration.Models.ViewModels;
using RespiratoryProtectionProgram.BL;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
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

            bool successSubmit = true/*await _preRegistrationBL.SubmitPreRegistrationForm(patientViewModel)*/;


            return Json(successSubmit, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public async Task<JsonResult> submitPatientData(PatientViewModel patientViewModel, int updateId)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);
            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }
            var successSubmit = await _preRegistrationBL.submitPatient(patientViewModel, updateId);
            if (successSubmit == 0)
            {
                string errorMsg = "Data validation failed. SomethingWentWrong";

                // Return error in JSON format
                return Json(new { error = errorMsg }, JsonRequestBehavior.AllowGet);
            }

            return Json(successSubmit, JsonRequestBehavior.AllowGet);



        }
        [HttpPost]
        public async Task<JsonResult> submitSpouseData(PatientViewModel patientViewModel, int personId, int updateId)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);
            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }
            patientViewModel.SpouseInformation.PersonID = personId;
            var successSubmit = await _preRegistrationBL.submitSpouse(patientViewModel.SpouseInformation, updateId);


            return Json(successSubmit, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public async Task<JsonResult> submitMinorData(PatientViewModel patientViewModel, int personId, int fatherId, int motherId)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);
            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }
            patientViewModel.MinorInformation.MontherMinorInformation.PersonID = personId;
            patientViewModel.MinorInformation.FatherMinorInformation.PersonID = personId;
            patientViewModel.MinorInformation.FatherMinorInformation.ResponsiblePartyID = patientViewModel.MinorInformation.MontherMinorInformation.ResponsiblePartyID;


            var successSubmit = await _preRegistrationBL.submitMinor(patientViewModel.MinorInformation, fatherId, motherId);



            return Json(successSubmit, JsonRequestBehavior.AllowGet);



        }
        [HttpPost]
        public async Task<JsonResult> submitInsuranceData(PatientViewModel patientViewModel, int personId, int insId1, int insId2, int insId3)
        {

            if (patientViewModel.InsuranceInformation.InsuranceOne.Attachment != null)
            {
                var attachmentList = patientViewModel.InsuranceInformation.InsuranceOne.Attachment.ToString().Split(',').ToList();
                patientViewModel.InsuranceInformation.InsuranceOne.AttachmentList = attachmentList;
            }

            if (patientViewModel.InsuranceInformation.InsuranceTwo.Attachment != null)
            {

                var attachmentList2 = patientViewModel.InsuranceInformation.InsuranceTwo.Attachment.ToString().Split(',').ToList();
                patientViewModel.InsuranceInformation.InsuranceTwo.AttachmentList = attachmentList2;

            }


            if (patientViewModel.InsuranceInformation.InsuranceThree.Attachment != null)
            {
                var attachmentList3 = patientViewModel.InsuranceInformation.InsuranceThree.Attachment.ToString().Split(',').ToList();
                patientViewModel.InsuranceInformation.InsuranceThree.AttachmentList = attachmentList3;
            }

            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);
            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }
            patientViewModel.InsuranceInformation.InsuranceOne.PersonID = personId;
            patientViewModel.InsuranceInformation.InsuranceTwo.PersonID = personId;
            patientViewModel.InsuranceInformation.InsuranceThree.PersonID = personId;
            var successSubmit = await _preRegistrationBL.submitInsurance(patientViewModel.InsuranceInformation, insId1, insId2, insId3);

            return Json(successSubmit, JsonRequestBehavior.AllowGet);



        }

        [HttpPost]
        public async Task<JsonResult> submitEmergencyData(PatientViewModel patientViewModel, int personId, int emgId1, int emgId2, int emgId3)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);
            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }

            patientViewModel.EmergencyContact.EmergencyContactOne.PersonID = personId;
            patientViewModel.EmergencyContact.EmergencyContactTwo.PersonID = personId;
            patientViewModel.EmergencyContact.EmergencyContactThree.PersonID = personId;
            var successSubmit = await _preRegistrationBL.submitEmergency(patientViewModel.EmergencyContact, emgId1, emgId2, emgId3);


            return Json(successSubmit, JsonRequestBehavior.AllowGet);

        }


        [HttpPost]
        public async Task<JsonResult> submitAccidentData(PatientViewModel patientViewModel, int personId, int updateId)
        {
            string userId = System.Web.HttpContext.Current.User.Identity.Name.ToString();
            userId = userId.Substring(userId.IndexOf("\\") + 1);
            if (ModelState.IsValid)
            {
                StringBuilder errorMsg = new StringBuilder("<ul>");
                int errorCount = 0;

                errorMsg.Append("</ul>");

                if (errorCount > 0)
                {
                    return Json(new { error = errorMsg.ToString() }, JsonRequestBehavior.AllowGet);
                }

            }
            patientViewModel.AccidentDetail.PersonID = personId;
            var successSubmit = await _preRegistrationBL.submitAccident(patientViewModel.AccidentDetail, updateId);

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