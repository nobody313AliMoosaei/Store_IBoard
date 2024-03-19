using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.BL.Services.MongoDB
{
    public class MongoDbService<Collection>
    {
        private IMongoCollection<Collection> _collection;
        public MongoDbService(IConfiguration config)
        {
            var client = new MongoClient(config["MongoDBSetting:MongoDb"]);
            var _mongoDb = client.GetDatabase(config["MongoDBSetting:DataBaseName"]);
            _collection = _mongoDb.GetCollection<Collection>(typeof(Collection).Name);
        }




    }
}
