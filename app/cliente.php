<?php include("navbar.php"); ?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel="icon" href="../../favicon.ico">

    <title>Sistema de Fidelização de Clientes</title>

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

        <h4>Nome do Cliente: <span id="nomeCliente" class="label label-primary"></span></h4>
        <br>
        <h4>Número de Contribuinte: <span id="numContribuinte" class="label label-primary"></span></h4>
        <br>
        <br>
        <h4 id="cartaoClienteH4">ID Cartão de Cliente: <span id="cartaoCliente" class="label label-info"></span> <button type="submit" id="criarCartaoCliente" class="btn btn-lg btn-info btn-block">Criar Cartão de Cliente</button></h4>
        <br>
        <h4 id="pontosH4">Pontos: <span id="pontos" class="label label-info"></span></h4>
    </div>
</body>

</html>
