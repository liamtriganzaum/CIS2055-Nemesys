using System.Runtime.InteropServices;

using System.Collections.Generic;
using CIS2055___Nemesys.Models.Documents;

namespace CIS2055___Nemesys.Models.Repositories
{
    public class InvestigationsRepository
    {
        private List<Investigation> _investigations;

        public InvestigationsRepository()
        {
            if (_investigations == null)
            {
                InitializeInvestigations();
            }
        }

        private void InitializeInvestigations()
        {
            _investigations = new List<Investigation>()
            {
                new Investigation(description:"desctiption: ok",
                           email:"email@mail.com",
                           status:Status.Open),
            };
        }

        // todo this method has to return IEnumerable<Report> 
        public IEnumerable<Investigation> GetAllInvestigations()
        {
            return _investigations;
        }

        public Investigation GetDocumentByRN(int IRN)
        {
            return null;
        }
    }
}