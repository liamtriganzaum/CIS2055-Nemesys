using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS2055___Nemesys.Models;

namespace CIS2055___Nemesys.ViewModels
{
    public class InvestigationViewModel
    {
        public int IRN { get; set; }
        public DateTime DateOfAction { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public Status _status { get; set; }
    }

}