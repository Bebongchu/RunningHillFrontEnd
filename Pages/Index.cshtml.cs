using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IConfiguration _config;
        private ImyHttpClient _httpClient;
        public  List<string> categories { get; set; }
 
        public IndexModel(IConfiguration config, ILogger<IndexModel> logger, ImyHttpClient client)
        {
            _logger = logger;
            categories = new List<string>();
            _httpClient = client;
            _config = config;
      
        }

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                string response = await _httpClient.gethttpclient().GetStringAsync(_config["getCatsQuery"]);
                foreach(string item in response.Split(','))
                {
                    categories.Add(item);
                }

            }
            catch (Exception ex)
            {

            }
            return Page();

        }
    }
}
