using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using WebApplication1.Models;

namespace WebApplication1.Models
{
#warning Refatorar com interface

    public class Repository<T> where T : Cliente
    {   
       protected static IMongoDatabase _database;
       protected static IMongoCollection<T> _collection;

       public Repository(IMongoClient client, string tblName, string collName)
       {           
           _database = client.GetDatabase(tblName);
           _collection = _database.GetCollection<T>(collName);                                                
       }
     
       public void Add(T entity) 
       {            
           _collection.InsertOne(entity);
       }

       public T Get(int id) 
       {
         var data = _collection.Find<T>(x => x.ID == id);

         return data?.First();
       }

       public void Delete(int id) 
       {
            var filter = Builders<T>.Filter.Where(e => e.ID == id);
            _collection.DeleteOne(filter);
           
       }
      

       public void Update(T entity, int id) 
       {
           var filter = Builders<T>.Filter.Where(e => e.ID == id);

           var update = _collection.ReplaceOne(filter, entity);                
       }

        public IEnumerable<T> GetAll()
        {
            var filter = new JsonFilterDefinition<T>("{}");
            
            var t = _collection.Find<T>(filter);

             var data = t.ToList<T>();

            return data;
        }


    }
}