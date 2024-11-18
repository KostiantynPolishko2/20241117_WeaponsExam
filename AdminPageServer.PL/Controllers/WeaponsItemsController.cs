using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminPageServer.PL.DTO;
using AdminPageServer.PL.EF;
using AdminPageServer.PL.Entities;
using System.ComponentModel.DataAnnotations;

namespace SpaceObject.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsItemsController : ControllerBase
    {
        private readonly ILogger<WeaponsItemsController> logger;
        private readonly WeaponsItemsContext context;

        public WeaponsItemsController(ILogger<WeaponsItemsController> logger, WeaponsItemsContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        [HttpGet("weaponsitems", Name = "GetWeaponsItemsDto")]
        public ActionResult<IEnumerable<WeaponsItemDto>> GetWeaponsItemsDto() 
        {
            try
            {
                var data = context.weaponsItems;
                if (data == null)
                {
                    throw new Exception("WeaponsItems no records in db");
                }

                IMapper mapper = new MapperConfiguration(c => c.CreateMap<WeaponsItem, WeaponsItemDto>()).CreateMapper();
                var weaponsItemsDto = mapper.Map<IEnumerable<WeaponsItem>, IEnumerable<WeaponsItemDto>>(data);

                return Ok(weaponsItemsDto);
            }
            catch (Exception ex) 
            { 
                return NotFound(ex.Message);
            }
        }

        [HttpGet("weapons-id/{id}", Name = "GetWeaponsCardDto")]
        public ActionResult<WeaponsCardDto> GetWeaponsCardDto([FromRoute] int id)
        {         
            try
            {
                var item = context.weaponsItems.Include(wi => wi.weaponsProperty).Include(wi => wi.weaponsImage).FirstOrDefault(c => c.id.Equals(id));

                if (item == null)
                {
                    throw new Exception($"WeaponsInfo of id {id}  no records in db");
                }

                var weaponsCardDto = new WeaponsCardDto(item.weaponsProperty) { 
                    Model = item.Model, Name = item.Name, isVisible = item.isVisible,
                    image_path = item.weaponsImage!.path
                };

                return Ok(weaponsCardDto);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
