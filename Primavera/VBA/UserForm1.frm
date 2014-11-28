VERSION 5.00
Begin {C62A69F0-16DC-11CE-9E98-00AA00574A4F} UserForm1 
   Caption         =   "Fidelização Clientes - Descontos"
   ClientHeight    =   5160
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   8670
   OleObjectBlob   =   "UserForm1.frx":0000
   StartUpPosition =   1  'CenterOwner
End
Attribute VB_Name = "UserForm1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Public clickedButton As Boolean
Public priceBeforeDiscount As Double
Public priceBeforeClientDiscount As Double


Private Sub CommandButton1_Click()
    clickedButton = True
    Me.hide
End Sub

Private Sub ComboBox1_Change()
    
    Dim newPrice As Double
    
    If Me.ComboBox1.ListIndex <> -1 Then
        If Me.ComboBox1.List(Me.ComboBox1.ListIndex, 0) = " - " Then
            newPrice = priceBeforeDiscount
            Me.priceWithDiscountBox.Value = Round(newPrice, 2)
            Me.afterPointsBox.Value = Me.actualPointsBox + Int(priceBeforeDiscount)
        Else
            Dim percentagemArray() As String
            percentagemArray = Split(Me.ComboBox1.List(Me.ComboBox1.ListIndex, 0), " ")
            
            newPrice = priceBeforeDiscount * (100 - CInt(percentagemArray(0))) / 100
            Me.priceWithDiscountBox.Value = Round(newPrice, 2)
            
            Dim pontosArray() As String
            pontosArray = Split(Me.ComboBox1.List(Me.ComboBox1.ListIndex, 1), " ")
            
            Me.afterPointsBox = Me.actualPointsBox + Int(priceBeforeDiscount) - CInt(pontosArray(0))
        End If
        
    End If
    

End Sub

Private Sub CommandButton2_Click()
    clickedButton = False
    Me.hide
End Sub
