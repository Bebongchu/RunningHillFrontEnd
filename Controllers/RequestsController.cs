using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Threading.Tasks;


namespace FrontEnd.Controllers
{
  

    [ApiController]
    [Route("api/Requests")]
    public class RequestsController : Controller
    {
        private IConfiguration _config;
        private ImyHttpClient _httpClient;
       public RequestsController(IConfiguration config, ImyHttpClient client)
        {
            _config = config;
            _httpClient = client;
        }

        [HttpPost]
        public async Task<string> Index([FromBody] string request)
        {
            string response = await _httpClient.gethttpclient().GetStringAsync(request);

            return response;
        }

 

}
}
