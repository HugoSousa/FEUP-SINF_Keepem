VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
END
Attribute VB_Name = "EditorVendas"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = True
  
    Dim discountPointsUsed As Integer
    
Private Sub EditorVendas_AntesDeGravar(Cancel As Boolean)
    
    Dim line As String
    Dim lineCounter As Long
    Dim strSQL As String
    Dim allLines As String
    Dim totalDiscount As Double
    Dim precoTotal As Double
    Dim pontosCliente As Long
    
    ' PlataformaPRIMAVERA.Dialogos.MostraAviso Me.DocumentoVenda.DescFinanceiro
    ' PlataformaPRIMAVERA.Dialogos.MostraAviso Me.DocumentoVenda.DescEntidade
    
    
    If Me.DocumentoVenda.TipoDoc = "FA" Then
        discountPointsUsed = 0
        strSQL = vbNullString
        
        strSQL = "SELECT Clientes.CDU_idCartaoCliente, TDU_CartaoCliente.CDU_Pontos FROM Clientes, TDU_CartaoCliente "
        strSQL = strSQL & "WHERE Cliente = '"
        strSQL = strSQL & Me.DocumentoVenda.Entidade
        strSQL = strSQL & "' AND Clientes.CDU_idCartaoCliente = TDU_CartaoCliente.CDU_idCartaoCliente"
        
        Set pontosClienteQuery = Aplicacao.BSO.Consulta(strSQL)
        
        
        If Not pontosClienteQuery.NoFim Then
        
            pontosCliente = pontosClienteQuery.Valor(1)
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "SOU FIDELIZADO"
            
            
            ' verificar se este cliente é fidelizado (tem idCartao != null ?)
            
            
            strSQL = vbNullString
            ' query a BD para achar as familias com desconto de cartao -> select distinct familia from artigo where familia.descontoCartao != null
            strSQL = strSQL & "SELECT DISTINCT Familia FROM Familias WHERE Familias.CDU_Desconto IS NOT NULL OR Familias.CDU_Desconto != 0"
            
            Set FamiliasDesconto = Aplicacao.BSO.Consulta(strSQL)
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso FamiliasDesconto.Valor(0) ' acede ao nome da familia que tem desconto
            
            

            
            ' objLista.Seguinte
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso objLista.Valor(0)
            
            ' If Not (objLista Is Nothing) Then
                ' PlataformaPRIMAVERA.Dialogos.MostraAviso objLista(1)
            ' End If
            
            allLines = vbNullString
            totalDiscount = 0
            precoTotal = 0
            For lineCounter = 1 To Me.DocumentoVenda.Linhas.NumItens
                
                line = Me.DocumentoVenda.Linhas(lineCounter).Artigo
                allLines = allLines & line
                
                strSQL = "SELECT COALESCE  ( "
                strSQL = strSQL & "(SELECT CDU_Desconto "
                strSQL = strSQL & "FROM Artigo, Familias "
                strSQL = strSQL & "WHERE Familias.Familia = Artigo.Familia "
                strSQL = strSQL & "AND (Familias.CDU_Desconto IS NOT NULL "
                strSQL = strSQL & "OR Familias.CDU_Desconto != 0)"
                strSQL = strSQL & "AND Artigo.Artigo = '"
                strSQL = strSQL & line
                strSQL = strSQL & "'), 0)"
                
                ' retorna true se tem desconto, e false se não tem
                Set familiaArtigo = Aplicacao.BSO.Consulta(strSQL)
                
                
                TotalIlLiquido = Me.DocumentoVenda.Linhas(lineCounter).TotalIliquido
                DescontoComercial = Me.DocumentoVenda.Linhas(lineCounter).DescontoComercial
                TaxaIva = Me.DocumentoVenda.Linhas(lineCounter).TaxaIva
                
                If familiaArtigo.Valor(0) > 0 Then
                    ' somar desconto deste artigo ao desconto total -> percentagem do desconto * preco do artigo * quantidade
        
                    
                    precoAntigo = (TotalIlLiquido - DescontoComercial) * ((100 + TaxaIva) / 100)
                    precoNovo = (TotalIlLiquido - DescontoComercial - (TotalIlLiquido) * (familiaArtigo.Valor(0) / 100)) * ((100 + TaxaIva) / 100)
                    descontoLinha = precoAntigo - precoNovo
                    totalDiscount = totalDiscount + descontoLinha
                    precoTotal = precoTotal + precoNovo
                    ' PlataformaPRIMAVERA.Dialogos.MostraAviso "Fica por:" + CStr(Round(precoNovo, 2))
                    ' PlataformaPRIMAVERA.Dialogos.MostraAviso "Poupa" + CStr(descontoLinha)
                Else
                
                    ' PlataformaPRIMAVERA.Dialogos.MostraAviso "NAO TEM DESCONTO"
                    precoAntigo = (TotalIlLiquido - DescontoComercial) * ((100 + TaxaIva) / 100)
                    precoTotal = precoTotal + precoAntigo
                End If
        
            Next lineCounter
            totalDiscount = totalDiscount * ((100 - Me.DocumentoVenda.DescEntidade) / 100)
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "PRECO FINALLLLLLL:" + CStr(TotalIlLiquido)
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "NO FINAL por:" + CStr(Round(precoTotal, 2))
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "NO FINAL poupa" + CStr(totalDiscount)

            ' percorrer novamente as linhas
            ' para cada linha em artigo com desconto no cartão, editar o campo desconto do artigo e somar a percentagem adequeada
            ' remover pontos usados do cartao
            
                lineCounter = 0
                
                For lineCounter = 1 To Me.DocumentoVenda.Linhas.NumItens
                    line = Me.DocumentoVenda.Linhas(lineCounter).Artigo
                    
                    strSQL = "SELECT COALESCE  ( "
                    strSQL = strSQL & "(SELECT CDU_Desconto "
                    strSQL = strSQL & "FROM Artigo, Familias "
                    strSQL = strSQL & "WHERE Familias.Familia = Artigo.Familia "
                    strSQL = strSQL & "AND (Familias.CDU_Desconto IS NOT NULL "
                    strSQL = strSQL & "OR Familias.CDU_Desconto != 0)"
                    strSQL = strSQL & "AND Artigo.Artigo = '"
                    strSQL = strSQL & line
                    strSQL = strSQL & "'), 0)"
                    
                    Set familiaArtigo = Aplicacao.BSO.Consulta(strSQL)
                    ValorDesconto = familiaArtigo.Valor(0)
                    
                    ' PlataformaPRIMAVERA.Dialogos.MostraAviso "FOR FINAL: " + CStr(ValorDesconto)
                    
                    If ValorDesconto > 0 Then
                        descontoAtual = Me.DocumentoVenda.Linhas(lineCounter).Desconto1
                        descontoNovo = descontoAtual + ValorDesconto
                        Me.DocumentoVenda.Linhas(lineCounter).Desconto1 = descontoNovo
                        
                        ' PlataformaPRIMAVERA.Dialogos.MostraAviso "DESCONTO FINALISSIMO: " + CStr(Me.DocumentoVenda.Linhas(lineCounter).Desconto1)
                    End If
                     
                Next lineCounter

            ' verificar se o utilizador tem pontos suficiente para aplicar um desconto
            ' se sim, mostrar combobox para utilizador desconto que quer aplicar
            strSQL = "SELECT CDU_Desconto, CDU_Pontos FROM TDU_TipoDesconto"
            Set tiposDesconto = Aplicacao.BSO.Consulta(strSQL)
            
            tamanhoLista = 0
            
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "CLIENTE TEM PONTOS: " + CStr(pontosCliente)
            
            Dim descontosPossiveis() As String
            Dim pontosNecessarios() As String
            
            For counter = 1 To tiposDesconto.NumLinhas
                pontos = tiposDesconto.Valor(1)
                If pontos <= pontosCliente Then
                    ReDim Preserve descontosPossiveis(tamanhoLista)
                    ReDim Preserve pontosNecessarios(tamanhoLista)
                    descontosPossiveis(tamanhoLista) = tiposDesconto.Valor(0)
                    pontosNecessarios(tamanhoLista) = tiposDesconto.Valor(1)
                    tamanhoLista = tamanhoLista + 1
                End If
                tiposDesconto.Seguinte
            Next counter
                        
            Dim listaComboBox() As String
            ReDim listaComboBox(tamanhoLista, 1)
            listaComboBox(0, 0) = " - "
            listaComboBox(0, 1) = " - "
            For counter = 1 To tamanhoLista
                listaComboBox(counter, 0) = descontosPossiveis(counter - 1) + " %"
                listaComboBox(counter, 1) = pontosNecessarios(counter - 1) + " pontos"
            Next counter
            
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "DESCONTO DIRETO TOTAL: " + CStr(totalDiscount)
            ' PlataformaPRIMAVERA.Dialogos.MostraAviso "PRECO FINAL: " + CStr(Me.DocumentoVenda.TotalDocumento - totalDiscount)
             
            UserForm1.priceBeforeClientDiscount = Me.DocumentoVenda.TotalDocumento
            UserForm1.priceBeforeDiscount = Me.DocumentoVenda.TotalDocumento - totalDiscount
            UserForm1.directDiscountBox = Round(totalDiscount, 2)
            UserForm1.priceWithoutDiscountBox = Round(Me.DocumentoVenda.TotalDocumento - totalDiscount, 2)
            UserForm1.priceWithDiscountBox = Round(Me.DocumentoVenda.TotalDocumento - totalDiscount, 2)
            UserForm1.actualPointsBox = pontosCliente
            UserForm1.afterPointsBox = pontosCliente + Int(Me.DocumentoVenda.TotalDocumento - totalDiscount)
            UserForm1.ComboBox1.ColumnCount = 2
            UserForm1.ComboBox1.List = listaComboBox
            UserForm1.ComboBox1.BoundColumn = 1
            UserForm1.ComboBox1.ListIndex = 0
            UserForm1.Show
             
            If UserForm1.ComboBox1.SelText <> " - " Then
                ' Aplicar o desconto da combobox
                Dim pontosArray() As String
                
                If UserForm1.ComboBox1.ListIndex = -1 Then
                    descontoPercentagem = 0
                Else
                    If (UserForm1.ComboBox1.List(UserForm1.ComboBox1.ListIndex, 0) <> " - ") Then
                        pontosArray = Split(UserForm1.ComboBox1.List(UserForm1.ComboBox1.ListIndex, 0), " ")
                        descontoPercentagem = pontosArray(0)
                        pontosUsadosArray = Split(UserForm1.ComboBox1.List(UserForm1.ComboBox1.ListIndex, 1), " ")
                        discountPointsUsed = pontosUsadosArray(0)
                    End If
                    
                End If
                
                ' PlataformaPRIMAVERA.Dialogos.MostraAviso Int(descontoPercentagem)
                Me.DocumentoVenda.DescEntidade = Me.DocumentoVenda.DescEntidade + Int(descontoPercentagem)
                 
            End If
            
            
            ' Cancel = True
            

        End If
    End If
End Sub


Private Sub EditorVendas_DepoisDeGravar(Filial As String, Serie As String, Tipo As String, NumDoc As Long)

  ' PlataformaPRIMAVERA.Dialogos.MostraAviso Filial + " " + Serie + " " + Tipo + " " + CStr(NumDoc)
 
   Dim TotalPreco As Double
    Dim strSQL As String
    Dim chave As StdBECamposChave
    Dim PontosAtuais As Integer
    Dim NovosPontos As Integer
    
    Set chave = Nothing
      
    If Me.DocumentoVenda.TipoDoc = "FA" Then
    
        strSQL = vbNullString
        
        strSQL = "SELECT Clientes.CDU_idCartaoCliente, TDU_CartaoCliente.CDU_Pontos FROM Clientes, TDU_CartaoCliente "
        strSQL = strSQL & "WHERE Cliente = '"
        strSQL = strSQL & Me.DocumentoVenda.Entidade
        strSQL = strSQL & "' AND Clientes.CDU_idCartaoCliente = TDU_CartaoCliente.CDU_idCartaoCliente"
        
        Set clienteFidelizado = Aplicacao.BSO.Consulta(strSQL)
      End If
        If Not clienteFidelizado.NoFim Then
           ' Cliente fidelizado

            Set chave = New StdBECamposChave
            chave.AddCampoChave "CDU_idCartaoCliente", clienteFidelizado.Valor(0)
 
            PontosAtuais = CInt(clienteFidelizado.Valor(1))
            NovosPontos = PontosAtuais + Int(Me.DocumentoVenda.TotalDocumento) - discountPointsUsed
            
            Aplicacao.BSO.TabelasUtilizador.ActualizaValorAtributo "TDU_CartaoCliente", chave, "CDU_Pontos", NovosPontos

        Else
          ' Cliente nao fidelizado
        End If
        
End Sub


