using ClientPageServer.PL.DTO;
using ClientPageServer.PL.Infrastructures;
using ClientPageServer.PL.Interfaces;
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
        private readonly IWeaponsItemRepository weapons;
        //private readonly HttpRequestMessage httpRequestMsg;
        private CancellationTokenSource cts = null!;
        private readonly int timeRequest = 10;

        public WeaponsCardsController(ILogger<WeaponsCardsController> logger, IWeaponsItemRepository weapons)
        {
            this.logger = logger;
            this.weapons = weapons;
            //this.httpRequestMsg = httpRequestMsg;
            setToken();
        }
        private void setToken()
        {
            this.cts = new CancellationTokenSource();
            this.cts.CancelAfter(TimeSpan.FromSeconds(this.timeRequest));
        }

        //[HttpGet("weapons-cards", Name = "GetWeaponsCards")]
        //public async Task<ActionResult<IEnumerable<WeaponsCardDto>>> GetWeaponsCardsRedirect()
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        HttpResponseMessage responseMessage = client.Send(httpRequestMsg, this.cts.Token);

        //        if (responseMessage.StatusCode == HttpStatusCode.OK)
        //        {
        //            return Ok(await responseMessage.Content.ReadFromJsonAsync<List<WeaponsCardDto>>(this.cts.Token));
        //        }
        //        else
        //        {
        //            throw new WeaponsException("Error! failed HttpClient.Send(), status code != 200", $"{HttpStatusCode.OK}");
        //        }
        //    }
        //}

        [HttpGet("model/{model}", Name = "GetWeaponsCardDtoById")]
        public ActionResult<WeaponsCardDto> GetWeaponsCardDtoById([FromRoute] string? model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model))
                {
                    throw new ArgumentNullException($"no name of weapons");
                }

                return Ok(weapons.getCardDtoById(model));
            }
            catch (Exception ex)
            {
                return BadRequest(getException(ex));
            }
        }

        [HttpGet("client-models", Name = "GetWeaponsCards")]
        public ActionResult<IEnumerable<WeaponsCardDto>> GetWeaponsCards()
        {
            try
            {
                return Ok(weapons.getCardsDto());
            }
            catch (Exception ex)
            {
                return BadRequest(getException(ex));
            }
        }
        private string getException(Exception ex)
        {
            if (ex is WeaponsException weaponsEx)
            {
                var _ex = (ex as WeaponsException);
                return $"Error! msg: {weaponsEx.Message} {weaponsEx.property}, source: {weaponsEx.Source}";
            }
            return $"Error! msg: {ex.Message}, details: {ex.InnerException}";
        }
    }
}
