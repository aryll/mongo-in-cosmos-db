using System;

namespace MongoCosmosDb.Example
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Item()
        {
            Id = Guid.NewGuid();
            Name = "ABC";
        }
    }
}
