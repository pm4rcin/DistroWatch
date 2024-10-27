using Dapper;

using DistroWatch.Api.Data;
using DistroWatch.Api.Database;

namespace DistroWatch.Api.Repositories;

public class DistributionRepository : IDistributionRepository
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DistributionRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> CreateAsync(DistributionDto distribution)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"INSERT INTO Distributions (Id, Name, Creator, WebPageURL, DateOfBirth)
        VALUES(@Id, @Name, @Creator, @WebPageURL, @DateOfBirth)",
            distribution
        );
        return result > 0;
    }

    public async Task<DistributionDto?> GetAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<DistributionDto>(
            "SELECT * FROM Distributions WHERE Id = @Id LIMIT 1",
            new { Id = id.ToString() }
        );
    }

    public async Task<IEnumerable<DistributionDto>> GetAllAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        return await connection.QueryAsync<DistributionDto>("SELECT * FROM Distributions");
    }

    public async Task<bool> UpdateAsync(DistributionDto distribution)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"UPDATE Distributions SET Name = @Name, Creator = @Creator, WebPageURL = @WebPageURL,
        DateOfBirth = @DateOfBirth WHERE Id = @Id",
            distribution
        );
        return result > 0;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        var result = await connection.ExecuteAsync(
            @"DELETE FROM Distributions WHERE Id = @Id",
            new { Id = id.ToString() }
        );
        return result > 0;
    }
}
