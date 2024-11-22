using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ClientPageServer.PL.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsCardsController : ControllerBase
    {
        private readonly ILogger<WeaponsCardsController> logger;

        public WeaponsCardsController(ILogger<WeaponsCardsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("weapons-cards", Name = "GetWeaponsCards")]
        public async Task<ActionResult<string>> GetWeaponsCards()
        {
            using (HttpClient client = new HttpClient())
            {
                var uri = new Uri("https://adminpage-server.azurewebsites.net/api/WeaponsItems/client-models");
                HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Get, uri);
                httpRequest.Headers.Add("Accept", "application/json");

                HttpResponseMessage responseMessage = client.Send(httpRequest);
                var item = responseMessage.StatusCode;

                if (responseMessage.StatusCode == HttpStatusCode.OK)
                {
                    return await responseMessage.Content.ReadAsStringAsync();
                }

                return "responce is empty";
            }
        }
    }
}
