using CIS2055___Nemesys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CIS2055___Nemesys.Models.Documents;
using CIS2055___Nemesys.Models.Repositories;
using CIS2055___Nemesys.ViewModels;

namespace CIS2055___Nemesys.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportsRepository _reportsRepository;

        public ReportsController(ReportsRepository reportsRepository)
        {
            _reportsRepository = reportsRepository;
        }
        
        public IActionResult Index()
        {
            var model = new ReportListViewModel()
            {
                TotalEntries = _reportsRepository.GetAllReports().Count(),
                Reports = _reportsRepository
                    .GetAllReports()
                    .OrderByDescending(b => b.DateAndTimeOfReport)
                    .Select(b => new ReportViewModel
                    {
                        RRN = b.RRN,
                        DateAndTimeOfReport = b.DateAndTimeOfReport,
                        Desc = b.Desc,
                        Location = b.Location,
                        Title = b.Title
                    })
            };

            return View(model);
        }

        public IActionResult Reports()
        {
            var model = _reportsRepository.GetAllReports();
            return View(model);
        }

       
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create([Bind("Title, Location, _hazardType, Desc, ReporterEmail, status")] EditReportViewModel newReport)
        {
            if (ModelState.IsValid)
            {
                Report report = new Report()
                {
                    Title = newReport.Title,
                    Location = newReport.Location,
                    _hazardType = newReport._hazardType,
                    Desc = newReport.Desc,
                    Reporter_Email = newReport.Reporter_Email,
                    _status = newReport._status
                };

                _reportsRepository.CreateReport(report);
                return RedirectToAction("Index");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
