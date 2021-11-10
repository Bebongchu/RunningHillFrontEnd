using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Pages
{
    public class SentencesModel : PageModel
    {
        private readonly ILogger<SentencesModel> _logger;
        private ImyHttpClient _httpClient;
        private IConfiguration _config;
        public List<string> Sentences { get; set; }
        public SentencesModel(IConfiguration config, ILogger<SentencesModel> logger, ImyHttpClient client)
        {
            Sentences = new List<string>();
            _logger = logger;
            _httpClient = client;
            _config = config;
        }

        public async Task<IActionResult> OnGet()
        {

            try
            {
                string response = await _httpClient.gethttpclient().GetStringAsync(_config["getSentencesQuery"]);
                foreach (string item in response.Split(','))
                {
                    Sentences.Add(item);
                }

            }
            catch (Exception ex)
            {

            }
            return Page();
        }
    }
}
