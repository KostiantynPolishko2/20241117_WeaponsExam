using AdminPageServer.PL.DTO;
using AdminPageServer.PL.Entities;

namespace AdminPageServer.PL.Interfaces
{
    public interface IWeaponsItemRepository : IDisposable
    {
        public IEnumerable<WeaponsItemDto> getItemsDto();

        public WeaponsCardDto getCardDtoById(string name);

        public void addNewWeaponsData(string model, WeaponsDataDto weaponsData);

        public void deleteWeaponsData(string model);

        public void Save();
    }
}
