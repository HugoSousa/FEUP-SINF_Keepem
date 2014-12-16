<nav class="navbar navbar-default" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <a class="navbar-brand" href="index.php">Gestão de sistema de Fidelização</a>
        </div>

        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav">
                <li><a href="email_form.php">Newsletter</a></li>
                <li class="dropdown">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Gestão de descontos <span class="caret"></span></a>
                    <ul class="dropdown-menu" role="menu">
                        <li><a href="descontos_diretos.php">Descontos Directos (Famílias)</a>
                        </li>
                        <li><a href="descontos_pontos.php">Descontos Por Pontos</a>
                        </li>
                    </ul>
                </li>
                <li><a href="clientes.php">Clientes Fidelizados</a></li>

            </ul>
            <?php if ($logged) { ?>
            <button type="button" id="logout" class="btn btn-default navbar-btn navbar-right">Log out</button 
                <?php } ?>
                </div>
                <!-- /.navbar-collapse -->
                </div>
            <!-- /.container-fluid -->
            </nav>