using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreRegistration.Models.ViewModels
{
    public class HospitalServiceViewModel
    {
        public short ID { get; set; }
        public string Description { get; set; }
        public string NewDescription { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<HospitalServiceViewModel> AllHospitalServices { get; set; }
    }
}
