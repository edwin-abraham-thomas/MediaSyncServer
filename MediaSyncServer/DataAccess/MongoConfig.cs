using Core.Database.MongoDB;

namespace MediaSyncServer.DataAccess;

public class MongoConfig : IMongoConfig
{
    public string MongoConnectionString { get; set; }
    public string MongoDatabaseName { get; set; }
}