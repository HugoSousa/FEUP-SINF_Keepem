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
            <h1>Perfil <small>Cliente</small></h1>
        </div>

        <h3>Nome do Cliente: <span id="nomeCliente" class="label label-primary"></span></h3>
        <br>
        <h3>Número de Contribuinte: <span id="numContribuinte" class="label label-primary"></span></h3>
        <br>
        <br>
        <h3 id="cartaoClienteH3">ID Cartão de Cliente: <span id="cartaoCliente" class="label label-info"></span> <button type="submit" id="criarCartaoCliente" class="btn btn-lg btn-info btn-block">Criar Cartão de Cliente</button></h3>
        <br>
        <h3 id="pontosH3">Pontos: <span id="pontos" class="label label-info"></span></h3>
    </div>
</body>

</html>
