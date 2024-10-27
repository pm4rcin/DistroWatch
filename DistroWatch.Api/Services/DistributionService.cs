using DistroWatch.Api.Domain;
using DistroWatch.Api.Mapping;
using DistroWatch.Api.Repositories;

using FluentValidation;
using FluentValidation.Results;

namespace DistroWatch.Api.Services;

public class DistributionService : IDistributionService
{
    private readonly IDistributionRepository _distributionRepository;

    public DistributionService(IDistributionRepository distributionRepository)
    {
        _distributionRepository = distributionRepository;
    }

    public async Task<bool> CreateAsync(Distribution distribution)
    {
        var distroExists = await _distributionRepository.GetAsync(distribution.Id.Value);
        if (distroExists is not null)
        {
            var message = $"Distro with id {distribution.Id} is already present";
            throw new ValidationException(message, new[]
            {
                new ValidationFailure(nameof(Distribution), message)
            });
        }
        var distributionDto = distribution.ToDistributionDto();
        return await _distributionRepository.CreateAsync(distributionDto);
    }


    public async Task<IEnumerable<Distribution>> GetAllAsync()
    {
        var distributionDtos = await _distributionRepository.GetAllAsync();
        return distributionDtos.Select(x => x.ToDistribution());
    }

    public async Task<Distribution?> GetAsync(Guid id)
    {
        var distributionDto = await _distributionRepository.GetAsync(id);
        return distributionDto?.ToDistribution();
    }

    public async Task<bool> UpdateAsync(Distribution distribution)
    {
        var distributionDto = distribution.ToDistributionDto();
        return await _distributionRepository.UpdateAsync(distributionDto);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        return await _distributionRepository.DeleteAsync(id);
    }
}
