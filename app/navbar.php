<?php include( "session.php"); ?>

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
    <link rel="shortcut icon" href="images/favicon.ico">
    <title>Keep'em</title>

    <script src="/js/jquery.min.js"></script>
    <script src="/js/jquery.dataTables.min.js"></script>
    <script src="/js/dataTables.bootstrap.js"></script>
    <script src="/js/bootstrap.min.js"></script>

    <script>
        $(document).ready(function () {
            
            $("#logout").click(function () {
                window.location.href = "logout.php";
            });
			
			$(".nav a").on("click", function(){
				console.log("A");
			   //$(".nav").find(".active").removeClass("active");
			   //$(this).parent().addClass("active");
			});

        });
    </script>
</head>

<body>
    <nav class="navbar navbar-default" role="navigation">
	
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
				<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse">
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
				</button>
                <a class="navbar-brand">Keep'em</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="navbar-collapse">
                <ul class="nav navbar-nav">
                    <li style="text-align:center"><a href="cliente.php?codCliente=<?php echo $_SESSION['codCliente'];?>">O Meu Perfil</a>
                    </li>
                    <li class="dropdown" style="text-align:center">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Descontos <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li style="text-align:center"><a href="descontos_diretos.php?codCliente=<?php echo $_SESSION['codCliente'];?>">Descontos Directos</a>
                            </li>
                            <li style="text-align:center"><a href="descontos_pontos.php?codCliente=<?php echo $_SESSION['codCliente'];?>">Descontos Pontos</a>
                            </li>
                        </ul>
                    </li>
                    <li style="text-align:center"><a href="historico.php?codCliente=<?php echo $_SESSION['codCliente'];?>">Histórico</a>
                    </li>
                </ul>
				<ul class="nav navbar-nav navbar-right">
					<li style="text-align:center"><a><?php echo $_SESSION['nomeCliente'];?></a></li>
					<li style="text-align:center"><button type="button" id="logout" class="btn btn-default navbar-btn">Log Out</button></li>
				</ul>
				
                <!-- <button type="button" id="logout" class="btn btn-default navbar-btn navbar-right">Log out</button </div> -->
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
    </nav>
