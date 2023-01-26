using FlightCrashSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FlightCrashSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
		private readonly IFlightCrashService flightCrashService;

		public IndexModel(ILogger<IndexModel> logger, IFlightCrashService flightCrashService)
        {
            _logger = logger;
			this.flightCrashService = flightCrashService;
		}

        public void OnGet()
        {

        }
    }
}