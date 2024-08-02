using PreRegistration.Models;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PreRegistration.DAL
{
    public class PreRegistrationDAL
    {
        private PatientPreRegistrationEntities _context;
        private Logger _log = new Logger();
        public string userid;

        public PreRegistrationDAL()
        {
            _context = new PatientPreRegistrationEntities();
        }

        public async Task<PatientViewModel> GetPatientModel()
        {
            PatientViewModel patientModel = new PatientViewModel();
            try
            {

                patientModel.Hospitals.Add(new SelectListItem { Text = "-- Select Hospital --", Value = "0" });
                patientModel.Hospitals.AddRange(_context.Hospitals.Select(x => new SelectListItem { Text = x.HospitalName, Value = x.HospitalID.ToString() }).ToList());

                patientModel.States.Add(new SelectListItem { Text = "-- Select State --", Value = "0" });
                patientModel.States.AddRange(_context.States.Select(x => new SelectListItem { Text = x.StateName, Value = x.StateID.ToString() }).ToList());

                List<SelectListItem> Races = new List<SelectListItem>
                {
                    new SelectListItem { Text = "American Indian or Alaska Native", Value = "American Indian or Alaska Native" },
                    new SelectListItem { Text = "Asian", Value = "Asian" },
                    new SelectListItem { Text = "Black or African American", Value = "Black or African American" },
                    new SelectListItem { Text = "Hispanic", Value = "Hispanic" },
                    new SelectListItem { Text = "Mixed Race", Value = "Mixed Race" },
                    new SelectListItem { Text = "Native Hawaiian or Other Pacific Islander", Value = "Native Hawaiian or Other Pacific Islander" },
                    new SelectListItem { Text = "Hispanic", Value = "Hispanic" },
                    new SelectListItem { Text = "Other Race", Value = "Other Race" },
                    new SelectListItem { Text = "White", Value = "White" }
                };

                patientModel.Race.Add(new SelectListItem { Text = "-- Select Race --", Value = "0" });
                patientModel.Race.AddRange(Races);

                List<SelectListItem> MaritalStatus = new List<SelectListItem>
                {
                    new SelectListItem { Text = "-- Select Marital Status --", Value = "" },
                    new SelectListItem { Text = "Single", Value = "Single" },
                    new SelectListItem { Text = "Married", Value = "Married" },
                    new SelectListItem { Text = "Separated", Value = "Separated" },
                    new SelectListItem { Text = "Hispanic", Value = "Hispanic" },
                    new SelectListItem { Text = "Divorced", Value = "Divorced" }
                };

                patientModel.MaritalStatus.AddRange(MaritalStatus);

                patientModel.YesNo.Add("Yes");
                patientModel.YesNo.Add("No");

                patientModel.HospitalService.Add("Pregnancy");
                patientModel.HospitalService.Add("Surgery");
                patientModel.HospitalService.Add("Other");

                patientModel.Gender.Add("Female");
                patientModel.Gender.Add("Male");

                patientModel.Guarantors.AddRange(_context.ResponsibleParties.Select(x => new SelectListItem { Text = x.ResponsiblePartyDescription, Value = x.ResponsiblePartyID.ToString() }).ToList());

                var accidentTypes = _context.AccidentTypes.ToList();
                foreach(var type in accidentTypes)
                {
                    patientModel.AccidentTypes.Add(type.Description);
                }

            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetPatientModel: " + ex);
            }
            return patientModel;
        }

        //public async Task<List<ECRespiratoryProtectionFormViewModel>> GetAllForms()
        //{
        //    List<ECRespiratoryProtectionFormViewModel> eCRespiratoryProtections = new List<ECRespiratoryProtectionFormViewModel>();
        //    try
        //    {

        //        eCRespiratoryProtections = (from respiratoryProtectionForms in _context.ECRespiratoryProtectionForms
        //                                    join reason in _context.ECRespiratoryProtectionWaivedReasons on respiratoryProtectionForms.WaivedReasonId equals reason.WaivedReasonId
        //                                    join status in _context.ECRespiratoryProtectionStatusMasters on respiratoryProtectionForms.StatusId equals status.StatusId into rs
        //                                    from status in rs.DefaultIfEmpty()
        //                                    select new ECRespiratoryProtectionFormViewModel
        //                                    {
        //                                        FormId = respiratoryProtectionForms.FormId,
        //                                        EmpName = respiratoryProtectionForms.EmpName,
        //                                        EmpNumber = respiratoryProtectionForms.EmpNumber,
        //                                        EmpADID = respiratoryProtectionForms.EmpADID,
        //                                        EmpJobTitle = respiratoryProtectionForms.EmpJobTitle,
        //                                        EmpJobCode = respiratoryProtectionForms.EmpJobCode,
        //                                        EmpDepartment = respiratoryProtectionForms.EmpDepartment,
        //                                        EmpCostCenter = respiratoryProtectionForms.EmpCostCenter,
        //                                        CurrentRiskLevel = respiratoryProtectionForms.CurrentRiskLevel,
        //                                        StatusId = respiratoryProtectionForms.StatusId,
        //                                        WaivedReasonId = respiratoryProtectionForms.WaivedReasonId,
        //                                        IsRespiratoryRiskLevelHIGH = respiratoryProtectionForms.IsRespiratoryRiskLevelHIGH,
        //                                        DirectpatientOrPerformingJobRelatedTasks = respiratoryProtectionForms.DirectpatientOrPerformingJobRelatedTasks,
        //                                        N95RespiratorReadily = respiratoryProtectionForms.N95RespiratorReadily,
        //                                        EmployeeWorkPartTimePRN = respiratoryProtectionForms.EmployeeWorkPartTimePRN,
        //                                        CreatedBy = respiratoryProtectionForms.CreatedBy,
        //                                        Created = respiratoryProtectionForms.Created,
        //                                        ModifiedBy = respiratoryProtectionForms.ModifiedBy,
        //                                        Modified = respiratoryProtectionForms.Modified,
        //                                        Status = status.Status,
        //                                        WaivedReason = reason.Reason
        //                                    }).ToList();

        //        return eCRespiratoryProtections;

        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Failed to get GetAllForms: " + ex);
        //    }
        //    return eCRespiratoryProtections;
        //}

        //public async Task<ECRespiratoryProtectionFormViewModel> ECRespiratoryProtectionFormLoad(int formId)
        //{
        //    ECRespiratoryProtectionFormViewModel respiratoryProtectionFormViewModel = new ECRespiratoryProtectionFormViewModel();

        //    try
        //    {
        //        if (formId > 0)
        //        {
        //            respiratoryProtectionFormViewModel = await GetFormById(formId);
        //        }
        //        respiratoryProtectionFormViewModel.ECRespiratoryProtectionStatusMaster.Add(new SelectListItem { Text = "Select Status", Value = "0" });
        //        respiratoryProtectionFormViewModel.ECRespiratoryProtectionStatusMaster.AddRange(_context.ECRespiratoryProtectionStatusMasters.Select(x => new SelectListItem { Text = x.Status, Value = x.StatusId.ToString() }).ToList());

        //        respiratoryProtectionFormViewModel.ECRespiratoryProtectionWaivedReasons.Add(new SelectListItem { Text = "Select Waived Reason", Value = "0" });
        //        respiratoryProtectionFormViewModel.ECRespiratoryProtectionWaivedReasons.AddRange(_context.ECRespiratoryProtectionWaivedReasons.Select(x => new SelectListItem { Text = x.Reason, Value = x.WaivedReasonId.ToString() }).ToList());
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Failed to get ECRespiratoryProtectionFormLoad: " + ex);
        //    }

        //    return respiratoryProtectionFormViewModel;
        //}

        public async Task<bool> SubmitPreRegistrationForm(PatientViewModel patientViewModel)
        {
            try
            {
                SendEmails sendEmails = new SendEmails();
                int patientId = 0;
                if (patientViewModel.PatientDemographicsViewModel != null)
                {
                    PatientDemographic patientDemographic = new PatientDemographic
                    {

                        HospitalID = patientViewModel.PatientDemographicsViewModel.HospitalID,
                        In_Hospital_Directory = patientViewModel.PatientDemographicsViewModel.In_Hospital_Directory,
                        HospitalService = patientViewModel.PatientDemographicsViewModel.HospitalService,
                        PrimaryCarePhys = patientViewModel.PatientDemographicsViewModel.PrimaryCarePhys,
                        AdmitDate = Convert.ToDateTime(patientViewModel.PatientDemographicsViewModel.AdmitDate),
                        PatientHereBefore = patientViewModel.PatientDemographicsViewModel.PatientHereBefore,
                        First_Name = patientViewModel.PatientDemographicsViewModel.First_Name,
                        Middle_Name = patientViewModel.PatientDemographicsViewModel.Middle_Name,
                        Last_Name = patientViewModel.PatientDemographicsViewModel.Last_Name,
                        Entitlement = patientViewModel.PatientDemographicsViewModel.Entitlement,
                        Gender = patientViewModel.PatientDemographicsViewModel.Gender,
                        Address1 = patientViewModel.PatientDemographicsViewModel.Address1,
                        Address2 = patientViewModel.PatientDemographicsViewModel.Address2,
                        City = patientViewModel.PatientDemographicsViewModel.City,
                        StateProvince = patientViewModel.PatientDemographicsViewModel.StateProvince,
                        ZipCode = patientViewModel.PatientDemographicsViewModel.ZipCode,
                        BirthDate = patientViewModel.PatientDemographicsViewModel.BirthDate,
                        Race = patientViewModel.PatientDemographicsViewModel.Race,
                        Marital_Status = patientViewModel.PatientDemographicsViewModel.Marital_Status,
                        SSN = patientViewModel.PatientDemographicsViewModel.SSN,
                        Home_Phone = patientViewModel.PatientDemographicsViewModel.Home_Phone,
                        Cell_Phone = patientViewModel.PatientDemographicsViewModel.Cell_Phone,
                        Email_Address = patientViewModel.PatientDemographicsViewModel.Email_Address,
                        Church_Choice = patientViewModel.PatientDemographicsViewModel.Church_Choice,

                        Mailing_Address1 = patientViewModel.PatientDemographicsViewModel.Mailing_Address1,
                        Mailing_Address2 = patientViewModel.PatientDemographicsViewModel.Mailing_Address2,
                        MailingCity = patientViewModel.PatientDemographicsViewModel.MailingCity,
                        MailingState = patientViewModel.PatientDemographicsViewModel.MailingState,
                        MailingZip = patientViewModel.PatientDemographicsViewModel.MailingZip,

                        E911Address1 = patientViewModel.PatientDemographicsViewModel.E911Address2,
                        E911Address2 = patientViewModel.PatientDemographicsViewModel.Mailing_Address1,
                        E911City = patientViewModel.PatientDemographicsViewModel.E911City,
                        E911State = patientViewModel.PatientDemographicsViewModel.E911State,
                        E911Zip = patientViewModel.PatientDemographicsViewModel.E911Zip,

                        ResponsiblePartyID = patientViewModel.PatientDemographicsViewModel.ResponsiblePartyID,
                        GuarNameIfOther = patientViewModel.PatientDemographicsViewModel.GuarNameIfOther,

                        Bill_Address1 = patientViewModel.PatientDemographicsViewModel.Bill_Address1,
                        Bill_Address2 = patientViewModel.PatientDemographicsViewModel.Bill_Address2,
                        Bill_City = patientViewModel.PatientDemographicsViewModel.E911State,
                        Bill_State = patientViewModel.PatientDemographicsViewModel.Bill_State,
                        Bill_ZipCode = patientViewModel.PatientDemographicsViewModel.Bill_ZipCode,

                        Employer = patientViewModel.PatientDemographicsViewModel.Employer,
                        Job_Title = patientViewModel.PatientDemographicsViewModel.Job_Title,
                        EmployerAddress1 = patientViewModel.PatientDemographicsViewModel.EmployerAddress1,
                        EmployerAddress2 = patientViewModel.PatientDemographicsViewModel.EmployerAddress2,
                        EmployerCity = patientViewModel.PatientDemographicsViewModel.EmployerCity,
                        EmployerState = patientViewModel.PatientDemographicsViewModel.EmployerState,
                        EmployerZip = patientViewModel.PatientDemographicsViewModel.EmployerZip,
                        EmployerPhone = patientViewModel.PatientDemographicsViewModel.EmployerPhone,
                        //       Status = patientViewModel.PatientDemographicsViewModel.Status,

                        SectionID = 1,
                        Created = DateTime.Now,
                    };

                    _context.PatientDemographics.Add(patientDemographic);
                    await _context.SaveChangesAsync();

                    patientId = patientDemographic.PersonID;

                    if(patientViewModel.SpouseInformation != null)
                    {
                        patientViewModel.SpouseInformation.PersonID = patientId;
                        await SubmitSpouseInfo(patientViewModel.SpouseInformation);
                    }

                    if (patientViewModel.MinorInformation != null)
                    {
                        patientViewModel.MinorInformation.PersonID = patientId;
                        await SubmitMinorInfo(patientViewModel.MinorInformation);
                    }

                    if (patientViewModel.EmergencyContact != null)
                    {
                        patientViewModel.EmergencyContact.PersonID = patientId;
                        await SubmitEmergencyContact(patientViewModel.EmergencyContact);
                    }

                    if (patientViewModel.InsuranceInformation != null)
                    {
                        patientViewModel.InsuranceInformation.PersonID = patientId;
                        await SubmitInsuranceInfo(patientViewModel.InsuranceInformation);
                    }

                    if (patientViewModel.AccidentDetail != null)
                    {
                        patientViewModel.AccidentDetail.PersonID = patientId;
                        await SubmitAccidentDetail(patientViewModel.AccidentDetail);
                    }
                }

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _log.Log("Validation error on SubmitPreRegistrationForm function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
                    }
                }
                return false;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitPreRegistrationForm: " + ex);
                return false;
            }
        }

        public async Task<bool> SubmitSpouseInfo(SpouseInformationViewModel spouseInformation)
        {
            try
            {
                SpouseInformation spouse = new SpouseInformation()
                {
                    PersonID = spouseInformation.PersonID,

                    First_Name = spouseInformation.First_Name,
                    Middle_Name = spouseInformation.Middle_Name,
                    Last_Name = spouseInformation.Last_Name,
                    Address1 = spouseInformation.Address1,
                    Address2 = spouseInformation.Address2,
                    City = spouseInformation.City,
                    StateProvince = spouseInformation.StateProvince,
                    ZipCode = spouseInformation.ZipCode,
                    BirthDate = spouseInformation.BirthDate,
                    Race = spouseInformation.Race,
                    Marital_Status = spouseInformation.Marital_Status,
                    SSN = spouseInformation.SSN,
                    Home_Phone = spouseInformation.Home_Phone,
                    Cell_Phone = spouseInformation.Cell_Phone,
                    Employer = spouseInformation.Employer,
                    Job_Title = spouseInformation.Job_Title,
                    EmployerAddress1 = spouseInformation.EmployerAddress1,
                    EmployerAddress2 = spouseInformation.EmployerAddress2,
                    EmployerCity = spouseInformation.EmployerCity,
                    EmployerState = spouseInformation.EmployerState,
                    EmployerZip = spouseInformation.EmployerZip,
                    Employer_Phone = spouseInformation.Employer_Phone,
                };

                _context.SpouseInformations.Add(spouse);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _log.Log("Validation error on SubmitSpouseInfo function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
                    }
                }
                return false;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitSpouseInfo: " + ex);
                return false;
            }
        }

        public async Task<bool> SubmitMinorInfo(MinorInformationViewModel minorInformation)
        {
            try
            {
                MinorInformation model = new MinorInformation();
                AutoMapper.Mapper.CreateMap<MinorInformation, MinorInformationViewModel>();
                model = AutoMapper.Mapper.Map<MinorInformationViewModel, MinorInformation>(minorInformation);

                _context.MinorInformations.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _log.Log("Validation error on SubmitMinorInfo function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
                    }
                }
                return false;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitMinorInfo: " + ex);
                return false;
            }
        }

        public async Task<bool> SubmitEmergencyContact(EmergencyContactViewModel emergencyContact)
        {
            try
            {
                EmergencyContact model = new EmergencyContact();
                AutoMapper.Mapper.CreateMap<EmergencyContact, EmergencyContactViewModel>();
                model = AutoMapper.Mapper.Map<EmergencyContactViewModel, EmergencyContact>(emergencyContact);

                _context.EmergencyContacts.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _log.Log("Validation error on SubmitEmergencyContact function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
                    }
                }
                return false;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitEmergencyContact: " + ex);
                return false;
            }
        }


        public async Task<bool> SubmitInsuranceInfo(InsuranceInformationViewModel insuranceInformation)
        {
            try
            {
                InsuranceInformation model = new InsuranceInformation();
                AutoMapper.Mapper.CreateMap<InsuranceInformation, InsuranceInformationViewModel>();
                model = AutoMapper.Mapper.Map<InsuranceInformationViewModel, InsuranceInformation>(insuranceInformation);

                _context.InsuranceInformations.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _log.Log("Validation error on SubmitInsuranceInfo function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
                    }
                }
                return false;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitInsuranceInfo: " + ex);
                return false;
            }
        }

        public async Task<bool> SubmitAccidentDetail(AccidentDetailViewModel accidentDetailViewModel)
        {
            try
            {
                AccidentDetail model = new AccidentDetail();
                AutoMapper.Mapper.CreateMap<AccidentDetail, AccidentDetailViewModel>();
                model = AutoMapper.Mapper.Map<AccidentDetailViewModel, AccidentDetail>(accidentDetailViewModel);

                _context.AccidentDetails.Add(model);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _log.Log("Validation error on SubmitAccidentDetail function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
                    }
                }
                return false;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitAccidentDetail: " + ex);
                return false;
            }
        }

        //public async Task<ECRespiratoryProtectionFormViewModel> GetFormById(int formId)
        //{
        //    try
        //    {
        //        var respiratoryProtections = _context.ECRespiratoryProtectionForms.FirstOrDefault(form => form.FormId == formId);

        //        ECRespiratoryProtectionFormViewModel eCRespiratoryProtections = new ECRespiratoryProtectionFormViewModel()
        //        {
        //            EmpName = respiratoryProtections.EmpName,
        //            EmpADID = respiratoryProtections.EmpADID,
        //            EmpNumber = respiratoryProtections.EmpNumber,
        //            EmpDepartment = respiratoryProtections.EmpDepartment,
        //            EmpCostCenter = respiratoryProtections.EmpCostCenter,
        //            EmpJobCode = respiratoryProtections.EmpJobCode,
        //            EmpJobTitle = respiratoryProtections.EmpJobTitle,
        //            CurrentRiskLevel = respiratoryProtections.CurrentRiskLevel,
        //            WaivedReasonId = respiratoryProtections.WaivedReasonId,
        //            IsRespiratoryRiskLevelHIGH = respiratoryProtections.IsRespiratoryRiskLevelHIGH,
        //            DirectpatientOrPerformingJobRelatedTasks = respiratoryProtections.DirectpatientOrPerformingJobRelatedTasks,
        //            RespiratoryRiskLevelMEDIUM = respiratoryProtections.RespiratoryRiskLevelMEDIUM,
        //            N95RespiratorReadily = respiratoryProtections.N95RespiratorReadily,
        //            EmployeeWorkPartTimePRN = respiratoryProtections.EmployeeWorkPartTimePRN,
        //            StatusId = respiratoryProtections.StatusId,
        //            CreatedBy = respiratoryProtections.CreatedBy,
        //            Created = respiratoryProtections.Created,
        //            FormId = respiratoryProtections.FormId
        //        };

        //        eCRespiratoryProtections.ECRespiratoryProtectionComments = _context.ECRespiratoryProtectionComments.Where(form => form.FormId == formId).ToList();

        //        //eCRespiratoryProtections = (from respiratoryProtectionForms in _context.ECRespiratoryProtectionForms
        //        //                            select new ECRespiratoryProtectionFormViewModel
        //        //                            {
        //        //                                FormId = respiratoryProtectionForms.FormId,
        //        //                                EmpName = respiratoryProtectionForms.EmpName,
        //        //                                EmpNumber = respiratoryProtectionForms.EmpNumber,
        //        //                                EmpADID = respiratoryProtectionForms.EmpADID,
        //        //                                EmpJobTitle = respiratoryProtectionForms.EmpJobTitle,
        //        //                                EmpJobCode = respiratoryProtectionForms.EmpJobCode,
        //        //                                EmpDepartment = respiratoryProtectionForms.EmpDepartment,
        //        //                                EmpCostCenter = respiratoryProtectionForms.EmpCostCenter,
        //        //                                CurrentRiskLevel = respiratoryProtectionForms.CurrentRiskLevel,
        //        //                                StatusId = respiratoryProtectionForms.StatusId,
        //        //                                WaivedReasonId = respiratoryProtectionForms.WaivedReasonId,
        //        //                                IsRespiratoryRiskLevelHIGH = respiratoryProtectionForms.IsRespiratoryRiskLevelHIGH,
        //        //                                DirectpatientOrPerformingJobRelatedTasks = respiratoryProtectionForms.DirectpatientOrPerformingJobRelatedTasks,
        //        //                                N95RespiratorReadily = respiratoryProtectionForms.N95RespiratorReadily,
        //        //                                EmployeeWorkPartTimePRN = respiratoryProtectionForms.EmployeeWorkPartTimePRN,
        //        //                                CreatedBy = respiratoryProtectionForms.CreatedBy,
        //        //                                Created = respiratoryProtectionForms.Created,
        //        //                                ModifiedBy = respiratoryProtectionForms.ModifiedBy,
        //        //                                Modified = respiratoryProtectionForms.Modified,
        //        //                            }).Where(a=>a.FormId == formId).FirstOrDefault();
        //        return eCRespiratoryProtections;
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Failed to get GetFormById: " + ex);
        //    }
        //    return new ECRespiratoryProtectionFormViewModel();
        //}

        //public async Task<List<ECRespiratoryProtectionWaivedReasonViewModel>> GetWaivedReasons()
        //{
        //    List<ECRespiratoryProtectionWaivedReasonViewModel> eCRespiratoryProtectionWaivedReasons = new List<ECRespiratoryProtectionWaivedReasonViewModel>();
        //    try
        //    {
        //        var waivedReasons = _context.ECRespiratoryProtectionWaivedReasons.ToList();
        //        AutoMapper.Mapper.CreateMap<ECRespiratoryProtectionWaivedReasonViewModel, ECRespiratoryProtectionWaivedReason>();
        //        eCRespiratoryProtectionWaivedReasons = AutoMapper.Mapper.Map<List<ECRespiratoryProtectionWaivedReason>, List<ECRespiratoryProtectionWaivedReasonViewModel>>(waivedReasons);
        //        return eCRespiratoryProtectionWaivedReasons;
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Failed to get GetWaivedReasons: " + ex);
        //    }
        //    return eCRespiratoryProtectionWaivedReasons;
        //}

        //public async Task<bool> CreateWaivedReason(ECRespiratoryProtectionWaivedReasonViewModel model)
        //{
        //    try
        //    {
        //        ECRespiratoryProtectionWaivedReason wr = new ECRespiratoryProtectionWaivedReason
        //        {
        //            Reason = model.NewReason,
        //            IsActive = true
        //        };
        //        _context.ECRespiratoryProtectionWaivedReasons.Add(wr);
        //        _context.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Failed to CreateWaivedReason: " + ex);
        //        return false;
        //    }
        //    return true;
        //}

        //public async Task<bool> UpdateWaivedReason(int id, string reason, bool active)
        //{
        //    try
        //    {
        //        var waivedReason = _context.ECRespiratoryProtectionWaivedReasons.FirstOrDefault(x => x.WaivedReasonId == id);
        //        waivedReason.Reason = reason;
        //        waivedReason.IsActive = active;
        //        _context.SaveChanges();

        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Error updating existing reason record - UpdateWaivedReason  :  " + ex);
        //        return false;
        //    }

        //    return true;
        //}
    }
}
