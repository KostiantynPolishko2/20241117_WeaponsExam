using Azure;
using ClientPageServer.PL.Entities;
using ClientPageServer.PL.Infrastructures;
using ClientPageServer.PL.Interfaces;
using ClientPageServer.PL.EF;
using ClientPageServer.PL.DTO;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ClientPageServer.PL.Repositories
{
    public class WeaponsItemRepository: IWeaponsItemRepository
    {
        private readonly WeaponsItemsContext context;
        private bool disposed = false;

        public WeaponsItemRepository(WeaponsItemsContext context)
        {
            this.context = context;
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

        public IEnumerable<WeaponsCardDto> getCardsDto()
        {
            IEnumerable<WeaponsItem> data = context.weaponsItems.Include(wi => wi.weaponsProperty).Include(wi => wi.weaponsImage);
            if (data == null)
            {
                throw new WeaponsException("no records in db ", "WeaponsItems");
            }

            var config = new MapperConfiguration(c => c.CreateMap<WeaponsItem, WeaponsCardDto>().ForMember("image_path", opt => opt.MapFrom(src => src.weaponsImage!.path)));
            IMapper mapper = new Mapper(config);

            var weaponsCardsDto = mapper.Map<IEnumerable<WeaponsItem>, IEnumerable<WeaponsCardDto>>(data);

            return weaponsCardsDto;
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
