using System;
using System.Collections.Generic;
using System.IO;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Hotel.Services
{
    public class MongoDbServiceRepository : IServiceRepository
    {
        private const string databaseName = "ServiceDb";
        private const string collectionName = "Services";

        private readonly IMongoCollection<Service> _services;
        private readonly FilterDefinitionBuilder<Service> filterBuilder = Builders<Service>.Filter;

        public MongoDbServiceRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _services = database.GetCollection<Service>(collectionName);
        }

        public IEnumerable<Service> Get()
        {
            return _services.Find(new BsonDocument()).ToList();
        }

        public Service Get(string id)
        {
            var filter = filterBuilder.Eq(service => service.Id, id);
            return _services.Find<Service>(filter).FirstOrDefault();
        }

        public void Edit(string id, Service service)
        {
            _services.ReplaceOne(service => service.Id == id, service);
            
        }
        public Service Create(Service service)
        {
            _services.InsertOne(service);
            return service;
        }

        public void Remove(string id)
        {
            _services.DeleteOne(service => service.Id == id);
        }
    }
}
