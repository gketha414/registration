using System.Collections.Generic;

namespace PreRegistration.Models.ViewModels
{
    public class GenderViewModel
    {
        public short GenderID { get; set; }
        public string Name { get; set; }
        public string NewName { get; set; }
        public bool IsActive { get; set; }
        public bool? Success { get; set; }

        public List<GenderViewModel> AllGenders { get; set; }
    }
}
