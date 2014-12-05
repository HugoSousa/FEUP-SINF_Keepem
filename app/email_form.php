<?php
$result; 

if (isset($_GET['do']) && strcmp($_GET['do'],"send") == 0)
{

    $from = $_POST['from'];
    $text = $_POST['content'];
    $emess = $text;
    $to = "ei11084@fe.up.pt";

    $ehead = "From: ".$from."\r\n";
    $subj = "<CLIENTNAME> aproveita as promoÇões deste mês!";
    $mailsend=mail("$to",htmlspecialchars("$subj"),htmlspecialchars("$emess"),"$ehead"."\nContent-Type: text/html; charset=UTF-8\n");
    $message = "Email was sent.";
    $result['result'] = $mailsend;
    unset($_GET['do']);
    echo json_encode($result); 

}
else { // missing parameters
?><!DOCTYPE html>
<html >

    <head>
        <meta charset="utf-8">
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <meta name="description" content="">
        <meta name="author" content="">
        <link rel="icon" href="../../favicon.ico">

        <title>Envio de NewsLetter</title>

        <link href="css/bootstrap.min.css" rel="stylesheet">

        <link rel="stylesheet" href="/css/style.css" type="text/css">

        <script src="/js/jquery.min.js"></script>
        <script src="/js/bootstrap.js"></script>
        <script src="/js/jquery.dataTables.min.js"></script>
        <script src="/js/dataTables.bootstrap.js"></script>
         <script>
        $(document).ready(function () {
             $('.dropdown-toggle')
            /*
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
            */


            $("#logout").click(function () {
                window.location.href = "logout.php";
            });

        });
    </script>
    </head>
    <body>
        <nav class="navbar navbar-default" role="navigation">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <a class="navbar-brand" href="index.php">Gestão de sistema de Fidelização</a>
            </div>

            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav">
                    <li><a >Newsletter</a></li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">Gestão de descontos <span class="caret"></span></a>
                        <ul class="dropdown-menu" role="menu">
                            <li><a href="descontos_diretos.php?codCliente=">Descontos Directos (Famílias)</a>
                            </li>
                            <li><a href="descontos_pontos.php?codCliente=>">Descontos Por Pontos</a>
                            </li>
                        </ul>
                    </li>
                </ul>

                <button type="button" id="logout" class="btn btn-default navbar-btn navbar-right">Log out</button </div>
                <!-- /.navbar-collapse -->
            </div>
            <!-- /.container-fluid -->
    </nav>

        <p></p>
        <div class="container">
            <form class="form-horizontal" role="form" action="email_form.php?do=send" method="POST" >
                <div class="form-group">
                    <label class="col-sm-1 control-label" >From</label>
                    <div class="col-sm-10">
                        <input type="email" id="to" class="form-control" id="from" placeholder="Enter email">
                    </div>
                </div>
                <div class="form-group">

                    <label class="col-sm-1 control-label" >Subject</label>
                    <div class="col-sm-10">
                        <input type="email" id="subject" class="form-control" placeholder="Subject">
                    </div>
                </div>

                <div class="checkbox form-group">
                    <div class="col-sm-offset-1 col-sm-10">
                        <label class="control-label">
                            <input type="checkbox" checked="true"> Send default email
                        </label>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-sm-1 control-label" >Content</label>
                    <div class="col-sm-10">
                        <textarea id="content" class="form-control" rows="7" ></textarea>
                        <p class="help-block">You can use this area to customize the email to send</p>

                    </div>
                </div>
                <div class="col-sm-offset-1 col-sm-10">
                    <button type="submit" class="btn btn-default">Submit</button>
                </div>
            </form>
        </div>


    </body>
</html>

<?php
}
?>