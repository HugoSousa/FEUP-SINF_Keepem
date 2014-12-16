using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstREST.Lib_Primavera.Model
{
    public class Cliente
    {

        public string CodCliente
        {
            get;
            set;
        }

        public string NomeCliente
        {
            get;
            set;
        }

        public string NumContribuinte
        {
            get;
            set;
        }

        public string Moeda
        {
            get;
            set;
        }

        public string CDU_Email
        {
            get;
            set;
        }

        public string CDU_Password
        {
            get;
            set;
        }

        public string CDU_idCartaoCliente
        {
            get;
            set;
        }

        public bool CDU_Subscribed
        {
            get;
            set;
        }

        public int Pontos
        {
            get;
            set;
        }

        public string DataProximaExpiracao
        {
            get;
            set;
        }

        public int PontosProximaExpiracao
        {
            get;
            set;
        }

    }
}