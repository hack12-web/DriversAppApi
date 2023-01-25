using DriversAppApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DriversAppApi.Services
{
    public class DriverService
    {
        private readonly IMongoCollection<Driver> _driverCollection;
        private readonly IMongoCollection<Messenger> _messengerCollection;
        public DriverService(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDb = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _driverCollection = mongoDb.GetCollection<Driver>(databaseSettings.Value.CollectionName);
            _messengerCollection = mongoDb.GetCollection<Messenger>(databaseSettings.Value.CollectionName);
        }
        
        //Drivers
        public async Task<List<Driver>> GetAsync() => await _driverCollection.Find(_ => true).ToListAsync();
        public async Task<Driver> GetAsync(string id) => await _driverCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(Driver driver) => await _driverCollection.InsertOneAsync(driver);
        public async Task UpdateAsync(Driver driver) => await _driverCollection.ReplaceOneAsync(x => x.Id == driver.Id, driver);
        public async Task DeleteAsync(string id) => await _driverCollection.DeleteOneAsync(x => x.Id == id);

        //Messengers
        public async Task<List<Messenger>> GetMessenger() => await _messengerCollection.Find(_ => true).ToListAsync();
    }
}