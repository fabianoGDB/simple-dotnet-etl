using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ETLProject.Blazor.Pages
{
    public class UploadCsv : PageModel
    {
        private readonly ILogger<UploadCsv> _logger;

        public UploadCsv(ILogger<UploadCsv> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}