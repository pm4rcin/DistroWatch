using Dapper;

namespace DistroWatch.Api.Database;

public class DatabaseInitializer
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DatabaseInitializer(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task InitializeAsync()
    {
        using var connection = await _connectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync(
            @"CREATE TABLE IF NOT EXISTS Distributions(
					Id Char(36) PRIMARY KEY,
					Name TEXT NOT NULL,
					Creator TEXT NOT NULL,
					WebPageURL TEXT NOT NULL,
					DateOfBirth TEXT NOT NULL
					)"
        );
    }
}
