using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ICT.Module.Moneris.Models
{
    public class ICTMonerisConfigForm
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        public string storeID { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string apiKEY { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string userID { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string passWord { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public bool testMode { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string processCountry { get; set; }

    }
}
