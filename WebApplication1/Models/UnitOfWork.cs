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
    public class UnitOfWork 
    {
        protected Repository<Cliente> _cliente;
        IMongoClient _client;

        public UnitOfWork()
        {           
            _client = new MongoClient();      
        }

        public Repository<Cliente> Clientes 
        {
            get 
            {
                if (_cliente == null)
                    _cliente = new Repository<Cliente>(_client, "Pessoa", "Cliente");

                return _cliente;
            }
        }
    }

}