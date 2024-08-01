using System;
using System.ComponentModel.DataAnnotations;

namespace PreRegistration.Models.ViewModels
{
    public class CentraPeopleViewModel
    {
        public CentraPeopleViewModel()
        {
            Full_Name = string.Empty;
            Ad_Id = string.Empty;
            Employee_Id = 0;
            Email_Address = string.Empty;
            Department = string.Empty;
            Dept_Name = string.Empty;
            Work_Phone_Alpha = string.Empty;
            Nick_Name = string.Empty;
        }
        [Display(Name = "Employee Id")]
        public int Employee_Id { get; set; }
        public string Last_Name { get; set; }
        public string First_Name { get; set; }
        public string Middle_Init { get; set; }
        [Display(Name = "Employee Name")]
        public string Full_Name { get; set; }
        public string Nick_Name { get; set; }
        [Display(Name = "Job Code")]
        public string Job_Code { get; set; }
        [Display(Name = "Job Title")]
        public string Title { get; set; }
        public string Work_Phone { get; set; }
        public string Location { get; set; }
        public string Location_Name { get; set; }
        [Display(Name = "Cost Center")]
        public string Department { get; set; }
        [Display(Name = "Department")]
        public string Dept_Name { get; set; }
        public string Email_Address { get; set; }
        public string Ad_Id { get; set; }
        public DateTime? birthdate { get; set; }
        public DateTime? hiredate { get; set; }
        public bool? RN_License_Flag { get; set; }
        public string Image_Path { get; set; }
        public bool? supervisor { get; set; }
        public string NBR_FTE { get; set; }
        public string SupervisorName { get; set; }
        public int super_id { get; set; }
        public string Work_Phone_Alpha { get; set; }
        public string exempt_status { get; set; }
        public DateTime? GOdate { get; set; }
        public string physical_location { get; set; }
        public string Status_Code { get; set; }
        public string physloc_name { get; set; }
        public DateTime? acquisition_date { get; set; }
        public string Plan_id { get; set; }
        public bool? MD_license_flag { get; set; }
        public bool? LPN_license_flag { get; set; }
        public bool? CNA_license_flag { get; set; }
        public DateTime? srv_begin_dt { get; set; }
        public string Supervisor_code { get; set; }
        public DateTime? current_hire_date { get; set; }
        public string EMP_ADDR1 { get; set; }
        public string EMP_ADDR2 { get; set; }
        public string EMP_CITY { get; set; }
        public string EMP_STATE { get; set; }
        public string EMP_ZIP { get; set; }
        public string EMP_GENDER { get; set; }
        public string MgrEmail { get; set; }
        public int PersonTypeId { get; set; }
    }
}
