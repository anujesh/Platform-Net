using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Id.ViewModels
{
    public class ExternalLoginConfirmationVM
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }
    }
}
