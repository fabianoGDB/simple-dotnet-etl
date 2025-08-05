using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ETLProject.Blazor.Pages
{
    public class PowerBI : PageModel
    {
        private readonly ILogger<PowerBI> _logger;

        public PowerBI(ILogger<PowerBI> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}