<!DOCTYPE html>
<html lang="en">

    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="description" content="">
        <meta name="author" content="">
        <link rel="icon" href="images/favicon.ico">
        <title>Keep'em</title>

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
                <h1>Keep'em <small>Novo Cliente</small></h1>
            </div>

            <form id="formNovoCliente" class="form-signin form-horizontal" role="form">
                <div class="form-group">
                    <label for="inputNomeCliente" class="col-sm-2 control-label">NomeCliente</label>
                    <div class="col-sm-10">
                        <input type="text" name="NomeCliente" id="inputNomeCliente" class="form-control" placeholder="Nome">
                    </div>
                </div>
                <div class="form-group">

                    <label for="inputNumContribuinte" class="col-sm-2 control-label">NumContribuinte</label>
                    <div class="col-sm-10">
                        <input type="text" name="NumContribuinte" id="inputNumContribuinte" class="form-control" placeholder="Número de Contribuinte">
                    </div>
                </div>

                <div class="form-group">

                    <label for="inputEmail" class="col-sm-2 control-label">E-Mail</label>
                    <div class="col-sm-10">

                        <input type="email" name="CDU_Email" id="inputEmail" class="form-control" placeholder="E-mail">
                    </div>
                </div>

                <div class="form-group">
                    <label for="inputPassword" class="col-sm-2 control-label">Password</label>
                    <div class="col-sm-10">
                        <input type="password" name="CDU_Password" id="inputPassword" class="form-control" placeholder="Password">
                    </div>
                </div>
                <div class=" col-sm-10 col-sm-offset-2" style="padding:0px">
                    <button type="submit" id="newClientButton" class="btn btn-lg btn-default btn-block">Criar Cliente</button>
                </div>

            </form>

        </div>
    </body>

</html>
