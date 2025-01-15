﻿using AutoMapper;
using MongoDB.Driver;
using MyMongoProjectNight.Dtos.CustomerDtos;
using MyMongoProjectNight.Entities;
using MyMongoProjectNight.Settings;

namespace MyMongoProjectNight.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
           var value=_mapper.Map<Customer>(createCustomerDto);
            await _customerCollection.InsertOneAsync(value);
        }

        public async Task DeleteCustomerAsync(string customerId)
        {
          await _customerCollection.DeleteOneAsync(x=>x.CustomerId==customerId);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
           var values=await _customerCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values);
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(string customerId)
        {
            var values = await _customerCollection.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCustomerDto>(values);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto UpdateCustomerDto)
        {
            var values=_mapper.Map<Customer>(UpdateCustomerDto);
            await _customerCollection.FindOneAndReplaceAsync(x => x.CustomerId == UpdateCustomerDto.CustomerId, values);
        }
    }
}