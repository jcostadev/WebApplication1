using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    interface IClienteService
    {
        void Insert(Cliente cliente);
        Cliente Get(int i);
        IEnumerable<Cliente> GetAll();
        void Delete(int id);
        void Update(Cliente cliente);
    }
}
