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
    <script src="js/novoCliente.js"></script>
</head>

<body>

    <div class="container">

        <div class="page-header">
            <h1>Sistema de Fidelização de Clientes <small>Novo Cliente</small></h1>
        </div>

        <form id="formNovoCliente" class="form-signin" role="form">
            <label for="inputNomeCliente" class="sr-only">NomeCliente</label>
            <input type="text" name="NomeCliente" id="inputNomeCliente" class="form-control" placeholder="Nome">
            <br>
            <label for="inputNumContribuinte" class="sr-only">NumContribuinte</label>
            <input type="text" name="NumContribuinte" id="inputNumContribuinte" class="form-control" placeholder="Número de Contribuinte">
            <br>
            <label for="inputEmail" class="sr-only">E-Mail</label>
            <input type="email" name="CDU_Email" id="inputEmail" class="form-control" placeholder="E-mail">
            <br>
            <label for="inputPassword" class="sr-only">Password</label>
            <input type="password" name="CDU_Password" id="inputPassword" class="form-control" placeholder="Password">
            <br>
            <button type="submit" id="newClientButton" class="btn btn-lg btn-default btn-block">Criar Cliente</button>
        </form>

    </div>
</body>

</html>
