using MyMongoProjectNight.Dtos.CustomerDtos;

namespace MyMongoProjectNight.Services
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();

        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);

        Task UpdateCustomerAsync(UpdateCustomerDto UpdateCustomerDto);

        Task DeleteCustomerAsync(string customerId);

        Task<GetByIdCustomerDto> GetByIdCustomerAsync(string customerId);

        Task<List<ResultCustomerWithCategoryDto>> GetAllCustomerWithCategoryAsync();

    }
}