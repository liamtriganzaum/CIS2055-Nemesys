using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using CIS2055___Nemesys.Models;

namespace CIS2055___Nemesys.ViewModels
{
    public class EditInvestigationViewModel
    {
        public int IRN { get; set; }

        [Required(ErrorMessage = "A title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Investigation description is required")]
        [StringLength(1500, ErrorMessage = "Investigation description cannot be longer than 1500 characters")]
        public string Desc { get; set; }

        [Display(Name = "Investigator Email")]
        [Required(ErrorMessage = "Investigator Email is required")]
        public string Investigator_Email { get; set; }

        //Property used solely to populate drop down
        public Status _status { get; set; } //Used to prepare the edit page
    }

}