<?php include("login.php"); ?>

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
</head>

<body>

    <div class="container">

        <div class="page-header">
            <h1>Sistema de Fidelização de Clientes <small>Login</small></h1>
        </div>

        <form class="form-signin" role="form" action="" method="post">
            <label for="inputEmail" class="sr-only">Código de Cliente</label>
            <input type="email" name="inputEmail" id="inputEmail" class="form-control" placeholder="E-mail" required autofocus>
            <br>
            <label for="inputPassword" class="sr-only">Password</label>
            <input type="password" name="inputPassword" id="inputPassword" class="form-control" placeholder="Password" required>
            <br>
            <button class="btn btn-lg btn-primary btn-block" name="submit" type="submit">Sign in</button>
        </form>
    </div>
</body>

</html>
