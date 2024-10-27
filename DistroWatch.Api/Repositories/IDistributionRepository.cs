using DistroWatch.Api.Data;

namespace DistroWatch.Api.Repositories;

public interface IDistributionRepository
{
    Task<bool> CreateAsync(DistributionDto distribution);
    Task<DistributionDto?> GetAsync(Guid id);
    Task<IEnumerable<DistributionDto>> GetAllAsync();
    Task<bool> UpdateAsync(DistributionDto distribution);
    Task<bool> DeleteAsync(Guid id);
}
