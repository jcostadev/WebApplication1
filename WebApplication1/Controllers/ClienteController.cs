using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using WebApplication1.Services;
using System.Linq;

namespace WebApplication1.Controllers {
    /// <summary>
    /// 
    /// </summary>
    public class ClienteController : ApiController {
        private readonly IClienteService _clienteService;

        public ClienteController() {
            _clienteService = new ClienteService();
        }

        /// <summary>
        /// sdsd
        /// </summary>
        /// <param name="cliente"></param>
        public void Post([FromBody]Cliente cliente) {
            //sdsd
            _clienteService.Insert(cliente);
        }

        public IHttpActionResult Get(int id) {
#warning Separar em camadas
#warning Moq
#warning Simple Inject
#warning Tem muitos retornos. Bom um só.
#warning Comentário
            try {
                var cliente = _clienteService.Get(id);
                if (cliente != null) return ResponseMessage(Request.CreateResponse<Cliente>(HttpStatusCode.OK, cliente));

            } catch (Exception e) {
#warning InterServerError sem msg adicional
#warning Logar o erro em arq, txt. c:\sdsda\log.txt
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Client not founded for provided ID."));
            }

            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Client not founded for provided ID."));

        }

        public IHttpActionResult GetAll() {
#warning try catch em tudo
            var cliente = _clienteService.GetAll();

            if (cliente != null && cliente.Any()) return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, cliente));

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "No client found."));
        }

#warning  [FromBody]  [FromUri]
        public IHttpActionResult Put(int id, [FromBody]Cliente cliente) {
            if (cliente != null) {
                _clienteService.Update(cliente);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Cliente não localizado para alteração."));
        }


        public IHttpActionResult Delete(int id) {
            var cliente = _clienteService.Get(id);

            if (cliente != null) {
                _clienteService.Delete(id);
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "Cliente não localizado"));
        }



    }
}
