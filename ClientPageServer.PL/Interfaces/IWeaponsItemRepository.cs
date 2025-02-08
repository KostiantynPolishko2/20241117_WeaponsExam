using ClientPageServer.PL.DTO;

namespace ClientPageServer.PL.Interfaces
{
    public interface IWeaponsItemRepository : IDisposable
    {
        public WeaponsCardDto getCardDtoById(string name);

        public IEnumerable<WeaponsCardDto> getCardsDto();

        public void Save();
    }
}
