using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class postMsg
    {
        public string dest { get; set; }
        public string sent { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class PostSentFrtController : ControllerBase
    {
        ImyHttpClient _httpClient;
        public PostSentFrtController(ImyHttpClient client)
        {
            _httpClient = client;
        }


        [HttpPost]
        public async Task<string> Index([FromBody] postMsg msg)
        {
            StringContent cont = new StringContent("{\"sentence\":\""+ msg.sent + "\"}", null, "application/json");
           
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("setence", msg.sent)
            });
            var response = await _httpClient.gethttpclient().PostAsync(msg.dest, cont);

            return await response.Content.ReadAsStringAsync();
        }

    }

}
