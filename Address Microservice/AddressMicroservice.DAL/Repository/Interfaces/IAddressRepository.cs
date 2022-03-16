using SharedAzureServiceBus.DTO;

namespace AddressMicroservice.DAL.Repository.Interfaces
{
    public interface IAddressRepository
    {
        public bool InsertAddressData(AddressData addressData);
        public List<AddressData> GetAllAddressData();
        public AddressData GetAddressData(int personID);
    }
}
