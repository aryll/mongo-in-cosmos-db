using System;

namespace MongoCosmosDb.Example
{
    //this project is only to gather details how to connect and handle data on CosmosDB with MongoDB API
    class Program
    {
        static void Main(string[] args)
        {
            //this should be done by dependency injection
            var service = new ItemsService();

            service.Create(new Item());

            var itemGuid = Guid.Parse("52ee9ba6-bee7-4770-b868-8435c4b3f13f");
            var item1 = service.Get(itemGuid);
            var item2 = service.GetWithSerialization(itemGuid);

            service.Remove(item1);
            
            var all = service.GetAll();
        }
    }
}
