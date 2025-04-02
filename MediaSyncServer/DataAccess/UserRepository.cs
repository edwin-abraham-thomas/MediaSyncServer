using Core.Database.MongoDB;
using MediaSyncServer.Models;
using Microsoft.Extensions.Options;

namespace MediaSyncServer.DataAccess;

public class UserRepository : BaseMongoRepository<User>
{
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(IMongoConfig mongoConfig, ILogger<UserRepository> logger) : base(mongoConfig)
    {
        _logger = logger;
    }
}
