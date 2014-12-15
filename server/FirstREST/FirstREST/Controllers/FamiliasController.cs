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
    //GET api/familias
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FamiliasController : ApiController
    {
        public IEnumerable<Lib_Primavera.Model.Familia> Get()
        {
            return Lib_Primavera.Comercial.ListaFamilias();
        }

        //POST api/familias

        public HttpResponseMessage Post(Lib_Primavera.Model.Familia familia)
        {
            Lib_Primavera.Model.RespostaErro erro = new Lib_Primavera.Model.RespostaErro();

            try
            {
                erro = Lib_Primavera.Comercial.UpdFamilia(familia);
                if (erro.Erro == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, erro.Descricao);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, erro.Descricao);
                }
            }

            catch (Exception exc)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, erro.Descricao);
            }
        }
    }
}