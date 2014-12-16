<?php include("navbar.php"); ?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="shortcut icon" href="images/favicon.ico">
    <title>Keep'em</title>

    <!-- Bootstrap core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom styles for this template -->
    <!-- <link href="signin.css" rel="stylesheet"> -->

    <script src="js/jquery-1.11.1.min.js"></script>
    <script src="js/cliente.js"></script>
</head>

<body>

    <div class="container">

		<div class="page-header">
            <h3>O Meu Perfil <small>Cliente</small></h3>
        </div>
		
		<div style="text-align:center; margin-top:50; margin-bottom:50">
			<h3>Newsletter</h3>
			<div class="btn-group" role="group" id="subscribe_group">
			  <button type="button" class="btn btn-default" id="subscribe_button">Subscribe</button>
			  <button type="button" class="btn btn-default" id="unsubscribe_button">Unsubscribe</button>
			</div>
		</div>
		

        <h4><span style="display: inline-block; width:20%">Nome do Cliente:</span><span id="nomeCliente" class="label label-primary"></span></h4>
        <br>
        <h4><span style="display: inline-block; width:20%">Número de Contribuinte:</span><span id="numContribuinte" class="label label-primary"></span></h4>
        <br>
        <h4 id="cartaoClienteH4"><span style="display: inline-block; width:20%">ID Cartão de Cliente:</span><span id="cartaoCliente" class="label label-primary"></span> <button type="submit" id="criarCartaoCliente" class="btn btn-lg btn-info btn-block">Criar Cartão de Cliente</button></h4>
        <br>
        <h4 id="pontosH4"><span style="display: inline-block; width:20%">Pontos:</span><span id="pontos" class="label label-primary"></span></h4>
		
		
    </div>
</body>

</html>
