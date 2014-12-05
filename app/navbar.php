<?php include("session.php"); ?>

<html>

<head>

    <!-- Bootstrap -->
    <!-- <link href="../css/bootstrap.min.css" rel="stylesheet"> -->

    <!-- <script type="text/javascript" src="../js/bootstrap.min.js"></script> -->

    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="/css/bootstrap.min.css">
    <link rel="stylesheet" href="/css/dataTables.bootstrap.css">

    <link rel="stylesheet" href="/css/style.css" type="text/css">

    <script src="/js/jquery.min.js"></script>
    <script src="/js/jquery.dataTables.min.js"></script>
    <script src="/js/dataTables.bootstrap.js"></script>
    <script src="/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            $('#historico_table').dataTable({
                "searching": false,
                'aoColumnDefs': [{
                    'bSortable': false,
                    'aTargets': ['nosort']
				}]
            });

            $('#descontos_table').dataTable({
                "searching": false,
                "ordering": false,
                "columns": [
                    {
                        "data": "pontos"
                    },
                    {
                        "data": "desconto"
                    }
       ]
            });


            $("#logout").click(function () {
                window.location.href = "logout.php";
            });

        });
    </script>
</head>

<body>
    <div class="container">
        <nav class="navbar navbar-default" role="navigation">
            <div class="container-fluid">
                <!-- Brand and toggle get grouped for better mobile display -->
                <div class="navbar-header">
                    <a class="navbar-brand" href="index.php">Sistema de Fidelização de Clientes</a>
                </div>

                <!-- Collect the nav links, forms, and other content for toggling -->
                <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                    <ul class="nav navbar-nav">
                        <li><a href="cliente.php?codCliente=<?php echo $_SESSION['codCliente'];?>">O Meu Perfil</a>
                        </li>
                        <li class="dropdown">
                            <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Descontos <span class="caret"></span></a>
                            <ul class="dropdown-menu" role="menu">
                                <li><a href="descontos_diretos.php?codCliente=<?php echo $_SESSION['codCliente'];?>">Descontos Directos</a>
                                </li>
                                <li><a href="descontos_pontos.php?codCliente=<?php echo $_SESSION['codCliente'];?>">Descontos Pontos</a>
                                </li>
                            </ul>
                        </li>
                        <li><a href="historico.php">Histórico</a>
                        </li>
                    </ul>

                    <button type="button" id="logout" class="btn btn-default navbar-btn navbar-right">Log out</button </div>
                    <!-- /.navbar-collapse -->
                </div>
                <!-- /.container-fluid -->
        </nav>
        </div>
