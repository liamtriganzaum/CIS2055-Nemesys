using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CIS2055___Nemesys.Models.Documents;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace CIS2055___Nemesys.Models.Repositories
{
    public class ReportsRepository
    {
        private readonly AppDbContext _appDbContext;

        public ReportsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
       
        public IEnumerable<Report> GetAllReports()
        {
            //Using Eager loading
            return _appDbContext.Reports;
        }
        
        
        public void CreateReport(Report report)
        {
            _appDbContext.Reports.Add(report);
            _appDbContext.SaveChanges();
        }

        public void UpdateReport(Report report)
        {
            var existingReport = _appDbContext.Reports.SingleOrDefault(r => r.RRN == report.RRN);
            if (existingReport != null)
            {
                existingReport.Title = report.Title;
                existingReport.Location = report.Location;
                existingReport.Desc = report.Desc;
                existingReport._hazardType = report._hazardType;
                existingReport._status = report._status;

                _appDbContext.Entry(existingReport).State = EntityState.Modified;
                _appDbContext.SaveChanges();
            }
        }

        public Report GetDocumentByRN(int rrn)
        {
            return _appDbContext.Reports.FirstOrDefault(r => r.RRN == rrn);
        }
    }
}