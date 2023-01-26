using DriversAppApi;
using DriversAppApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DriversAppApi.Services
{
    public class MessengerService
    {
        private readonly IMongoCollection<Messenger> _messengerCollection;
        public MessengerService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _messengerCollection = mongoDb.GetCollection<Messenger>(databaseSettings.Value.CollectionNameMessenger);
        }

        public async Task<List<Messenger>> GetAsync() => await _messengerCollection.Find(_ => true).ToListAsync();
        public async Task<Messenger> GetAsync(string id) => await _messengerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Messenger messenger) => await _messengerCollection.InsertOneAsync(messenger);
        public async Task UpdateAsync(Messenger messenger) => await _messengerCollection.ReplaceOneAsync(x => x.Id == messenger.Id, messenger);
        public async Task DeleteAsync(string id) => await _messengerCollection.DeleteOneAsync(x => x.Id == id);
    }
}