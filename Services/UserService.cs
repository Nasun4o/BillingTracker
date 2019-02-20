namespace BillingTracker.Services
{
    using MongoDB.Driver;
    using BillingTracker.Models;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class UserService
    {
        private readonly IMongoCollection<UsersModel> _users;

        public UserService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("BillingDB"));
            var database = client.GetDatabase("BillingDB");
            _users = database.GetCollection<UsersModel>("UserDetails");
        }

        public List<UsersModel> GetAll()
        {
            return _users.Find(u => true).ToList();
        }
        public UsersModel GetById(string id)
        {
            return _users.Find<UsersModel>(u => u.Id == id).FirstOrDefault();
        }

        public UsersModel Create(UsersModel user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<UsersModel> Create(List<UsersModel> users)
        {
            _users.InsertMany(users);
            return users;
        }

        public void Update(string id, UsersModel userModel)
        {
            _users.ReplaceOne(s => s.Id == id, userModel);
        }

        public void Remove(UsersModel userModel)
        {
            _users.DeleteOne(d => d.Id == userModel.Id);
        }
        public void Remove(string id)
        {
            _users.DeleteOne(s => s.Id == id);
        }
    }
}