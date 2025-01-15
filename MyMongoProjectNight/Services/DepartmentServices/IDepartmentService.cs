using MyMongoProjectNight.Dtos.DepartmentDtos;

namespace MyMongoProjectNight.Services.DepartmentServices
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();

        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);

        Task UpdateDepartmentAsync(UpdateDepartmentDto UpdateDepartmentDto);

        Task DeleteDepartmentAsync(string DepartmentId);

        Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string DepartmentId);
    }
}
