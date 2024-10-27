using System.Data;

namespace DistroWatch.Api.Database;

public interface IDbConnectionFactory
{
    public Task<IDbConnection> CreateConnectionAsync();
}
