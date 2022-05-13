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
    public class InvestigationsController : Controller
    {
        private readonly InvestigationsRepository _investigationRepository;

        public InvestigationsController(InvestigationsRepository investigationRepository)
        {
            _investigationRepository = investigationRepository;
        }
        
        public IActionResult Index()
        {
            var model = new InvestigationListViewModel()
            {
                TotalEntries = _investigationRepository.GetAllInvestigations().Count(),
                Investigations = _investigationRepository
                    .GetAllInvestigations()
                    .OrderByDescending(b => b.DateOfAction)
                    .Select(b => new InvestigationViewModel
                    {
                        IRN = b.IRN,
                        DateOfAction = b.DateOfAction,
                        Desc = b.Desc,
                        Title = b.Title
                    })
            };
            return View(model);
        }

        public IActionResult Investigations()
        {
            var model = _investigationRepository.GetAllInvestigations();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Title, Desc, InvestigatorEmail, status")] EditInvestigationViewModel newInvestigation)
        {
            if (ModelState.IsValid)
            {
                Investigation investigation = new Investigation()
                {
                    Title = newInvestigation.Title,
                    Desc = newInvestigation.Desc,
                    Investigator_Email = newInvestigation.Investigator_Email,
                    _status = newInvestigation._status
                };

                _investigationRepository.CreateInvestigation(investigation);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Expand(int irn)
        {
            var current_investigation = _investigationRepository.GetDocumentByRN(irn);

            if (current_investigation == null) return NotFound();

            var Model = new InvestigationViewModel()
            {
                IRN = current_investigation.IRN,
                Title = current_investigation.Title,,
                Desc = current_investigation.Desc,
                DateOfAction = current_investigation.DateOfAction,
                _status = current_investigation._status
            };

            return View(Model);
        }

        [HttpGet]
        public IActionResult Edit(int irn)
        {
            var investigation = _investigationRepository.GetDocumentByRN(irn);
            if (investigation != null)
            {
                var Model = new EditInvestigationViewModel()
                {
                    Title = investigation.Title,
                    Desc = investigation.Desc,
                    Investigator_Email = investigation.Investigator_Email,
                    _status = investigation._status
                };

                return View(Model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int irn, [Bind("irn, Title, Desc, InvestigatorEmail, status")] EditInvestigationViewModel InvestigationToUpdate)
        {
            var investigation = _investigationRepository.GetDocumentByRN(irn);
            if (investigation == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                investigation.Title = InvestigationToUpdate.Title;
                investigation.Desc = InvestigationToUpdate.Desc;
                investigation._status = InvestigationToUpdate._status;
                investigation.Investigator_Email = InvestigationToUpdate.Investigator_Email;

                _investigationRepository.UpdateInvestigation(investigation);
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
