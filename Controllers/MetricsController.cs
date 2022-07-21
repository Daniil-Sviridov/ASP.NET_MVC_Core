using Microsoft.AspNetCore.Mvc;
using MVC_study.Models;

namespace MVC_study.Controllers
{
    public class MetricsController : Controller
    {
        private IMetrics _metrics;

        public MetricsController(IMetrics metrisc)
        {
            _metrics = metrisc;
        }

        public IActionResult Metrics()
        {
            return View(_metrics);
        }
    }
}
