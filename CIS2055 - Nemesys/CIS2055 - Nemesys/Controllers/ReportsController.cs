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
        
        public IActionResult Expand(int rrn)
        {
            var current_report = _reportsRepository.GetDocumentByRN(rrn);

            if (current_report == null) return NotFound();

            var Model = new ReportViewModel()
            {
                RRN                = current_report.RRN,
                Title              = current_report.Title,
                Location           = current_report.Location,
                Desc               = current_report.Desc,
                _hazardType        = current_report._hazardType,
                DateAndTimeOfReport= current_report.DateAndTimeOfReport,
                _status            = current_report._status
            };

            return View(Model);
        }

        [HttpGet]
        public IActionResult Edit(int rrn)
        {
            var report = _reportsRepository.GetDocumentByRN(rrn);
            if (report != null)
            {
                var Model = new EditReportViewModel()
                {
                    Title = report.Title,
                    Location = report.Location,
                    _hazardType = report._hazardType,
                    Desc = report.Desc,
                    Reporter_Email = report.Reporter_Email,
                    _status = report._status
                };
                
                return View(Model);
            }
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int rrn, [Bind("rrn, Title, Location, _hazardType, Desc, ReporterEmail, status")] EditReportViewModel ReportToUpdate)
        {
            var report = _reportsRepository.GetDocumentByRN(rrn);
            if (report == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                report.Title = ReportToUpdate.Title;
                report.Desc = ReportToUpdate.Desc;
                report.Location = ReportToUpdate.Location;
                report._hazardType = ReportToUpdate._hazardType;
                report._status = ReportToUpdate._status;
                report.Reporter_Email = ReportToUpdate.Reporter_Email;

                _reportsRepository.UpdateReport(report);
                return RedirectToAction("Index");
            }
            
            // todo not finished part (from bloggy)
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
