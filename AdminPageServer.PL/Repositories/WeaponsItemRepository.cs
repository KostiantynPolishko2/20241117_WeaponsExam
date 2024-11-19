using Azure;
using AdminPageServer.PL.Entities;
using AdminPageServer.PL.Infrastructures;
using AdminPageServer.PL.Interfaces;
using AdminPageServer.PL.EF;
using AdminPageServer.PL.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AdminPageServer.PL.Repositories
{
    public class WeaponsItemRepository: IWeaponsItemRepository
    {
        private readonly WeaponsItemsContext context;
        private bool disposed = false;

        public WeaponsItemRepository(WeaponsItemsContext context)
        {
            this.context = context;
        }

        public IEnumerable<WeaponsItemDto> getItemsDto()
        {
            var data = context.weaponsItems;
            if (data == null)
            {
                throw new WeaponsException("no records in db ", "WeaponsItems");
            }

            IMapper mapper = new MapperConfiguration(c => c.CreateMap<WeaponsItem, WeaponsItemDto>()).CreateMapper();
            var weaponsItemsDto = mapper.Map<IEnumerable<WeaponsItem>, IEnumerable<WeaponsItemDto>>(data);

            return weaponsItemsDto;
        }

        public WeaponsCardDto getCardDtoById(string model)
        {

            var _model = model.ToLower();
            var item = context.weaponsItems.Include(wi => wi.weaponsProperty).Include(wi => wi.weaponsImage).FirstOrDefault(c => c.Model.ToLower().Equals(_model));

            if (item == null)
            {
                throw new Exception($"WeaponsInfo of {model}  no records in db");
            }

            var weaponsCardDto = new WeaponsCardDto(item.weaponsProperty)
            {
                Model = item.Model,
                Name = item.Name,
                isVisible = item.isVisible,
                image_path = item.weaponsImage!.path
            };

            return weaponsCardDto;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
