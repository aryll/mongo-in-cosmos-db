using System;
using System.Collections.Generic;
using System.Security.Authentication;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoCosmosDb.Example
{
    public class ItemsService
    {
        //this should be in configuration
        // when exception appears add '&retrywrites=false' in the end of connection string
        private const string ConnectionString = "";
        private const string DbName = "Tasks";
        private const string CollectionName = "TasksList";

        private readonly IMongoCollection<Item> _tasks;

        public ItemsService()
        {
            var client = new MongoClient(ConnectionString);
            var database = client.GetDatabase(DbName);

            _tasks = database.GetCollection<Item>(CollectionName);
        }

        public void Create(Item book) => _tasks.InsertOne(book);

        public void Remove(Item bookIn) => _tasks.DeleteOne(book => book.Id == bookIn.Id);

        public List<Item> GetAll() => _tasks.Find(book => true).ToList();

        public Item Get(Guid id) => _tasks.Find(book => book.Id == id).SingleOrDefault();

        public string GetWithSerialization(Guid id) => _tasks.Find(book => book.Id == id).SingleOrDefault().ToJson();
    }
}
