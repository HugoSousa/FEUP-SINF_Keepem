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
    public class DescontosDiretosController : ApiController
    {
        // GET: DescontosDiretos
        public IEnumerable<Lib_Primavera.Model.Familia> Get()
        {
            return Lib_Primavera.Comercial.ListaFamiliasDescontoDireto();

        }
    }
}