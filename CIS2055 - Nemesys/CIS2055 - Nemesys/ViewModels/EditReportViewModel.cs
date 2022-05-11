using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using CIS2055___Nemesys.Models;

namespace CIS2055___Nemesys.ViewModels
{
    public class EditReportViewModel
    {
        public int RRN { get; set; }

        [Required(ErrorMessage = "A title is required")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "A location is required")]
        [StringLength(50)]
        [Display(Name = "Report location")]
        public string Location { get; set; }
        

        [Display(Name = "Report type")]
        //Property used to bind user selection
        [Required(ErrorMessage = "Report type is required")]
        public HazardType _hazardType { get; set; }

        [Required(ErrorMessage = "Report description is required")]
        [StringLength(1500, ErrorMessage = "Report description cannot be longer than 1500 characters")]
        public string Desc { get; set; }

        [Display(Name = "Reporter Email")]
        [Required(ErrorMessage = "Reporter Email is required")]
        public string Reporter_Email { get; set; }

        //Property used solely to populate drop down
        // public List<CategoryViewModel> CategoryList { get; set; }
        public Status _status { get; set; } //Used to prepare the edit page
    }

}
