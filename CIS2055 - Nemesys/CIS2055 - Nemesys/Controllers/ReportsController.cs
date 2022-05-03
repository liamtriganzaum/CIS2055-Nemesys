using CIS2055___Nemesys.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CIS2055___Nemesys.Models.Repositories;

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
            return View();
        }

        public IActionResult Reports()
        {
            var model = _reportsRepository.GetAllReports();
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
