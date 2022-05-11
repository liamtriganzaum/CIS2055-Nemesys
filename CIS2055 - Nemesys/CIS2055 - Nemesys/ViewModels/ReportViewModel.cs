using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CIS2055___Nemesys.Models;

namespace CIS2055___Nemesys.ViewModels
{
    public class ReportViewModel
    {
        public int RRN { get; set; }
        public DateTime DateAndTimeOfReport { get; set; }
        public string Title { get; set; }
        public HazardType _hazardType { get; set; }
        public string Location { get; set; }
        public string Desc { get; set; }
        public Status _status { get; set; }
    }

}
