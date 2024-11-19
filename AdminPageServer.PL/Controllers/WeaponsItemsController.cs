using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using AdminPageServer.PL.DTO;
using AdminPageServer.PL.Infrastructures;
using AdminPageServer.PL.Interfaces;

namespace AdminPageServer.PL.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsItemsController : ControllerBase
    {
        private readonly ILogger<WeaponsItemsController> logger;
        private readonly IWeaponsItemRepository weapons;


        public WeaponsItemsController(ILogger<WeaponsItemsController> logger, IWeaponsItemRepository weapons)
        {
            this.logger = logger;
            this.weapons = weapons;
        }

        [HttpGet("weaponsitems", Name = "GetWeaponsItemsDto")]
        public ActionResult<IEnumerable<WeaponsItemDto>> GetWeaponsItemsDto() 
        {
            try
            {
                return Ok(weapons.getItemsDto());
            }
            catch (Exception ex) 
            {
                return BadRequest(getException(ex));
            }
        }

        [HttpGet("weapons-id/{model}", Name = "GetWeaponsCardDtoById")]
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
