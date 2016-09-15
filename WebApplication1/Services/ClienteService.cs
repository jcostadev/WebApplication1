using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class ClienteService : IClienteService
    {
        private readonly Models.UnitOfWork _cUnitOfwork;

        public ClienteService()
        {
            _cUnitOfwork = new Models.UnitOfWork();
        }

        public Cliente Get(int i)
        {
            return _cUnitOfwork.Clientes.Get(i);
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _cUnitOfwork.Clientes.GetAll();
        }

        public void Delete(int id)
        {
            _cUnitOfwork.Clientes.Delete(id);            
        }

        public void Insert(Cliente cliente)
        {
            _cUnitOfwork.Clientes.Add(cliente);
        }

        public void Update(Cliente cliente) 
        {
            _cUnitOfwork.Clientes.Update(cliente, cliente.ID);
        }
    }

}