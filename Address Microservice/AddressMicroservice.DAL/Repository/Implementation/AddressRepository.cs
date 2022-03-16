﻿using AddressMicroservice.DAL.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using SharedAzureServiceBus.DTO;
using AddressMicroservice.DAL.Shared;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AddressMicroservice.DAL.Repository.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IConfiguration _configuration;

        public AddressRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AddressData GetAddressData(int personID)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("PersonID",personID)
            };
            DataSet dataSet = new DataSet();
            dataSet = SqlHelper.ExecuteProcedureReturnDataSet(_configuration.GetConnectionString("SQLConnectionString"), "GetAddress", sqlParameters);
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {

                AddressData addressData = new AddressData();
                addressData.PersonID = Convert.ToInt32(HandleNull(dataSet.Tables[0].Rows[0]["personid"]));
                addressData.Address = HandleNull(dataSet.Tables[0].Rows[0]["Address"]);
                addressData.Phone = HandleNull(dataSet.Tables[0].Rows[0]["Phone"]);
                addressData.Email = HandleNull(dataSet.Tables[0].Rows[0]["Email"]);
                return addressData;
            }
            else
            {
                return null;
            }
        }

        public List<AddressData> GetAllAddressData()
        {
            List<AddressData> listAddressData = new List<AddressData>();
            DataSet dataSet = new DataSet();
            dataSet = SqlHelper.ExecuteProcedureReturnDataSet(_configuration.GetConnectionString("SQLConnectionString"), "GetAllAddresses");
            if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dataSet.Tables[0].Rows)
                {
                    AddressData addressData = new AddressData();
                    addressData.PersonID = Convert.ToInt32(HandleNull(dr["personid"]));
                    addressData.Address = HandleNull(dr["Address"]);
                    addressData.Phone = HandleNull(dr["Phone"]);
                    addressData.Email = HandleNull(dr["Email"]);
                    listAddressData.Add(addressData);
                }
            }
            return listAddressData;
        }
        private string HandleNull(object? input)
        {
            if (input == null)
            {
                return "";
            }
            return input.ToString();
        }
        public bool InsertAddressData(AddressData addressData)
        {
            SqlParameter[] sqlParameters = new SqlParameter[] {
                new SqlParameter("personid",addressData.PersonID),
                new SqlParameter("Address",addressData.Address),
                new SqlParameter("Phone",addressData.Phone),
                new SqlParameter("Email",addressData.Email)
            };
            bool inserted = SqlHelper.ExecuteProcedureReturnDataSet(_configuration.GetConnectionString("SQLConnectionString"), "InsertAddressData", sqlParameters).Tables[0].Rows[0][0].ToString() == "1" ? true : false;
            return inserted;
        }
    }
}
