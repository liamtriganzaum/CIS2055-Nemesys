using System.Collections.Generic;
using CIS2055___Nemesys.Models;

namespace CIS2055___Nemesys.ViewModels
{
    public class ReportListViewModel
    {
        public int TotalEntries { get; set; }
        public IEnumerable<ReportViewModel> Reports { get; set; }
    }
}
