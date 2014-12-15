using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstREST.Lib_Primavera.Model;
using System.Web.Http.Cors;
using System.Diagnostics;


namespace FirstREST.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DocVendaClienteController : ApiController
    {

        // GET api/docvendacliente/  
        public IEnumerable<Lib_Primavera.Model.DocVenda> Get(string id)
        {
            string cliente = id;
            IEnumerable<Lib_Primavera.Model.DocVenda> docvenda = Lib_Primavera.Comercial.Encomenda_GetByCliente(cliente);
            if (docvenda == null)
            {
                throw new HttpResponseException(
                        Request.CreateResponse(HttpStatusCode.NotFound));

            }
            else
            {
                return docvenda;
            }
        }





    }
}
