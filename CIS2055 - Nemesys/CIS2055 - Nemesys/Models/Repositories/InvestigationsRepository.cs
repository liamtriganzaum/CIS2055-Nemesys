using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using CIS2055___Nemesys.Models.Documents;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace CIS2055___Nemesys.Models.Repositories
{
    public class InvestigationsRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvestigationsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // todo this method has to return IEnumerable<Investigation> 
        public IEnumerable<Investigation> GetAllInvestigations()
        {
            return _appDbContext.Investigations;
        }

        public void CreateInvestigation(Investigation investigation)
        {
            _appDbContext.Investigations.Add(investigation);
            _appDbContext.SaveChanges();
        }

        public void UpdateInvestigation(Investigation investigation)
        {
            var existingInvestigation = _appDbContext.Investigations.SingleOrDefault(i => i.IRN == investigation.IRN);
            if (existingInvestigation != null)
            {
                 existingInvestigation.Title = investigation.Title;
                 existingInvestigation.Desc = investigation.Desc;
                 existingInvestigation._status = investigation._status;
            
                 _appDbContext.Entry(existingInvestigation).State = EntityState.Modified;
                 _appDbContext.SaveChanges();
            }
        }
        public Investigation GetDocumentByRN(int irn)
        {
            return _appDbContext.Investigations.FirstOrDefault(i => i.IRN == irn);
        }
    }
}