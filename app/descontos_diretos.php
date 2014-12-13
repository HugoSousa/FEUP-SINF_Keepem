<?php include("navbar.php"); ?>
<script src="js/descontos_diretos.js"></script>
<div class="container">

    <h3 class="text-center" style="margin-bottom:20px">Categorias em Desconto </h3>

    <div class="dropdown text-center">
        <a class="btn btn-default dropdown-toggle" type="button" id="dropdownMenu1" data-toggle="dropdown" aria-expanded="true" href="#" style="width: 30%">
            <span id="dropdown_title">Select Category</span>
            <span class="caret" </span>
        </a>
        <ul class="dropdown-menu text-center" role="menu" aria-labelledby="dropdownMenu1" id="dropdown_list" style="width: 30%; margin-left:35%">
            <!--
		<li role="presentation"><a role="menuitem" tabindex="-1" href="#">Tinteiros</a></li>
		<li role="presentation"><a role="menuitem" tabindex="-1" href="#">Impressoras</a></li>
		<li role="presentation"><a role="menuitem" tabindex="-1" href="#">Papel</a></li>
		<li role="presentation"><a role="menuitem" tabindex="-1" href="#">DVD's</a></li>
		-->
        </ul>
    </div>

    <h2 class="text-center hide show-category"><span id="desconto_direto_familia">X</span>% Desconto Direto</h2>
    <p class="text-center hide show-category">nos seguintes produtos</p>

    <div id="produtos" style="margin-top:50">

            
			

	</div>

</div>

</body>

</html>