using System.Collections.Generic;

namespace PreRegistration.Models.ViewModels
{
    public class BirthGenderViewModel
    {
        public short ID { get; set; }
        public string Description { get; set; }
        public string NewDescription { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<BirthGenderViewModel> AllBirthGenders { get; set; }
    }
}
