using Core.Database.MongoDB.Interfaces;

namespace MediaSyncServer.Models
{
    public class User : IMongoDocument
    {
        public string _id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Device> Devices { get; set; }
    }

    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
