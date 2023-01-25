using DriversAppApi;
using DriversAppApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MessengerService.Services
{
    public class MessengerService
    {
        private readonly IMongoCollection<Messenger> _messengerCollection;
        public MessengerService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            
        }
    }
}