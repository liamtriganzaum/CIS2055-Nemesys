using System.Collections.Generic;
using CIS2055___Nemesys.Models.Documents;

namespace CIS2055___Nemesys.Models.Repositories
{
    public class ReportsRepository
    {
        private List<Report> _reports;

        public ReportsRepository()
        {
            if (_reports == null)
            {
                InitializeReports();
            }
        }

        private void InitializeReports()
        {
            System.Console.WriteLine("Initialising");
            _reports = new List<Report>()
            {
                new Report(location:"Malta",
                           h_type: HazardType.UnsafeAct, 
                           description:"desctiption: hazardous",
                           email:"email@mail.com",
                           status:Status.Open),
                new Report(location:"Tallin",
                           h_type: HazardType.UnsafeAct, 
                           description:"desctiption: ok",
                           email:"email@mail.com",
                           status:Status.Open),
                new Report(location:"Malta",
                           h_type: HazardType.UnsafeAct, 
                           description:"desctiption: super",
                           email:"email@mail.com",
                           status:Status.Open)
            };
        }
        
        // todo this method has to return IEnumerable<Report> 
        public IEnumerable<Report> GetAllReports()
        {
            return _reports;
        }

        public Report GetDocumentByRN(int RRN)
        {
            return null;
        }
    }
}