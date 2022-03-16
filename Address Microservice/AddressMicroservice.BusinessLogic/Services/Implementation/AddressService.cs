﻿using AddressMicroservice.DAL.Repository.Interfaces;
using AddressMicroservice.BusinessLogic.Services.Interfaces;
using SharedAzureServiceBus.DTO;

namespace AddressMicroservice.BusinessLogic.Services.Implementation
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public List<AddressData> GetAllAddressData()
        {
            return _addressRepository.GetAllAddressData();
        }

        public AddressData GetAddressData(int personID)
        {
            return _addressRepository.GetAddressData(personID);
        }

        public bool InsertAddressData(AddressData addressData)
        {
           return _addressRepository.InsertAddressData(addressData);
        }
    }
}
