using DistroWatch.Api.Domain;

namespace DistroWatch.Api.Services;

public interface IDistributionService
{
    Task<bool> CreateAsync(Distribution distribution);
    Task<Distribution?> GetAsync(Guid id);
    Task<IEnumerable<Distribution>> GetAllAsync();
    Task<bool> UpdateAsync(Distribution distribution);
    Task<bool> DeleteAsync(Guid id);
}
