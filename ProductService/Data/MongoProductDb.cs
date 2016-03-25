using System.Threading.Tasks;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using ProductService.Model;

namespace ProductService.Data
{
    public class MongoProductDb
    {
        protected static IMongoClient _client;
        protected static IMongoDatabase _database;
        private IMongoCollection<Product> _collection;
        private const string ConnectionString = "mongodb://127.0.0.1:27017";

        static MongoProductDb()
        {
            _client = new MongoClient(ConnectionString);
            _database = _client.GetDatabase("test");
        }

        public MongoProductDb()
        {
            _collection = _database.GetCollection<Product>("products");
        }

        public async Task<string> InsertOrder(Product product)
        {
            string id = Guid.NewGuid().ToString();
            product.Id = id;
            await _collection.InsertOneAsync(product);
            return id;
        }

        public async Task<Product> GetOrder(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            List<Product> orders = await _collection.Find(filter).ToListAsync();
            return orders.FirstOrDefault();
        }
    }
}
