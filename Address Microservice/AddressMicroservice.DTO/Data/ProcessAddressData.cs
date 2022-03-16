﻿using AddressMicroservice.BusinessLogic.Services.Interfaces;
using SharedAzureServiceBus.DTO;

namespace AddressMicroservice.DTO.Data
{
    public class ProcessAddressData : IProcessAddressData
    {
        private readonly IAddressService _addressService;
        public ProcessAddressData(IAddressService addressService)
        {
            _addressService = addressService;
        }
        public Task Process(AddressData myPayload)
        {
            bool inserted = _addressService.InsertAddressData(myPayload);
            return inserted ? Task.CompletedTask : Task.FromException(new Exception("Not Inserted"));
        }
    }
}
