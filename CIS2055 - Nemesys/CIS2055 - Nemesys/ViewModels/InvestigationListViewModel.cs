using System.Collections.Generic;
using CIS2055___Nemesys.Models;

namespace CIS2055___Nemesys.ViewModels
{
    public class InvestigationListViewModel
    {
        public int TotalEntries { get; set; }
        public IEnumerable<InvestigationViewModel> Investigations { get; set; }
    }
}
