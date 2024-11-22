using ClientPageServer.PL.DTO;
using ClientPageServer.PL.Infrastructures;
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
        private readonly HttpRequestMessage httpRequestMsg;
        private CancellationTokenSource cts = null!;
        private readonly int timeRequest = 10;

        public WeaponsCardsController(ILogger<WeaponsCardsController> logger, HttpRequestMessage httpRequestMsg)
        {
            this.httpRequestMsg = httpRequestMsg;
            this.logger = logger;
            setToken();
        }
        private void setToken()
        {
            this.cts = new CancellationTokenSource();
            this.cts.CancelAfter(TimeSpan.FromSeconds(this.timeRequest));
        }

        [HttpGet("weapons-cards", Name = "GetWeaponsCards")]
        public async Task<ActionResult<IEnumerable<WeaponsCardDto>>> GetWeaponsCards()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = client.Send(httpRequestMsg, this.cts.Token);

                    if (responseMessage.StatusCode == HttpStatusCode.OK){
                        return Ok(await responseMessage.Content.ReadFromJsonAsync<List<WeaponsCardDto>>(this.cts.Token));
                    }
                    else{
                        throw new WeaponsException("Error! failed HttpClient.Send(), status code != ", $"{HttpStatusCode.OK}");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(handleException(ex));
            }
        }

        private string handleException(Exception ex)
        {
            if (ex is WeaponsException weaponsEx){
                var _ex = (ex as WeaponsException);
                return $"Error! msg: {weaponsEx.Message} {weaponsEx.property}, source: {weaponsEx.Source}";
            }
            else if (ex is HttpRequestException){
                return $"Error! request failed due network, DNS, or server sertificate";
            }
            else if (ex is TaskCanceledException){
                return $"Error! request failed due to finish time request {this.timeRequest}";
            }

            return $"Error! msg: {ex.Message}, details: {ex.InnerException}";
        }

    }
}
