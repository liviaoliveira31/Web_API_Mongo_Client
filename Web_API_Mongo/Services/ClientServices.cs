using MongoDB.Driver;
using System.Collections.Generic;
using Web_API_Mongo.Models;
using Web_API_Mongo.Utils;

namespace Web_API_Mongo.Services
{
    public class ClientServices
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);
        }

        //Insert
        public Client Create(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        //Get All
        public List<Client> Get() => _clients.Find<Client>(client => true).ToList();

        //Get One
        public Client Get(string Id) => _clients.Find<Client>(client => client.Id == Id).FirstOrDefault();

        public void Update(string id, Client clientIn)
        {
            _clients.ReplaceOne(client => client.Id == id, clientIn);
           // Get(clientIn.Id);
        }

        public void Remove(Client clientIn) => _clients.DeleteOne(client => client.Id == client.Id);








    }

  
}
