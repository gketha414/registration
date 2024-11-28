using AutoMapper;
using Microsoft.AspNetCore.Http;
using PreRegistration.Models;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.UI;
using PreRegistration.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.IO;
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
        EmailHelper _emailHelper;

        public PreRegistrationDAL()
        {
            _context = new PatientPreRegistrationEntities();
            _emailHelper = new EmailHelper();
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

                patientModel.Race.Add(new SelectListItem { Text = "-- Select Race --", Value = "0" });
                patientModel.Race.AddRange(_context.Races.Select(x => new SelectListItem { Text = x.Description, Value = x.RaceID.ToString() }));

                patientModel.MaritalStatus.Add(new SelectListItem { Text = "-- Select Marital Status --", Value = "0" });
                patientModel.MaritalStatus.AddRange(_context.MaritalStatus.Select(x => new SelectListItem { Text = x.Description, Value = x.ID.ToString() }));

                patientModel.YesNo.Add("Yes");
                patientModel.YesNo.Add("No");

                foreach (var service in _context.HospitalServices)
                {
                    patientModel.HospitalService.Add(service.Description);
                }

                foreach (var birth in _context.BirthGenders)
                {
                    patientModel.Gender.Add(birth.Description);
                }

                patientModel.CurrentlyIdentifyAs.Add(new SelectListItem { Text = "-- Select Currently Identify As --", Value = "0" });
                patientModel.CurrentlyIdentifyAs.AddRange(_context.Genders.Select(x => new SelectListItem { Text = x.Name, Value = x.GenderID.ToString() }).ToList());

                patientModel.Guarantors.Add(new SelectListItem { Text = "-- Select Guarantor --", Value = "0" });
                patientModel.Guarantors.AddRange(_context.ResponsibleParties.Select(x => new SelectListItem { Text = x.ResponsiblePartyDescription, Value = x.ResponsiblePartyID.ToString() }).ToList());

                patientModel.FilteredGuarantors.Add(new SelectListItem { Text = "-- Select Guarantor --", Value = "0" });
                patientModel.FilteredGuarantors.AddRange(_context.ResponsibleParties.Where(a => a.ResponsiblePartyID != 4 && a.ResponsiblePartyID != 5).Select(x => new SelectListItem { Text = x.ResponsiblePartyDescription, Value = x.ResponsiblePartyID.ToString() }).ToList());

                var accidentTypes = _context.AccidentTypes.ToList();
                foreach (var type in accidentTypes)
                {
                    patientModel.AccidentTypes.Add(type.AccidentTypeID, type.Description);
                }

                List<SelectListItem> display = new List<SelectListItem>
                {
                    new SelectListItem { Text = "-- Select Display View --", Value = "0" },
                    new SelectListItem { Text = "New Online Registrations", Value = "1" },
                    new SelectListItem { Text = "Registrations Processed", Value = "2" },
                };

                patientModel.AttachmentTypes.Add(new SelectListItem { Text = "-- Select File Type --", Value = "0" });
                patientModel.AttachmentTypes.AddRange(_context.AttachmentTypes.Select(x => new SelectListItem { Text = x.AttachmentType1, Value = x.ID.ToString() }).ToList());

                patientModel.Ethincities.Add(new SelectListItem { Text = "-- Select Ethincity --", Value = "0" });
                patientModel.Ethincities.AddRange(_context.Ethnicities.Select(x => new SelectListItem { Text = x.Description, Value = x.EthnicityID.ToString() }).ToList());

                patientModel.PateintDisplayViewData.AddRange(display);

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

        //public async Task<bool> SubmitPreRegistrationForm(PatientViewModel patientViewModel)
        //{
        //    try
        //    {
        //        //SendEmails sendEmails = new SendEmails();
        //        int patientId = 0;
        //        if (patientViewModel.PatientDemographicsViewModel != null)
        //        {
        //            PatientDemographic patientDemographic = new PatientDemographic
        //            {
        //                HospitalID = patientViewModel.PatientDemographicsViewModel.HospitalID,
        //                In_Hospital_Directory = patientViewModel.PatientDemographicsViewModel.In_Hospital_Directory,
        //                HospitalService = patientViewModel.PatientDemographicsViewModel.HospitalService,
        //                PrimaryCarePhys = patientViewModel.PatientDemographicsViewModel.PrimaryCarePhys,
        //                AdmitDate = Convert.ToDateTime(patientViewModel.PatientDemographicsViewModel.AdmitDate),
        //                PatientHereBefore = patientViewModel.PatientDemographicsViewModel.PatientHereBefore,
        //                First_Name = patientViewModel.PatientDemographicsViewModel.First_Name,
        //                Middle_Name = patientViewModel.PatientDemographicsViewModel.Middle_Name,
        //                Last_Name = patientViewModel.PatientDemographicsViewModel.Last_Name,
        //                Entitlement = patientViewModel.PatientDemographicsViewModel.Entitlement,
        //                Gender = patientViewModel.PatientDemographicsViewModel.Gender,
        //                Address1 = patientViewModel.PatientDemographicsViewModel.Address1,
        //                Address2 = patientViewModel.PatientDemographicsViewModel.Address2,
        //                City = patientViewModel.PatientDemographicsViewModel.City,
        //                StateProvince = patientViewModel.PatientDemographicsViewModel.StateProvince,
        //                ZipCode = patientViewModel.PatientDemographicsViewModel.ZipCode,
        //                BirthDate = patientViewModel.PatientDemographicsViewModel.BirthDate,
        //                Race = patientViewModel.PatientDemographicsViewModel.Race,
        //                Marital_Status = patientViewModel.PatientDemographicsViewModel.Marital_Status,
        //                SSN = patientViewModel.PatientDemographicsViewModel.SSN,
        //                Home_Phone = patientViewModel.PatientDemographicsViewModel.Home_Phone != null ? (long)patientViewModel.PatientDemographicsViewModel.Home_Phone : 0,
        //                Cell_Phone = patientViewModel.PatientDemographicsViewModel.Cell_Phone,
        //                Email_Address = patientViewModel.PatientDemographicsViewModel.Email_Address,
        //                Church_Choice = patientViewModel.PatientDemographicsViewModel.Church_Choice,

        //                Mailing_Address1 = patientViewModel.PatientDemographicsViewModel.Mailing_Address1,
        //                Mailing_Address2 = patientViewModel.PatientDemographicsViewModel.Mailing_Address2,
        //                MailingCity = patientViewModel.PatientDemographicsViewModel.MailingCity,
        //                MailingState = patientViewModel.PatientDemographicsViewModel.MailingState,
        //                MailingZip = patientViewModel.PatientDemographicsViewModel.MailingZip,

        //                E911Address1 = patientViewModel.PatientDemographicsViewModel.E911Address1,
        //                E911Address2 = patientViewModel.PatientDemographicsViewModel.E911Address2,
        //                E911City = patientViewModel.PatientDemographicsViewModel.E911City,
        //                E911State = patientViewModel.PatientDemographicsViewModel.E911State,
        //                E911Zip = patientViewModel.PatientDemographicsViewModel.E911Zip,

        //                ResponsiblePartyID = patientViewModel.PatientDemographicsViewModel.ResponsiblePartyID,
        //                GuarNameIfOther = patientViewModel.PatientDemographicsViewModel.GuarNameIfOther,

        //                Bill_Address1 = patientViewModel.PatientDemographicsViewModel.Bill_Address1,
        //                Bill_Address2 = patientViewModel.PatientDemographicsViewModel.Bill_Address2,
        //                Bill_City = patientViewModel.PatientDemographicsViewModel.Bill_City, // Corrected
        //                Bill_State = patientViewModel.PatientDemographicsViewModel.Bill_State,
        //                Bill_ZipCode = patientViewModel.PatientDemographicsViewModel.Bill_ZipCode,

        //                Employer = patientViewModel.PatientDemographicsViewModel.Employer,
        //                Job_Title = patientViewModel.PatientDemographicsViewModel.Job_Title,
        //                EmployerAddress1 = patientViewModel.PatientDemographicsViewModel.EmployerAddress1,
        //                EmployerAddress2 = patientViewModel.PatientDemographicsViewModel.EmployerAddress2,
        //                EmployerCity = patientViewModel.PatientDemographicsViewModel.EmployerCity,
        //                EmployerState = patientViewModel.PatientDemographicsViewModel.EmployerState,
        //                EmployerZip = patientViewModel.PatientDemographicsViewModel.EmployerZip,
        //                EmployerPhone = patientViewModel.PatientDemographicsViewModel.EmployerPhone,
        //                Status = "Processed",

        //                SectionID = 1,
        //                Created = DateTime.Now,
        //            };

        //            _context.PatientDemographics.Add(patientDemographic);
        //            await _context.SaveChangesAsync();

        //            patientId = patientDemographic.PersonID;

        //            //_emailHelper.SendEmailToAdmin(patientViewModel.PatientDemographicsViewModel, patientId);
        //            //_emailHelper.SendEmailToPatient(patientViewModel.PatientDemographicsViewModel, patientId);

        //            if (!patientViewModel.SpouseInformation.SpouseSkip)
        //            {
        //                patientViewModel.SpouseInformation.PersonID = patientId;
        //                await SubmitSpouseInfo(patientViewModel.SpouseInformation);
        //            }

        //            if (!patientViewModel.MinorInformation.MinorSKip )
        //            {    
        //                patientViewModel.MinorInformation.FatherMinorInformation.PersonID = patientId;
        //                patientViewModel.MinorInformation.MontherMinorInformation.PersonID = patientId;
        //                patientViewModel.MinorInformation.FatherMinorInformation.ResponsiblePartyID = patientViewModel.MinorInformation.MontherMinorInformation.ResponsiblePartyID;

                        
        //                await SubmitMinorInfo(patientViewModel.MinorInformation);
        //            }

        //            if (!patientViewModel.EmergencyContact.EmergencySkip)
        //            {
        //                patientViewModel.EmergencyContact.EmergencyContactOne.PersonID = patientId;
        //                patientViewModel.EmergencyContact.EmergencyContactTwo.PersonID = patientId;
        //                patientViewModel.EmergencyContact.EmergencyContactThree.PersonID = patientId;
        //                await SubmitEmergencyContact(patientViewModel.EmergencyContact);
        //            }

        //            if (!patientViewModel.InsuranceInformation.InsuranceSkip)
        //            {
        //                patientViewModel.InsuranceInformation.InsuranceOne.PersonID = patientId;
        //                patientViewModel.InsuranceInformation.InsuranceTwo.PersonID = patientId;
        //                patientViewModel.InsuranceInformation.InsuranceThree.PersonID = patientId;

        //                await SubmitInsuranceInfo(patientViewModel.InsuranceInformation);
        //            }

        //            if (!patientViewModel.AccidentDetail.AccidentSkip)
        //            {
        //                patientViewModel.AccidentDetail.PersonID = patientId;
        //                await SubmitAccidentDetail(patientViewModel.AccidentDetail);
        //            }
        //        }

        //        return true;
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        foreach (var validationErrors in dbEx.EntityValidationErrors)
        //        {
        //            foreach (var validationError in validationErrors.ValidationErrors)
        //            {
        //                _log.Log("Validation error on SubmitPreRegistrationForm function in PreRegistrationDAL: " + validationError.PropertyName + ". " + validationError.ErrorMessage);
        //            }
        //        }
        //        return false;
        //        throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
        //    }
        //    catch (Exception ex)
        //    {
        //        _log.Log("Failed to get SubmitPreRegistrationForm: " + ex);
        //        return false;
        //    }
        //}

        public async Task<int> SubmitPatientDetail(PatientViewModel patientViewModel, int personId)
        {
            try
            {
                // Get the existing patient if the personId is not 0
                PatientDemographic patientDemographic = personId == 0
                    ? new PatientDemographic()
                    : await _context.PatientDemographics.FirstOrDefaultAsync(p => p.PersonID == personId);

                // If the patient doesn't exist and personId isn't 0, throw an exception
                if (personId != 0 && patientDemographic == null)
                {
                    throw new Exception("Patient not found");
                }

                // Populate patientDemographic fields
                patientDemographic.HospitalID = patientViewModel.PatientDemographicsViewModel.HospitalID;
                patientDemographic.In_Hospital_Directory = patientViewModel.PatientDemographicsViewModel.In_Hospital_Directory;
                patientDemographic.HospitalService = patientViewModel.PatientDemographicsViewModel.HospitalService;
                patientDemographic.PrimaryCarePhys = patientViewModel.PatientDemographicsViewModel.PrimaryCarePhys;
                patientDemographic.AdmitDate = Convert.ToDateTime(patientViewModel.PatientDemographicsViewModel.AdmitDate);
                patientDemographic.PatientHereBefore = patientViewModel.PatientDemographicsViewModel.PatientHereBefore;
                patientDemographic.First_Name = patientViewModel.PatientDemographicsViewModel.First_Name;
                patientDemographic.Middle_Name = patientViewModel.PatientDemographicsViewModel.Middle_Name;
                patientDemographic.Last_Name = patientViewModel.PatientDemographicsViewModel.Last_Name;
                patientDemographic.Entitlement = patientViewModel.PatientDemographicsViewModel.Entitlement;
                patientDemographic.Gender = patientViewModel.PatientDemographicsViewModel.Gender;
                patientDemographic.Address1 = patientViewModel.PatientDemographicsViewModel.Address1;
                patientDemographic.Address2 = patientViewModel.PatientDemographicsViewModel.Address2;
                patientDemographic.City = patientViewModel.PatientDemographicsViewModel.City;
                patientDemographic.StateProvince = patientViewModel.PatientDemographicsViewModel.StateProvince;
                patientDemographic.ZipCode = patientViewModel.PatientDemographicsViewModel.ZipCode;
                patientDemographic.BirthDate = patientViewModel.PatientDemographicsViewModel.BirthDate;
                patientDemographic.Race = patientViewModel.PatientDemographicsViewModel.Race;
                patientDemographic.Marital_Status = patientViewModel.PatientDemographicsViewModel.Marital_Status;
                patientDemographic.SSN = patientViewModel.PatientDemographicsViewModel.SSN;
                patientDemographic.Home_Phone = patientViewModel.PatientDemographicsViewModel.Home_Phone != null ? (long)patientViewModel.PatientDemographicsViewModel.Home_Phone : 0;
                patientDemographic.Cell_Phone = patientViewModel.PatientDemographicsViewModel.Cell_Phone;
                patientDemographic.Email_Address = patientViewModel.PatientDemographicsViewModel.Email_Address;
                patientDemographic.Church_Choice = patientViewModel.PatientDemographicsViewModel.Church_Choice;

                patientDemographic.Mailing_Address1 = patientViewModel.PatientDemographicsViewModel.Mailing_Address1;
                patientDemographic.Mailing_Address2 = patientViewModel.PatientDemographicsViewModel.Mailing_Address2;
                patientDemographic.MailingCity = patientViewModel.PatientDemographicsViewModel.MailingCity;
                patientDemographic.MailingState = patientViewModel.PatientDemographicsViewModel.MailingState;
                patientDemographic.MailingZip = patientViewModel.PatientDemographicsViewModel.MailingZip;

                patientDemographic.E911Address1 = patientViewModel.PatientDemographicsViewModel.E911Address1;
                patientDemographic.E911Address2 = patientViewModel.PatientDemographicsViewModel.E911Address2;
                patientDemographic.E911City = patientViewModel.PatientDemographicsViewModel.E911City;
                patientDemographic.E911State = patientViewModel.PatientDemographicsViewModel.E911State;
                patientDemographic.E911Zip = patientViewModel.PatientDemographicsViewModel.E911Zip;

                patientDemographic.ResponsiblePartyID = patientViewModel.PatientDemographicsViewModel.ResponsiblePartyID;
                patientDemographic.GuarNameIfOther = patientViewModel.PatientDemographicsViewModel.GuarNameIfOther;

                patientDemographic.Bill_Address1 = patientViewModel.PatientDemographicsViewModel.Bill_Address1;
                patientDemographic.Bill_Address2 = patientViewModel.PatientDemographicsViewModel.Bill_Address2;
                patientDemographic.Bill_City = patientViewModel.PatientDemographicsViewModel.Bill_City;
                patientDemographic.Bill_State = patientViewModel.PatientDemographicsViewModel.Bill_State;
                patientDemographic.Bill_ZipCode = patientViewModel.PatientDemographicsViewModel.Bill_ZipCode;

                patientDemographic.Employer = patientViewModel.PatientDemographicsViewModel.Employer;
                patientDemographic.Job_Title = patientViewModel.PatientDemographicsViewModel.Job_Title;
                patientDemographic.EmployerAddress1 = patientViewModel.PatientDemographicsViewModel.EmployerAddress1;
                patientDemographic.EmployerAddress2 = patientViewModel.PatientDemographicsViewModel.EmployerAddress2;
                patientDemographic.EmployerCity = patientViewModel.PatientDemographicsViewModel.EmployerCity;
                patientDemographic.EmployerState = patientViewModel.PatientDemographicsViewModel.EmployerState;
                patientDemographic.EmployerZip = patientViewModel.PatientDemographicsViewModel.EmployerZip;
                patientDemographic.EmployerPhone = patientViewModel.PatientDemographicsViewModel.EmployerPhone;
                patientDemographic.Status = "Processed";
                patientDemographic.Modified = DateTime.Now;

                patientDemographic.SectionID = 1;
                patientDemographic.Created = DateTime.Now;

                // Add new record or update the existing one
                if (personId == 0)
                {
                    _context.PatientDemographics.Add(patientDemographic);
                }
                else
                {
                    
                    _context.PatientDemographics.AddOrUpdate(patientDemographic);
                }

                await _context.SaveChangesAsync();

                return patientDemographic.PersonID;
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
                return 0;
                throw new Exception("Unable to Submit form. If this problem continues please contact your system admin.");
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitPreRegistrationForm: " + ex);
                return 0;
            }
        }

        public async Task<int> SubmitSpouseInfo(SpouseInformationViewModel spouseInformation, int updateId)
        {
            try
            {
                // Check if SpouseSkip is true
                if (spouseInformation.SpouseSkip)
                {
                    // If updateId is not zero, delete the existing record
                    if (updateId != 0)
                    {
                        var spousedetail = await _context.SpouseInformations.FindAsync(updateId);
                        if (spousedetail != null)
                        {
                            _context.SpouseInformations.Remove(spousedetail);
                            await _context.SaveChangesAsync();
                        }
                    }
                    // If SpouseSkip is true and updateId is zero, just return 0
                    return 0;
                }

                // Proceed with normal logic if SpouseSkip is false

                SpouseInformation spouse;

                if (updateId != 0)
                {
                    // Update existing record
                    spouse = await _context.SpouseInformations.FindAsync(updateId);

                    if (spouse == null)
                    {
                        throw new Exception("Spouse record not found.");
                    }
                }
                else
                {
                    // Insert new record
                    spouse = new SpouseInformation();
                    _context.SpouseInformations.Add(spouse);
                }

                // Populate properties
                spouse.First_Name = spouseInformation.First_Name;
                spouse.Middle_Name = spouseInformation.Middle_Name;
                spouse.Last_Name = spouseInformation.Last_Name;
                spouse.Address1 = spouseInformation.Address1;
                spouse.Address2 = spouseInformation.Address2;
                spouse.City = spouseInformation.City;
                spouse.StateProvince = spouseInformation.StateProvince;
                spouse.ZipCode = spouseInformation.ZipCode;
                spouse.BirthDate = spouseInformation.BirthDate;
                spouse.Race = spouseInformation.Race;
                spouse.Marital_Status = spouseInformation.Marital_Status;
                spouse.SSN = spouseInformation.SSN;
                spouse.Home_Phone = spouseInformation.Home_Phone;
                spouse.Cell_Phone = spouseInformation.Cell_Phone;
                spouse.Employer = spouseInformation.Employer;
                spouse.Job_Title = spouseInformation.Job_Title;
                spouse.EmployerAddress1 = spouseInformation.EmployerAddress1;
                spouse.EmployerAddress2 = spouseInformation.EmployerAddress2;
                spouse.EmployerCity = spouseInformation.EmployerCity;
                spouse.EmployerState = spouseInformation.EmployerState;
                spouse.EmployerZip = spouseInformation.EmployerZip;
                spouse.Employer_Phone = spouseInformation.Employer_Phone;
                spouse.PersonID = spouseInformation.PersonID;

                await _context.SaveChangesAsync();

                // Return the newly created Id or the updateId
                return updateId != 0 ? updateId : spouse.SpouseID;
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
                return 0;
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitSpouseInfo: " + ex);
                return 0;
            }
        }

        public async Task<Dictionary<string, int>> SubmitMinorInfo(MinorInformationViewModel minorInformation, int motherId, int fatherId)
        {
            try
            {
                var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MinorViewModel, MinorInformation>();
                });
                var mapper = config.CreateMapper();

                MinorInformation motherModel = null;
                MinorInformation fatherModel = null;
                bool motherCreated = false;
                bool fatherCreated = false;

                // Check if MinorSkip is true
                if (minorInformation.MinorSKip)
                {
                    // If any minor record ID is not zero, delete the corresponding record
                    if (motherId != 0)
                    {
                        var contactMother = await _context.MinorInformations.FindAsync(motherId);
                        if (contactMother != null)
                        {
                            _context.MinorInformations.Remove(contactMother);
                        }
                    }
                    if (fatherId != 0)
                    {
                        var contactFather = await _context.MinorInformations.FindAsync(fatherId);
                        if (contactFather != null)
                        {
                            _context.MinorInformations.Remove(contactFather);
                        }
                    }

                    // Save changes to delete records
                    await _context.SaveChangesAsync();

                    // Return result with zeroed IDs after deletion
                    return new Dictionary<string, int> { { "MotherId", 0 }, { "FatherId", 0 } };
                }

                // Proceed with normal logic if MinorSkip is false

                // Check and handle mother record
                if (motherId != 0)
                {
                    // Find existing mother record
                    motherModel = await _context.MinorInformations.FindAsync(motherId);
                    if (motherModel == null)
                    {
                        throw new Exception("Mother record not found.");
                    }

                    if (string.IsNullOrEmpty(minorInformation.MontherMinorInformation.First_Name))
                    {
                        // Delete if First_Name is null or empty
                        _context.MinorInformations.Remove(motherModel);
                    }
                    else
                    {
                        // Update if First_Name is present
                        mapper.Map(minorInformation.MontherMinorInformation, motherModel);
                    }
                }
                else if (!string.IsNullOrEmpty(minorInformation.MontherMinorInformation.First_Name))
                {
                    // Create new mother record if necessary
                    motherModel = mapper.Map<MinorViewModel, MinorInformation>(minorInformation.MontherMinorInformation);
                    _context.MinorInformations.Add(motherModel);
                    motherCreated = true;
                }

                // Check and handle father record
                if (fatherId != 0)
                {
                    // Find existing father record
                    fatherModel = await _context.MinorInformations.FindAsync(fatherId);
                    if (fatherModel == null)
                    {
                        throw new Exception("Father record not found.");
                    }

                    if (string.IsNullOrEmpty(minorInformation.FatherMinorInformation.First_Name))
                    {
                        // Delete if First_Name is null or empty
                        _context.MinorInformations.Remove(fatherModel);
                    }
                    else
                    {
                        // Update if First_Name is present
                        mapper.Map(minorInformation.FatherMinorInformation, fatherModel);
                    }
                }
                else if (!string.IsNullOrEmpty(minorInformation.FatherMinorInformation.First_Name))
                {
                    // Create new father record if necessary
                    fatherModel = mapper.Map<MinorViewModel, MinorInformation>(minorInformation.FatherMinorInformation);
                    _context.MinorInformations.Add(fatherModel);
                    fatherCreated = true;
                }

                await _context.SaveChangesAsync();

                // Prepare return dictionary with IDs of mother and father
                var result = new Dictionary<string, int>
        {
            { "MotherId", motherCreated ? motherModel.MinorID : (motherId != 0 ? motherId : 0) },
            { "FatherId", fatherCreated ? fatherModel.MinorID : (fatherId != 0 ? fatherId : 0) }
        };

                return result;
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
                return new Dictionary<string, int> { { "MotherId", 0 }, { "FatherId", 0 } };
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitMinorInfo: " + ex);
                return new Dictionary<string, int> { { "MotherId", 0 }, { "FatherId", 0 } };
            }
        }

        public async Task<Dictionary<string, int>> SubmitEmergencyContact(
     EmergencyContactViewModel emergencyContact,
     int emergencyContactOneId,
     int emergencyContactTwoId,
     int emergencyContactThreeId)
        {
            try
            {
                // Initialize result dictionary to store EmergContactID after operation
                var result = new Dictionary<string, int>
        {
            { "EmergencyContactOneEmergContactID", 0 },
            { "EmergencyContactTwoEmergContactID", 0 },
            { "EmergencyContactThreeEmergContactID", 0 }
        };

                // Check if EmergencySkip is true
                if (emergencyContact.EmergencySkip)
                {
                    // If any emergency contact ID is not zero, delete the corresponding record
                    if (emergencyContactOneId != 0)
                    {
                        var contactOne = await _context.EmergencyContacts.FindAsync(emergencyContactOneId);
                        if (contactOne != null)
                        {
                            _context.EmergencyContacts.Remove(contactOne);
                        }
                    }
                    if (emergencyContactTwoId != 0)
                    {
                        var contactTwo = await _context.EmergencyContacts.FindAsync(emergencyContactTwoId);
                        if (contactTwo != null)
                        {
                            _context.EmergencyContacts.Remove(contactTwo);
                        }
                    }
                    if (emergencyContactThreeId != 0)
                    {
                        var contactThree = await _context.EmergencyContacts.FindAsync(emergencyContactThreeId);
                        if (contactThree != null)
                        {
                            _context.EmergencyContacts.Remove(contactThree);
                        }
                    }

                    // Save changes to remove records from the database
                    await _context.SaveChangesAsync();

                    // Return result IDs with 0s after deletion
                    return result; // No further processing required, return early
                }

                // Proceed with existing logic if EmergencySkip is false

                // Process EmergencyContactOne
                if (emergencyContactOneId != 0)
                {
                    var contactOne = await _context.EmergencyContacts.FindAsync(emergencyContactOneId);
                    if (contactOne == null)
                        throw new Exception("EmergencyContactOne record not found.");

                    if (string.IsNullOrEmpty(emergencyContact.EmergencyContactOne.Nearest_Relative_Name))
                    {
                        // Delete if Nearest_Relative_Name is empty
                        _context.EmergencyContacts.Remove(contactOne);
                    }
                    else
                    {
                        // Update if Nearest_Relative_Name is present
                        emergencyContact.EmergencyContactOne.EmergContactID = contactOne.EmergContactID;
                        contactOne = emergencyContact.EmergencyContactOne;
                        result["EmergencyContactOneEmergContactID"] = contactOne.EmergContactID; // Use EmergContactID after update
                    }
                }
                else if (!string.IsNullOrEmpty(emergencyContact.EmergencyContactOne.Nearest_Relative_Name))
                {
                    // Create new contact if necessary
                    _context.EmergencyContacts.Add(emergencyContact.EmergencyContactOne);
                    await _context.SaveChangesAsync(); // Save to get new EmergContactID
                    result["EmergencyContactOneEmergContactID"] = emergencyContact.EmergencyContactOne.EmergContactID; // Get new EmergContactID after save
                }

                // Process EmergencyContactTwo
                if (emergencyContactTwoId != 0)
                {
                    var contactTwo = await _context.EmergencyContacts.FindAsync(emergencyContactTwoId);
                    if (contactTwo == null)
                        throw new Exception("EmergencyContactTwo record not found.");

                    if (string.IsNullOrEmpty(emergencyContact.EmergencyContactTwo.Nearest_Relative_Name))
                    {
                        // Delete if Nearest_Relative_Name is empty
                        _context.EmergencyContacts.Remove(contactTwo);
                    }
                    else
                    {
                        // Update if Nearest_Relative_Name is present
                        emergencyContact.EmergencyContactTwo.EmergContactID = contactTwo.EmergContactID;
                        contactTwo = emergencyContact.EmergencyContactTwo;
                        result["EmergencyContactTwoEmergContactID"] = contactTwo.EmergContactID; // Use EmergContactID after update
                    }
                }
                else if (!string.IsNullOrEmpty(emergencyContact.EmergencyContactTwo.Nearest_Relative_Name))
                {
                    // Create new contact if necessary
                    _context.EmergencyContacts.Add(emergencyContact.EmergencyContactTwo);
                    await _context.SaveChangesAsync(); // Save to get new EmergContactID
                    result["EmergencyContactTwoEmergContactID"] = emergencyContact.EmergencyContactTwo.EmergContactID; // Get new EmergContactID after save
                }

                // Process EmergencyContactThree
                if (emergencyContactThreeId != 0)
                {
                    var contactThree = await _context.EmergencyContacts.FindAsync(emergencyContactThreeId);
                    if (contactThree == null)
                        throw new Exception("EmergencyContactThree record not found.");

                    if (string.IsNullOrEmpty(emergencyContact.EmergencyContactThree.Nearest_Relative_Name))
                    {
                        // Delete if Nearest_Relative_Name is empty
                        _context.EmergencyContacts.Remove(contactThree);
                    }
                    else
                    {
                        // Update if Nearest_Relative_Name is present
                        emergencyContact.EmergencyContactThree.EmergContactID = contactThree.EmergContactID;
                        contactThree = emergencyContact.EmergencyContactThree;
                        result["EmergencyContactThreeEmergContactID"] = contactThree.EmergContactID; // Use EmergContactID after update
                    }
                }
                else if (!string.IsNullOrEmpty(emergencyContact.EmergencyContactThree.Nearest_Relative_Name))
                {
                    // Create new contact if necessary
                    _context.EmergencyContacts.Add(emergencyContact.EmergencyContactThree);
                    await _context.SaveChangesAsync(); // Save to get new EmergContactID
                    result["EmergencyContactThreeEmergContactID"] = emergencyContact.EmergencyContactThree.EmergContactID; // Get new EmergContactID after save
                }

                await _context.SaveChangesAsync(); // Final save after all operations

                return result;
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
                return new Dictionary<string, int> { { "EmergencyContactOneEmergContactID", 0 }, { "EmergencyContactTwoEmergContactID", 0 }, { "EmergencyContactThreeEmergContactID", 0 } };
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitEmergencyContact: " + ex);
                return new Dictionary<string, int> { { "EmergencyContactOneEmergContactID", 0 }, { "EmergencyContactTwoEmergContactID", 0 }, { "EmergencyContactThreeEmergContactID", 0 } };
            }
        }


        public async Task<string> SaveFileAndReturnUrlAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return "nl";

            // Define the folder path
            string uploadsFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads");

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Create a unique file name
            string uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            // Save the file to the server
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            // Generate a URL to access the file
            string fileUrl = $"{uploadsFolder}/{uniqueFileName}";

            // Save the URL to the database


            return fileUrl;
        }
        public async Task<Dictionary<string, int>> SubmitInsuranceInfo(InsuranceMultipleViewModel insuranceInformation, int insuranceid1, int insuranceid2, int insuranceid3)
        {
            try
            {
                var resultIds = new Dictionary<string, int> { { "InsId1", 0 }, { "InsId2", 0 }, { "InsId3", 0 } };

                if (insuranceInformation.InsuranceSkip)
                {
                    if (insuranceid1 != 0)
                    {
                        var record1 = await _context.InsuranceInformations.FindAsync(insuranceid1);
                        if (record1 != null)
                            _context.InsuranceInformations.Remove(record1);
                    }

                    if (insuranceid2 != 0)
                    {
                        var record2 = await _context.InsuranceInformations.FindAsync(insuranceid2);
                        if (record2 != null)
                            _context.InsuranceInformations.Remove(record2);
                    }

                    if (insuranceid3 != 0)
                    {
                        var record3 = await _context.InsuranceInformations.FindAsync(insuranceid3);
                        if (record3 != null)
                            _context.InsuranceInformations.Remove(record3);
                    }

                    await _context.SaveChangesAsync();
                    return resultIds;
                }

                var config = new MapperConfiguration(cfg => cfg.CreateMap<InsuranceInformationViewModel, InsuranceInformation>());
                var mapper = config.CreateMapper();

                async Task ProcessInsurance(InsuranceInformationViewModel insuranceViewModel, int insuranceId, string insIdKey)
                {
                    InsuranceInformation model = new InsuranceInformation();

                    if (insuranceId != 0)
                    {
                        model = await _context.InsuranceInformations.FindAsync(insuranceId);
                        if (insuranceViewModel.InsRank == 0)
                        {
                            if (model != null)
                            {
                                var existingAttachments = _context.InsuranceAttachments.Where(a => a.InsId == model.InsId).ToList();

                                _context.InsuranceAttachments.RemoveRange(existingAttachments);
                                _context.InsuranceInformations.Remove(model);
                                await _context.SaveChangesAsync();
                            }
                            return;
                        }

                        if (model != null)
                        {
                            model = mapper.Map(insuranceViewModel, model);
                            _context.InsuranceInformations.AddOrUpdate(model);
                            await _context.SaveChangesAsync();
                            resultIds[insIdKey] = model.InsId;
                        }
                        else
                        {
                            model = mapper.Map<InsuranceInformation>(insuranceViewModel);
                            _context.InsuranceInformations.Add(model);
                            await _context.SaveChangesAsync();
                            resultIds[insIdKey] = model.InsId;
                        }
                    }
                    else if (insuranceViewModel.InsRank != 0)
                    {
                        model = mapper.Map<InsuranceInformation>(insuranceViewModel);
                        _context.InsuranceInformations.Add(model);
                        await _context.SaveChangesAsync();
                        resultIds[insIdKey] = model.InsId;
                    }

                    if (insuranceViewModel.Attachment != null && model.InsId != 0)
                    {
                        var existingAttachments = _context.InsuranceAttachments.Where(a => a.InsId == model.InsId).ToList();
                       
                        _context.InsuranceAttachments.RemoveRange(existingAttachments);
                        foreach (var fileName in insuranceViewModel.AttachmentList)
                        {
                            var attachment = new InsuranceAttachment
                            {
                                InsId = model.InsId,
                                PersonId = model.PersonID,
                                FileName = fileName
                            };
                            _context.InsuranceAttachments.Add(attachment);
                        }
                        await _context.SaveChangesAsync();
                    }else if (model.InsId != 0)
                    {
                        var existingAttachments = _context.InsuranceAttachments.Where(a => a.InsId == model.InsId).ToList();

                        _context.InsuranceAttachments.RemoveRange(existingAttachments);
                        await _context.SaveChangesAsync();
                    }
                }

                await ProcessInsurance(insuranceInformation.InsuranceOne, insuranceid1, "InsId1");
                await ProcessInsurance(insuranceInformation.InsuranceTwo, insuranceid2, "InsId2");
                await ProcessInsurance(insuranceInformation.InsuranceThree, insuranceid3, "InsId3");

                return resultIds;
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
                return new Dictionary<string, int> { { "InsId1", 0 }, { "InsId2", 0 }, { "InsId3", 0 } };
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get SubmitInsuranceInfo: " + ex);
                return new Dictionary<string, int> { { "InsId1", 0 }, { "InsId2", 0 }, { "InsId3", 0 } };
            }
        }

        public async Task<int> SubmitAccidentDetail(AccidentDetailViewModel accidentDetailViewModel, int updateId)
        {
            if (accidentDetailViewModel == null)
            {
                _log.Log("SubmitAccidentDetailAsync: Provided AccidentDetailViewModel is null.");
                return 0;
            }

            try
            {
                // Map the ViewModel to a new instance of AccidentDetail
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AccidentDetailViewModel, AccidentDetail>());
                var mapper = config.CreateMapper();
                var model = mapper.Map<AccidentDetail>(accidentDetailViewModel);

                // 1. Check if AccidentSkip is true and updateId is not zero, delete and return 0
                if (accidentDetailViewModel.AccidentSkip && updateId != 0)
                {
                    var existingModel = await _context.AccidentDetails.FindAsync(updateId);
                    if (existingModel != null)
                    {
                        _context.AccidentDetails.Remove(existingModel);
                        await _context.SaveChangesAsync();
                        _log.Log("Record deleted due to AccidentSkip flag being true for updateId: " + updateId);
                    }
                    return 0;
                }

                // 2. Check if AccidentSkip is true and updateId is zero, return 0
                if (accidentDetailViewModel.AccidentSkip && updateId == 0)
                {
                    _log.Log("AccidentSkip is true and updateId is 0, returning without saving.");
                    return 0;
                }

                // 3. Check if AccidentSkip is false and updateId is not zero, update the record
                if (!accidentDetailViewModel.AccidentSkip && updateId != 0)
                {
                    var existingModel = await _context.AccidentDetails.FindAsync(updateId);
                    if (existingModel == null)
                    {
                        _log.Log("AccidentDetail record not found for updateId: " + updateId);
                        return 0;
                    }

                    // Map updated properties from the ViewModel to the existing model
                    mapper.Map(accidentDetailViewModel, existingModel);
                    _context.Entry(existingModel).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return existingModel.AccidentDetailID;
                }

                // 4. Check if AccidentSkip is false and updateId is zero, create a new record
                if (!accidentDetailViewModel.AccidentSkip && updateId == 0)
                {
                     _context.AccidentDetails.Add(model);
                    await _context.SaveChangesAsync();
                    return model.AccidentDetailID;
                }

                return 0; // Fallback, should never reach here
            }
            catch (DbUpdateException dbEx)
            {
                _log.Log("Database update error in SubmitAccidentDetailAsync: " + dbEx.Message);
                return 0;
            }
            catch (Exception ex)
            {
                _log.Log("Unexpected error in SubmitAccidentDetailAsync: " + ex);
                return 0;
            }
        }

        public async Task<List<PatientDemographicsViewModel>> GetPatientsByHospital(int hospitalId, int displayId)
        {
            List<PatientDemographicsViewModel> patientDemographics = new List<PatientDemographicsViewModel>();
            try
            {
                var patients = new List<PatientDemographic>();
                if (displayId == 1)
                {
                    patients = _context.PatientDemographics.Where(p => p.HospitalID == hospitalId && p.ProcessDate == null).ToList();
                }
                else
                {
                    patients = _context.PatientDemographics.Where(p => p.HospitalID == hospitalId && p.ProcessDate != null).ToList();
                }

                AutoMapper.Mapper.CreateMap<PatientDemographicsViewModel, PatientDemographic>();
                patientDemographics = AutoMapper.Mapper.Map<List<PatientDemographic>, List<PatientDemographicsViewModel>>(patients);
                return patientDemographics;
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetPatientsByHospital: " + ex);
            }
            return patientDemographics;
        }

        public async Task<PatientModel> GetPatientById(int personId)
        {
            PatientViewModel patientViewModel = new PatientViewModel();
            PatientModel patientModel = new PatientModel();
            try
            {
                var patient = _context.PatientDemographics.Where(a => a.PersonID == personId).FirstOrDefault();

                if (patient != null)
                {
                    patientModel.PatientDemographicsModel = new PatientDemographicsModel
                    {
                        Hospital = _context.Hospitals.FirstOrDefault(a => a.HospitalID == patient.HospitalID).HospitalName,
                        AdmitDate = patient.AdmitDate.Value.ToString("MM/dd/yyyy"),
                        PrimaryCarePhys = patient.PrimaryCarePhys,
                        Full_Name = patient.First_Name + " " + patient.Middle_Name + " " + patient.Last_Name,
                        Address = patient.Address1 + " " + patient.Address2 + " " + patient.City + " " + patient.StateProvince + " " + patient.ZipCode,
                        BirthDate = patient.BirthDate.ToString("MM/dd/yyyy"),
                        Gender = patient.Gender,
                        Race = patient.Race,
                        Marital_Status = patient.Marital_Status,
                        SSN = patient.SSN,
                        Home_Phone = patient.Home_Phone,
                        Cell_Phone = patient.Cell_Phone,
                        Church_Choice = patient.Church_Choice,
                        HospitalService = patient.HospitalService,
                        Email_Address = patient.Email_Address,
                        Bill_Address = patient.Bill_Address1 + " " + patient.Bill_Address2 + " " + patient.Bill_City + " " + patient.Bill_State + " " + patient.Bill_ZipCode,
                        Mailing_Address = patient.Mailing_Address1 + " " + patient.Mailing_Address2 + " " + patient.MailingCity + " " + patient.MailingState + " " + patient.MailingZip,
                        E911Address = patient.E911Address1 + " " + patient.E911Address2 + " " + patient.E911City + " " + patient.E911State + " " + patient.E911Zip,
                        Employer = patient.Employer,
                        Job_Title = patient.Job_Title,
                        EmployerAddress = patient.EmployerAddress1 + " " + patient.EmployerAddress2 + " " + patient.EmployerCity + " " + patient.EmployerState + " " + patient.EmployerZip,
                        EmployerPhone = patient.EmployerPhone,
                        PersonID = patient.PersonID
                        //  ResponsibleParty = _context.ResponsibleParties.FirstOrDefault(a => a.ResponsiblePartyID == patient.ResponsiblePartyID).ResponsiblePartyDescription,
                    };

                    if (patient.ResponsiblePartyID == 4)
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = patient.GuarNameIfOther;
                    }
                    else
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = _context.ResponsibleParties.FirstOrDefault(a => a.ResponsiblePartyID == patient.ResponsiblePartyID).ResponsiblePartyDescription;
                    }

                    if (patient.ResponsiblePartyID == 4)
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = patient.GuarNameIfOther;
                    }
                    else
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = _context.ResponsibleParties.FirstOrDefault(a => a.ResponsiblePartyID == patient.ResponsiblePartyID).ResponsiblePartyDescription;
                    }

                    if (patient.In_Hospital_Directory != null)
                    {
                        patientModel.PatientDemographicsModel.In_Hospital_Directory = Convert.ToBoolean(patient.In_Hospital_Directory) ? "Yes" : "No";
                    }

                    if (patient.PatientHereBefore != null)
                    {
                        patientModel.PatientDemographicsModel.PatientHereBefore = Convert.ToBoolean(patient.PatientHereBefore) ? "Yes" : "No";
                    }

                }

                //AutoMapper.Mapper.CreateMap<PatientDemographicsViewModel, PatientDemographic>();
                //var patientDemographicsViewModel = AutoMapper.Mapper.Map<PatientDemographic, PatientDemographicsViewModel>(patient);
                //patientViewModel.PatientDemographicsViewModel = patientDemographicsViewModel;
                //patientViewModel.PatientDemographicsViewModel.Hospital = _context.Hospitals.FirstOrDefault(a => a.HospitalID == patient.HospitalID).HospitalName;

                var spouse = _context.SpouseInformations.Where(a => a.PersonID == personId).FirstOrDefault();

                if (spouse != null)
                {
                    patientModel.SpouseInformationModel = new SpouseInformationModel
                    {
                        Full_Name = spouse.First_Name + " " + spouse.Middle_Name + " " + spouse.Last_Name,
                        Address = spouse.Address1 + " " + spouse.Address2 + " " + spouse.City + " " + spouse.StateProvince + " " + spouse.ZipCode,
                        BirthDate = spouse.BirthDate != null ? Convert.ToDateTime(spouse.BirthDate).ToString("MM/dd/yyyy") : string.Empty,
                        Race = spouse.Race,
                        Marital_Status = spouse.Marital_Status,
                        SSN = spouse.SSN,
                        Home_Phone = spouse.Home_Phone,
                        Cell_Phone = spouse.Cell_Phone,
                        Employer = spouse.Employer,
                        Job_Title = spouse.Job_Title,
                        EmployerAddress = spouse.EmployerAddress1 + " " + spouse.EmployerAddress2 + " " + spouse.EmployerCity + " " + spouse.EmployerState + " " + spouse.EmployerZip,
                        Employer_Phone = spouse.Employer_Phone,
                        PersonID = patient.PersonID
                    };
                }

                var minor = _context.MinorInformations.Where(a => a.PersonID == personId).FirstOrDefault();
                if (minor != null)
                {
                    patientModel.MinorInformationModel = new MinorInformationModel
                    {
                        Full_Name = minor.First_Name + " " + minor.Middle_Init + " " + minor.Last_Name,
                        Address = minor.Address1 + " " + minor.Address2 + " " + minor.City + " " + minor.StateProvince + " " + minor.ZipCode,
                        Dob = minor.Dob != null ? Convert.ToDateTime(minor.Dob).ToString("MM/dd/yyyy") : "",
                        Race = minor.Race,
                        Marital_Status = minor.Marital_Status,
                        SSN = minor.SSN,
                        HomePhone = minor.HomePhone,
                        Cell_Phone = minor.Cell_Phone,
                        BillAddress = minor.BillAddress1 + " " + minor.BillAddress2 + " " + minor.BillCity + " " + minor.BillState + " " + minor.BillZip,
                        MailAddress = minor.MailAddress1 + " " + minor.MailAddress2 + " " + minor.MailCity + " " + minor.MailState + " " + minor.MailZip,
                        E911Address = minor.E911Address1 + " " + minor.E911Address2 + " " + minor.E911City + " " + minor.E911State + " " + minor.E911Zip,
                        Employer = minor.Employer,
                        Job_Title = minor.Job_Title,
                        EmployerAddress = minor.EmployerAddress1 + " " + minor.EmployerAddress2 + " " + minor.EmployerCity + " " + minor.EmployerState + " " + minor.EmployerZip,
                        EmployerPhone = minor.EmployerPhone,
                        PersonID = minor.PersonID
                    };

                    if (patient.ResponsiblePartyID == 4)
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = patient.GuarNameIfOther;
                    }
                    else
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = _context.ResponsibleParties.FirstOrDefault(a => a.ResponsiblePartyID == patient.ResponsiblePartyID).ResponsiblePartyDescription;
                    }

                    if (patient.ResponsiblePartyID == 4)
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = patient.GuarNameIfOther;
                    }
                    else
                    {
                        patientModel.PatientDemographicsModel.ResponsibleParty = _context.ResponsibleParties.FirstOrDefault(a => a.ResponsiblePartyID == patient.ResponsiblePartyID).ResponsiblePartyDescription;
                    }

                    if (patient.In_Hospital_Directory != null)
                    {
                        patientModel.PatientDemographicsModel.In_Hospital_Directory = Convert.ToBoolean(patient.In_Hospital_Directory) ? "Yes" : "No";
                    }

                    if (patient.PatientHereBefore != null)
                    {
                        patientModel.PatientDemographicsModel.PatientHereBefore = Convert.ToBoolean(patient.PatientHereBefore) ? "Yes" : "No";
                    }

                }

                var emergency = _context.EmergencyContacts.Where(a => a.PersonID == personId).FirstOrDefault();

                if (emergency != null)
                {
                    patientModel.EmergencyContactModel = new EmergencyContactModel
                    {
                        Nearest_Relative_Name = emergency.Nearest_Relative_Name,
                        Address = emergency.Address1 + " " + emergency.Address2 + " " + emergency.City + " " + emergency.StateProvince + " " + emergency.ZipCode,
                        Relationship = emergency.Relationship,
                        Contact_Phone = emergency.Contact_Phone,
                    };
                }

                var insurance = _context.InsuranceInformations.Where(a => a.PersonID == personId).FirstOrDefault();

                if (insurance != null)
                {
                    patientModel.InsuranceInformationModel = new InsuranceInformationModel
                    {
                        InsPlanName = insurance.InsPlanName,
                        InsAddress = insurance.InsAddress1 + " " + insurance.InsAddress2 + " " + insurance.InsCity + " " + insurance.InsState + " " + insurance.InsZip,
                        Subscriber_Name = insurance.Subscriber_Name,
                        Rel_PolicyHolder_To_Patient = insurance.Rel_PolicyHolder_To_Patient,
                        Policy_Number = insurance.Policy_Number,
                        Group_Number = insurance.Group_Number,
                        PlanCode = insurance.PlanCode,
                        InsPhone = insurance.InsPhone
                    };
                }

                var accidentDetail = _context.AccidentDetails.Where(a => a.PersonID == personId).FirstOrDefault();

                if (accidentDetail != null)
                {
                    patientModel.AccidentDetailModel = new AccidentDetailModel
                    {
                        AccidentType = _context.AccidentTypes.FirstOrDefault(a => a.AccidentTypeID == accidentDetail.AccidentTypeID).Description,
                        Location = accidentDetail.Location,
                        DateOfAccident = accidentDetail.DateOfAccident,
                        TimeOfAccident = accidentDetail.TimeOfAccident,
                    };
                }

                return patientModel;
            }
            catch (Exception ex)
            {
                _log.Log("Failed to get GetPatientsByHospital: " + ex);
            }
            return patientModel;
        }
    }
}
