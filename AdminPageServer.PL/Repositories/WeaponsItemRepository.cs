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

        public void addNewWeaponsData(string model, WeaponsDataDto weaponsData)
        {
            var check = context.weaponsItems.FirstOrDefault(wi => wi.Model.Equals(model.ToLower()))??null;
            if (check != null)
            {
                throw new WeaponsException("in db is already existed", model);
            }

            context.weaponsItems.Add(new WeaponsItem(weaponsData.weaponsItem));
            context.SaveChanges();

            int idWeaponsItem = context.weaponsItems.FirstOrDefault(wi => wi.Model.Equals(model.ToLower()))!.id;
            if (idWeaponsItem == -1)
            {
                throw new Exception($"Weapons {model} did not saved to db");
            }

            weaponsData.weaponsProperty.idWeaponsItem = idWeaponsItem;
            weaponsData.weaponsImage.idWeaponsItem = idWeaponsItem;

            context.weaponsProperties.Add(weaponsData.weaponsProperty);
            context.weaponsImages.Add(weaponsData.weaponsImage);
            context.SaveChanges();
        }

        public void deleteWeaponsData(string model)
        {
            var weaponsItem = context.weaponsItems.FirstOrDefault(wi => wi.Model.Equals(model.ToLower())) ?? null;
            if (weaponsItem == null)
            {
                throw new WeaponsException("in db is absent", model);
            }

            context.weaponsItems.Remove(weaponsItem);
            context.SaveChanges();
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
