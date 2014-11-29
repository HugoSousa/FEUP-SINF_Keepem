<html>

	<head>

		<!-- Bootstrap -->
	<!-- <link href="../css/bootstrap.min.css" rel="stylesheet"> -->

	<!-- <script type="text/javascript" src="../js/bootstrap.min.js"></script> -->

		<meta charset="utf-8">
		<meta name="viewport" content="width=device-width, initial-scale=1">
		<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.min.css">
		<link rel="stylesheet" href="http://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/bootstrap/3/dataTables.bootstrap.css">
		
		<link rel="stylesheet" href="../css/style.css" type="text/css">

		<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
		<script src="http://cdn.datatables.net/1.10.4/js/jquery.dataTables.min.js"></script>
		<script src="http://cdn.datatables.net/plug-ins/9dcbecd42ad/integration/bootstrap/3/dataTables.bootstrap.js"></script>	
		<script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
	
		<script>
			$(document).ready(function() {
				$('#historico_table').dataTable({
					"searching": false,
					'aoColumnDefs': [{
						'bSortable': false,
						'aTargets': ['nosort']
					}]
				});
				
				$('#descontos_table').dataTable({
					"searching": false,
					"ordering": false
				});
				
				$('#dropdown_list li a').on('click', function() {
					console.log("FIRED");
					$('#dropdown_title').html($(this).html());
				});
			});
			

		</script>
	</head>

	<body>

		<nav class="navbar navbar-default" role="navigation">
			<div class="container-fluid">
				<!-- Brand and toggle get grouped for better mobile display -->
				<div class="navbar-header">
					<button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
					<span class="sr-only">Toggle navigation</span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					<span class="icon-bar"></span>
					</button>
					<a class="navbar-brand" href="#">Fidelização de Clientes</a>
				</div>

				<!-- Collect the nav links, forms, and other content for toggling -->
				<div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
					<ul class="nav navbar-nav">

					<li><a href="#">Perfil</a></li>

					<li class="dropdown">
						<a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Descontos <span class="caret"></span></a>
						<ul class="dropdown-menu" role="menu">
							<li><a href="#">Desconto Pontos</a></li>
							<li><a href="#">Desconto Imediato</a></li>
						</ul>
					</li>


					<li><a href="historico.php">Histórico</a></li>


					</ul>
					
					<button type="button" class="btn btn-default navbar-btn navbar-right">Log out</button>
				   

			</div><!-- /.navbar-collapse -->
		</div><!-- /.container-fluid -->
	</nav>
		

