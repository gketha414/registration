using AutoMapper;
using PreRegistration.Models;
using PreRegistration.Models.Helpers;
using PreRegistration.Models.UI;
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

        public async Task<bool> SubmitPreRegistrationForm(PatientViewModel patientViewModel)
        {
            try
            {
                //SendEmails sendEmails = new SendEmails();
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
                        Home_Phone = patientViewModel.PatientDemographicsViewModel.Home_Phone != null ? (long)patientViewModel.PatientDemographicsViewModel.Home_Phone : 0,
                        Cell_Phone = patientViewModel.PatientDemographicsViewModel.Cell_Phone,
                        Email_Address = patientViewModel.PatientDemographicsViewModel.Email_Address,
                        Church_Choice = patientViewModel.PatientDemographicsViewModel.Church_Choice,

                        Mailing_Address1 = patientViewModel.PatientDemographicsViewModel.Mailing_Address1,
                        Mailing_Address2 = patientViewModel.PatientDemographicsViewModel.Mailing_Address2,
                        MailingCity = patientViewModel.PatientDemographicsViewModel.MailingCity,
                        MailingState = patientViewModel.PatientDemographicsViewModel.MailingState,
                        MailingZip = patientViewModel.PatientDemographicsViewModel.MailingZip,

                        E911Address1 = patientViewModel.PatientDemographicsViewModel.E911Address1,
                        E911Address2 = patientViewModel.PatientDemographicsViewModel.E911Address2,
                        E911City = patientViewModel.PatientDemographicsViewModel.E911City,
                        E911State = patientViewModel.PatientDemographicsViewModel.E911State,
                        E911Zip = patientViewModel.PatientDemographicsViewModel.E911Zip,

                        ResponsiblePartyID = patientViewModel.PatientDemographicsViewModel.ResponsiblePartyID,
                        GuarNameIfOther = patientViewModel.PatientDemographicsViewModel.GuarNameIfOther,

                        Bill_Address1 = patientViewModel.PatientDemographicsViewModel.Bill_Address1,
                        Bill_Address2 = patientViewModel.PatientDemographicsViewModel.Bill_Address2,
                        Bill_City = patientViewModel.PatientDemographicsViewModel.Bill_City, // Corrected
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
                        Status = "Processed",

                        SectionID = 1,
                        Created = DateTime.Now,
                    };

                    _context.PatientDemographics.Add(patientDemographic);
                    await _context.SaveChangesAsync();

                    patientId = patientDemographic.PersonID;

                    //_emailHelper.SendEmailToAdmin(patientViewModel.PatientDemographicsViewModel, patientId);
                    //_emailHelper.SendEmailToPatient(patientViewModel.PatientDemographicsViewModel, patientId);

                    if (!patientViewModel.SpouseInformation.SpouseSkip)
                    {
                        patientViewModel.SpouseInformation.PersonID = patientId;
                        await SubmitSpouseInfo(patientViewModel.SpouseInformation);
                    }

                    if (!patientViewModel.MinorInformation.MinorSKip )
                    {    
                        patientViewModel.MinorInformation.FatherMinorInformation.PersonID = patientId;
                        patientViewModel.MinorInformation.MontherMinorInformation.PersonID = patientId;
                        patientViewModel.MinorInformation.FatherMinorInformation.ResponsiblePartyID = patientViewModel.MinorInformation.MontherMinorInformation.ResponsiblePartyID;

                        
                        await SubmitMinorInfo(patientViewModel.MinorInformation);
                    }

                    if (!patientViewModel.EmergencyContact.EmergencySkip)
                    {
                        patientViewModel.EmergencyContact.EmergencyContactOne.PersonID = patientId;
                        patientViewModel.EmergencyContact.EmergencyContactTwo.PersonID = patientId;
                        patientViewModel.EmergencyContact.EmergencyContactThree.PersonID = patientId;
                        await SubmitEmergencyContact(patientViewModel.EmergencyContact);
                    }

                    if (!patientViewModel.InsuranceInformation.InsuranceSkip)
                    {
                        patientViewModel.InsuranceInformation.InsuranceOne.PersonID = patientId;
                        patientViewModel.InsuranceInformation.InsuranceTwo.PersonID = patientId;
                        patientViewModel.InsuranceInformation.InsuranceThree.PersonID = patientId;

                        await SubmitInsuranceInfo(patientViewModel.InsuranceInformation);
                    }

                    if (!patientViewModel.AccidentDetail.AccidentSkip)
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


                var config = new AutoMapper.MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<MinorViewModel, MinorInformation>();
                });
                var mapper = config.CreateMapper();


                var motherModel = mapper.Map<MinorViewModel, MinorInformation>(minorInformation.MontherMinorInformation);
                var fatherModel = mapper.Map<MinorViewModel, MinorInformation>(minorInformation.MontherMinorInformation);

                if (motherModel.First_Name != null) { _context.MinorInformations.Add(motherModel); } else
                {
                    _context.MinorInformations.Add(fatherModel);
                }

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
                if (emergencyContact.EmergencyContactOne.Nearest_Relative_Name != null) { 
                    _context.EmergencyContacts.Add(emergencyContact.EmergencyContactOne); }
                if (emergencyContact.EmergencyContactTwo.Nearest_Relative_Name != null) {
                    _context.EmergencyContacts.Add(emergencyContact.EmergencyContactTwo); }
                if (emergencyContact.EmergencyContactThree.Nearest_Relative_Name != null) { 
                    _context.EmergencyContacts.Add(emergencyContact.EmergencyContactThree); }


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


        public async Task<bool> SubmitInsuranceInfo(InsuranceMultipleViewModel insuranceInformation)
        {
            try
            {
                InsuranceInformation model = new InsuranceInformation();


                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<InsuranceInformationViewModel, InsuranceInformation>();
                });
                var mapper = config.CreateMapper();
                if (insuranceInformation.InsuranceOne.InsRank != 0)
                {
                    model = mapper.Map<InsuranceInformation>(insuranceInformation.InsuranceOne);
                    _context.InsuranceInformations.Add(model);


                }
                if (insuranceInformation.InsuranceTwo.InsRank != 0)
                {
                    model = mapper.Map<InsuranceInformation>(insuranceInformation.InsuranceTwo);
                    _context.InsuranceInformations.Add(model);


                }
                if (insuranceInformation.InsuranceThree.InsRank != 0)
                {
                    model = mapper.Map<InsuranceInformation>(insuranceInformation.InsuranceThree);
                    _context.InsuranceInformations.Add(model);

                }


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
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<AccidentDetailViewModel, AccidentDetail>();
                });

                var mapper = config.CreateMapper();
                model = mapper.Map<AccidentDetail>(accidentDetailViewModel);

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
                        AdmitDate = patient.AdmitDate.ToString("MM/dd/yyyy"),
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
