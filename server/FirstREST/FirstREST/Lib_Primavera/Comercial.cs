using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using Interop.ErpBS800;
using Interop.StdPlatBS800;
using Interop.StdBE800;
using Interop.GcpBE800;
using ADODB;
using Interop.IGcpBS800;
//using Interop.StdBESql800;
//using Interop.StdBSSql800;

namespace FirstREST.Lib_Primavera
{
    public class Comercial
    {

        
        public static List<Model.CartaoCliente> ListaCartoesClientes()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.CartaoCliente cli = new Model.CartaoCliente();
            List<Model.CartaoCliente> listCartoesClientes = new List<Model.CartaoCliente>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_CartaoCliente");

                while (!objList.NoFim())
                {
                    cli = new Model.CartaoCliente();
                    cli.CDU_idCartaoCliente = objList.Valor("CDU_idCartaoCliente");

                    listCartoesClientes.Add(cli);
                    objList.Seguinte();

                }

                return listCartoesClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.CartaoCliente GetCartaoCliente(string idCartaoCliente)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.CartaoCliente cli = null;


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_CartaoCliente");

                while (!objList.NoFim())
                {
                    if(objList.Valor("CDU_idCartaoCliente").Equals(idCartaoCliente))
                    {
                        cli = new Model.CartaoCliente();
                        cli.CDU_idCartaoCliente = objList.Valor("CDU_idCartaoCliente");

                        break;
                    }

                    objList.Seguinte();
                }

                if (cli != null)
                {
                    return cli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Model.CartaoCliente novoCartaoCliente()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.CartaoCliente cartaoCliente;
            List<Model.CartaoCliente> listCartoesClientes = new List<Model.CartaoCliente>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_CartaoCliente");

                StdBERegistoUtil registoUtil = new StdBERegistoUtil();
                StdBECampos campos = new StdBECampos();
                StdBECampo campoCDU_idCartaoCliente = new StdBECampo();

                campoCDU_idCartaoCliente.Nome = "CDU_idCartaoCliente";
                campoCDU_idCartaoCliente.Valor = Convert.ToString(objList.NumLinhas() + 1);

                campos.Insere(campoCDU_idCartaoCliente);

                registoUtil.set_Campos(campos);

                PriEngine.Engine.TabelasUtilizador.Actualiza("TDU_CartaoCliente", registoUtil);
   
                cartaoCliente = new Model.CartaoCliente();
                cartaoCliente.CDU_idCartaoCliente = Convert.ToString(objList.NumLinhas() + 1);

                return cartaoCliente;
            }

            return null;
        }


        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {
            ErpBS objMotor = new ErpBS();
             
            StdBELista objList;

            Model.Cliente cli = new Model.Cliente();
            List<Model.Cliente> listClientes = new List<Model.Cliente>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT *, NumContrib as NumContribuinte FROM CLIENTES");

                while (!objList.NoFim())
                {
                    cli = new Model.Cliente();
                    cli.CodCliente = objList.Valor("Cliente");
                    cli.NomeCliente = objList.Valor("Nome");
                    cli.NumContribuinte = objList.Valor("NumContribuinte");
                    cli.Moeda = objList.Valor("Moeda");
                    cli.CDU_Email = objList.Valor("CDU_Email");
                    cli.CDU_Password = objList.Valor("CDU_Password");
                    cli.CDU_idCartaoCliente = objList.Valor("CDU_idCartaoCliente");
                    string val = Convert.ToString(objList.Valor("CDU_Subscribed"));
                    if (val == "") cli.CDU_Subscribed = false;
                    else cli.CDU_Subscribed = Convert.ToBoolean(objList.Valor("CDU_Subscribed"));
                    listClientes.Add(cli);
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string id)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;
            StdBELista objList2;

            Model.Cliente cli = null;


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                //objList = PriEngine.Engine.Consulta("SELECT *, NumContrib as NumContribuinte FROM CLIENTES");
                objList = PriEngine.Engine.Consulta(@"SELECT Clientes.Cliente, Clientes.nome, Clientes.NumContrib AS NumContribuinte, Clientes.Moeda, Clientes.CDU_Email, Clientes.CDU_Password, Clientes.CDU_idCartaoCliente, Clientes.CDU_Subscribed, pontos.Pontos 
                                                    FROM 
	                                                    (SELECT ISNULL(SUM(t.CDU_Pontos),0) AS Pontos FROM Clientes, TDU_TransacaoPontos t LEFT JOIN TDU_CartaoCliente c
	                                                    ON t.CDU_idCartaoCliente = c.CDU_idCartaoCliente
	                                                    WHERE Clientes.Cliente = '" + id + @"'
	                                                    AND Clientes.CDU_idCartaoCliente = c.CDU_idCartaoCliente) pontos, Clientes
                                                    WHERE Clientes.Cliente = '" + id + @"'
                                                    GROUP BY Clientes.Cliente, Clientes.nome, Clientes.NumContrib, Clientes.Moeda, Clientes.CDU_Email, Clientes.CDU_Password, Clientes.CDU_idCartaoCliente,Clientes.CDU_Subscribed, pontos.Pontos");


                while (!objList.NoFim())
                {
                    if (objList.Valor("Cliente").Equals(id))
                    {

                        cli = new Model.Cliente();
                        cli.CodCliente = objList.Valor("Cliente");
                        cli.NomeCliente = objList.Valor("Nome");
                        cli.NumContribuinte = objList.Valor("NumContribuinte");
                        cli.Moeda = objList.Valor("Moeda");
                        cli.CDU_Email = objList.Valor("CDU_Email");
                        cli.CDU_Password = objList.Valor("CDU_Password");
                        cli.CDU_idCartaoCliente = objList.Valor("CDU_idCartaoCliente");
                        cli.Pontos = objList.Valor("Pontos");
                        string val = Convert.ToString(objList.Valor("CDU_Subscribed"));
                        if (val == "") cli.CDU_Subscribed = false;
                        else cli.CDU_Subscribed = Convert.ToBoolean(val);
                        if (cli.Pontos > 0)
                        {
                            objList2 = PriEngine.Engine.Consulta(@"SELECT TOP 1 transacoes.CDU_Pontos, (transacoes.CDU_DataExpiracao) As DataExpiracao FROM
                                                                (
	                                                                SELECT CDU_idTransacaoPontos, TDU_TransacaoPontos.CDU_Pontos, TDU_TransacaoPontos.CDU_DataExpiracao FROM TDU_TransacaoPontos, Clientes, TDU_CartaoCliente
	                                                                WHERE TDU_TransacaoPontos.CDU_idCartaoCliente = TDU_CartaoCliente.CDU_idCartaoCliente
	                                                                AND Clientes.CDU_idCartaoCliente = TDU_CartaoCliente.CDU_idCartaoCliente
	                                                                AND Clientes.Cliente = '" + id + @"' 
	                                                                AND CDU_DataExpiracao > CURRENT_TIMESTAMP
                                                                ) transacoes;");

                            cli.DataProximaExpiracao = objList2.Valor("DataExpiracao").ToString();
                            cli.PontosProximaExpiracao = objList2.Valor("CDU_Pontos");
                        }
                        else
                        {
                            cli.DataProximaExpiracao = null;
                            cli.PontosProximaExpiracao = 0;
                        }

                        break;
                    }

                    objList.Seguinte();
                }

                if (cli != null)
                {
                    return cli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {
            
            
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            ErpBS objMotor = new ErpBS();

           // GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {


                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {
                        /*
                        Model.CartaoCliente cartaoCliente = novoCartaoCliente();
                        
                        
                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        
                        objCli.set_Nome(cliente.NomeCliente);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Moeda(cliente.Moeda);
                        

                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);
                        */
                        
                        if(cliente.CDU_Subscribed)
                            PriEngine.Engine.Comercial.Clientes.ActualizaValorAtributo(cliente.CodCliente, "CDU_Subscribed", 1);
                        else
                            PriEngine.Engine.Comercial.Clientes.ActualizaValorAtributo(cliente.CodCliente, "CDU_Subscribed", 0);
                        


                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }

        public static Lib_Primavera.Model.RespostaErro UpdFamilia(Lib_Primavera.Model.Familia familia)
        {


            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            ErpBS objMotor = new ErpBS();

            GcpBEFamilia objFam = new GcpBEFamilia();

            try
            {

                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {


                    if (PriEngine.Engine.Comercial.Familias.Existe(familia.NomeFamilia) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "A familia nao existe";
                        return erro;
                    }
                    else
                    {
                        objFam = PriEngine.Engine.Comercial.Familias.Edita(familia.NomeFamilia);
                        objFam.set_EmModoEdicao(true);

                        PriEngine.Engine.Comercial.Familias.ActualizaValorAtributo(familia.NomeFamilia, "Descricao", familia.DescriFamilia);
                        PriEngine.Engine.Comercial.Familias.ActualizaValorAtributo(familia.NomeFamilia, "CDU_Desconto", familia.DescFamilia);


                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }

        public static Lib_Primavera.Model.RespostaErro UpdDescontosPontos(Lib_Primavera.Model.Desconto[] descontos)
        {

            StdBELista objList;

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            ErpBS objMotor = new ErpBS();

            GcpBEFamilia objFam = new GcpBEFamilia();

            try
            {

                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {

                    objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_TipoDesconto");
                    
                    while (!objList.NoFim())
                    {
                        StdBECamposChave x = new StdBECamposChave();
                        x.AddCampoChave("CDU_idTipoDesconto", objList.Valor("CDU_idTipoDesconto"));
                        PriEngine.Engine.TabelasUtilizador.Remove("TDU_TipoDesconto",x);
                      

                        objList.Seguinte();

                    }
                     

                    int count = 0;
                    foreach (Lib_Primavera.Model.Desconto d in descontos)
                    {
                        StdBERegistoUtil registoUtil = new StdBERegistoUtil();
                        StdBECampos campos = new StdBECampos();
                        StdBECampo campoCDU_idTipoDesconto = new StdBECampo();
                        StdBECampo campoCDU_TipoDesconto = new StdBECampo();
                        StdBECampo campoCDU_Pontos = new StdBECampo();

                        campoCDU_idTipoDesconto.Nome = "CDU_idTipoDesconto";
                        campoCDU_idTipoDesconto.Valor = Convert.ToString(count);

                        campoCDU_TipoDesconto.Nome = "CDU_Desconto";
                        campoCDU_TipoDesconto.Valor = Convert.ToString(d.desconto);

                        campoCDU_Pontos.Nome = "CDU_Pontos";
                        campoCDU_Pontos.Valor = Convert.ToString(d.pontos);

                        campos.Insere(campoCDU_idTipoDesconto);
                        campos.Insere(campoCDU_TipoDesconto);
                        campos.Insere(campoCDU_Pontos);

                        registoUtil.set_Campos(campos);

                        PriEngine.Engine.TabelasUtilizador.Actualiza("TDU_TipoDesconto", registoUtil);

                        count++;
                    }


                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }

        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {
            StdBELista objList;


            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
         
            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {
                    objList = PriEngine.Engine.Consulta("SELECT *, NumContrib as NumContribuinte FROM CLIENTES");

                    
                    myCli.set_Cliente(Convert.ToString(objList.NumLinhas() + 1));
                    myCli.set_Nome(cli.NomeCliente);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Moeda("EUR");
                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    Model.CartaoCliente cartaoCliente = novoCartaoCliente();

                    PriEngine.Engine.Comercial.Clientes.ActualizaValorAtributo(myCli.get_Cliente(), "CDU_Email", cli.CDU_Email);
                    PriEngine.Engine.Comercial.Clientes.ActualizaValorAtributo(myCli.get_Cliente(), "CDU_Password", cli.CDU_Password);
                    PriEngine.Engine.Comercial.Clientes.ActualizaValorAtributo(myCli.get_Cliente(), "CDU_idCartaoCliente", cartaoCliente.CDU_idCartaoCliente);


                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }

        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------


        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {
            

            GcpBEArtigo objArtigo = new GcpBEArtigo();
            Model.Artigo myArt = new Model.Artigo();

            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == false)
                {
                    return null;
                }
                else
                {
                    objArtigo = PriEngine.Engine.Comercial.Artigos.Edita(codArtigo);
                    myArt.CodArtigo = objArtigo.get_Artigo();
                    myArt.DescArtigo = objArtigo.get_Descricao();

                    return myArt;
                }
                
            }
            else
            {
                return null;
            }

        }

        public static List<Model.Artigo> GetArtigosDeFamilia(string familia)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta(@"SELECT a.Artigo, a.Descricao, round(am.PVP1*(1.0 + a.Desconto/100)*(1.0 + a.Iva/100.0),2) As Preco, MIN(cast(an.Id as varchar(250))) As Imagem FROM Artigo a
                                                    JOIN ArtigoMoeda am
                                                    ON a.Artigo = am.Artigo
                                                    LEFT JOIN Anexos an
                                                    ON (a.Artigo = an.Chave 
                                                    AND Tipo = 'IPR')
                                                    WHERE a.Familia = '" + familia + @"'
                                                    GROUP BY a.Artigo, a.Descricao, round(am.PVP1*(1.0 + a.Desconto/100)*(1.0 + a.Iva/100.0),2);");
                while (!objList.NoFim())
                {
                    art = new Model.Artigo();
                    art.CodArtigo = objList.Valor("Artigo");
                    art.DescArtigo = objList.Valor("Descricao");
                    art.Preco = objList.Valor("Preco");
                    art.Imagem = objList.Valor("Imagem");

                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }


        public static List<Model.Artigo> ListaArtigos()
        {
            ErpBS objMotor = new ErpBS();
           
            StdBELista objList;

            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta(@"SELECT a.Artigo, a.Descricao, round(am.PVP1*(1.0 + a.Desconto/100)*(1.0 + a.Iva/100.0),2) As Preco, MIN(cast(an.Id as varchar(250))) AS Imagem 
                                                    FROM Artigo a
                                                    JOIN ArtigoMoeda am
                                                    ON a.Artigo = am.Artigo
                                                    LEFT JOIN Anexos an
                                                    ON (a.Artigo = an.Chave 
                                                    AND Tipo = 'IPR')
                                                    GROUP BY a.Artigo, a.Descricao, round(am.PVP1*(1.0 + a.Desconto/100)*(1.0 + a.Iva/100.0),2);");

                while (!objList.NoFim())
                {
                    art = new Model.Artigo();
                    art.CodArtigo = objList.Valor("Artigo");
                    art.DescArtigo = objList.Valor("Descricao");
                    art.Preco = objList.Valor("Preco");
                    art.Imagem = objList.Valor("Imagem");

                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }

        }



        //------------------------------------ ENCOMENDA ---------------------
        /*
        public static Model.RespostaErro TransformaDoc(Model.DocCompra dc)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoCompra objEnc = new GcpBEDocumentoCompra();
            GcpBEDocumentoCompra objGR = new GcpBEDocumentoCompra();
            GcpBELinhasDocumentoCompra objLinEnc = new GcpBELinhasDocumentoCompra();
            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();

            List<Model.LinhaDocCompra> lstlindc = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany("BELAFLOR", "sa", "123456") == true)
                {
                

                    objEnc = PriEngine.Engine.Comercial.Compras.Edita("000", "ECF", "2013", 3);

                    // --- Criar os cabeçalhos da GR
                    objGR.set_Entidade(objEnc.get_Entidade());
                    objEnc.set_Serie("2013");
                    objEnc.set_Tipodoc("ECF");
                    objEnc.set_TipoEntidade("F");

                    objGR = PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(objGR,rl);
 

                    // façam p.f. o ciclo para percorrer as linhas da encomenda que pretendem copiar
                     
                        double QdeaCopiar;
                        PriEngine.Engine.Comercial.Internos.CopiaLinha("C", objEnc, "C", objGR, lin.NumLinha, QdeaCopiar);
                       
                        // precisamos aqui de um metodo que permita actualizar a Qde Satisfeita da linha de encomenda.  Existe em VB mas ainda não sei qual é em c#
                       
                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(objEnc, "");
                    PriEngine.Engine.Comercial.Compras.Actualiza(objGR, "");

                    PriEngine.Engine.TerminaTransaccao();

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        
        
        }

        */




        // ------------------------ Documentos de Compra --------------------------//

        public static List<Model.DocCompra> VGR_List()
        {
            ErpBS objMotor = new ErpBS();
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>(); 

            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;
                    
                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }



        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.Entidade);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR, rl);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.Desconto);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }
        


        // ------ Documentos de venda ----------------------



        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();
             
            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();
             
            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();
            
            try
            {
                if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                   // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        public static List<Model.DocVenda> Encomendas_List()
        {
            ErpBS objMotor = new ErpBS();
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, TotalIva, TotalDesc, Serie, CDU_DescontoFidelizacao, CDU_PontosUsados From CabecDoc where TipoDoc='FA'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.PrecoFinal = Math.Round(objListCab.Valor("TotalMerc") + objListCab.Valor("TotalIva") - objListCab.Valor("TotalDesc"),2);
                    dv.Serie = objListCab.Valor("Serie");
                    dv.DescontoFidelizacao = objListCab.Valor("CDU_DescontoFidelizacao");
                    dv.PontosUsados = objListCab.Valor("CDU_PontosUsados");



                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, CDU_DescontoFidelizacao from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindv.DescontoFidelizacao = objListLin.Valor("CDU_DescontoFidelizacao");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }


        public static Model.DocVenda Encomenda_Get(string numdoc)
        {
            ErpBS objMotor = new ErpBS();
             
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {

                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, TotalIva, TotalDesc, Serie, CDU_DescontoFidelizacao, CDU_PontosUsados From CabecDoc where TipoDoc='FA' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);

                if(objListCab.NoFim())
                    return null;

                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.PrecoFinal = Math.Round(objListCab.Valor("TotalMerc") + objListCab.Valor("TotalIva") - objListCab.Valor("TotalDesc"), 2);
                dv.Serie = objListCab.Valor("Serie");
                dv.DescontoFidelizacao = objListCab.Valor("CDU_DescontoFidelizacao");
                dv.PontosUsados = objListCab.Valor("CDU_PontosUsados");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, CDU_DescontoFidelizacao from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    lindv.DescontoFidelizacao = objListLin.Valor("CDU_DescontoFidelizacao");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        public static List<Model.DocVenda> Encomenda_GetByCliente(string cliente)
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, TotalIva, TotalDesc, Serie, CDU_DescontoFidelizacao, CDU_PontosUsados From CabecDoc where TipoDoc='FA' AND Entidade='" + cliente + "'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.PrecoFinal = Math.Round(objListCab.Valor("TotalMerc") + objListCab.Valor("TotalIva") - objListCab.Valor("TotalDesc"),2);
                    dv.Serie = objListCab.Valor("Serie");
                    dv.DescontoFidelizacao = objListCab.Valor("CDU_DescontoFidelizacao");
                    dv.PontosUsados = objListCab.Valor("CDU_PontosUsados");



                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, CDU_DescontoFidelizacao from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindv.DescontoFidelizacao = objListLin.Valor("CDU_DescontoFidelizacao");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }


    //------------------------------------ LISTA FAMILIAS COM DESCONTO DIRETO

        public static List<Model.Familia> ListaFamiliasDescontoDireto()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Familia fam = new Model.Familia();
            List<Model.Familia> listFamilias = new List<Model.Familia>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT Familia, Descricao, CDU_Desconto FROM Familias WHERE Familias.CDU_Desconto <> 0");

                while (!objList.NoFim())
                {
                    fam = new Model.Familia();
                    fam.NomeFamilia = objList.Valor("Familia");
                    fam.DescriFamilia = objList.Valor("Descricao");

                    fam.DescFamilia = objList.Valor("CDU_Desconto");

                    listFamilias.Add(fam);
                    objList.Seguinte();

                }

                return listFamilias;
            }
            else
                return null;
        }

        //------------------------------------ LISTA FAMILIAS

        public static List<Model.Familia> ListaFamilias()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Familia fam = new Model.Familia();
            List<Model.Familia> listFamilias = new List<Model.Familia>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT Familia, Descricao, CDU_Desconto FROM Familias");

                while (!objList.NoFim())
                {
                    fam = new Model.Familia();
                    fam.NomeFamilia = objList.Valor("Familia");
                    fam.DescriFamilia = objList.Valor("Descricao");

                    String CDU_desconto = System.Convert.ToString(objList.Valor("CDU_Desconto"));
                    if (CDU_desconto == "" || CDU_desconto == null) fam.DescFamilia = 0;
                    else fam.DescFamilia = objList.Valor("CDU_Desconto");
                   

                    listFamilias.Add(fam);
                    objList.Seguinte();

                }

                return listFamilias;
            }
            else
                return null;
        }

        //------------------------------------ LISTA DESCONTOS COM PONTOS

        public static List<Model.Desconto> ListaDescontosPontos()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Desconto desc = new Model.Desconto();
            List<Model.Desconto> listDescontos = new List<Model.Desconto>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_TipoDesconto");

                while (!objList.NoFim())
                {
                    desc = new Model.Desconto();
                    desc.pontos = objList.Valor("CDU_Pontos");
                    desc.desconto = objList.Valor("CDU_Desconto");

                    listDescontos.Add(desc);
                    objList.Seguinte();

                }

                return listDescontos;
            }
            else
                return null;
        }

        //------------------------------------ LISTA Funcionarios

        public static List<Model.Funcionario> ListaFuncionarios()
        {
            ErpBS objMotor = new ErpBS();

            StdBELista objList;

            Model.Funcionario desc = new Model.Funcionario();
            List<Model.Funcionario> list = new List<Model.Funcionario>();


            if (PriEngine.InitializeCompany("PRIBELA", "", "") == true)
            {
                objList = PriEngine.Engine.Consulta("SELECT * FROM TDU_Funcionario");

                while (!objList.NoFim())
                {
                    desc = new Model.Funcionario();
                    desc.username = objList.Valor("CDU_username");
                    desc.password = objList.Valor("CDU_password");

                    list.Add(desc);
                    objList.Seguinte();

                }

                return list;
            }
            else
                return null;
        }
    }
}