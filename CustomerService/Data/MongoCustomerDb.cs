using CustomerService.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data
{
    class MongoCustomerDb
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private IMongoCollection<Customer> _collection;
        private const string ConnectionString = "mongodb://192.168.99.100:27017";

        static MongoCustomerDb()
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase("test");
        }

        public MongoCustomerDb()
        {
            _collection = _database.GetCollection<Customer>("customers");
        }

        public async Task<string> InsertOrder(Customer customer)
        {
            string id = Guid.NewGuid().ToString();
            customer.Id = id;
            await _collection.InsertOneAsync(customer);
            return id;
        }

        public async Task<Customer> GetOrder(string id)
        {
            var filter = Builders<Customer>.Filter.Eq(x => x.Id, id);
            List<Customer> orders = await _collection.Find(filter).ToListAsync();
            return orders.FirstOrDefault();
        }
    }
}
