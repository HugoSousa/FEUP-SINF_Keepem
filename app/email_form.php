<?php
$result; 
$default_from_email = "newsletter@pribela.pt";
$default_subject_email = "Informações sobre novas oportunidades para clientes fidelizados";

if (isset($_POST['do']) && strcmp($_POST['do'],"send") == 0)
{

    if (!isset($_POST['from']) || !isset( $_POST['content']) || !isset( $_POST['subject']) || !isset( $_POST['to'])) {
        $result['error'] = "Missing parameters";
        echo json_encode($result);

    }
    else {
        $from = $_POST['from'];
        $text = $_POST['content'];
        $subj = $_POST['subject'];
        $to = $_POST['to'];

        $ehead = "From: ".$from."\r\n";
        
        $mailsend=mail("$to",htmlspecialchars("$subj"),htmlspecialchars("$text"),"$ehead"."\nContent-Type: text/html; charset=UTF-8\n");
        $message = "Email was sent.";
        $result['result'] = $mailsend;
        unset($_POST['do']);
        echo json_encode($result); 
    }
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
            var default_subject = "<?php echo $default_subject_email ?>";
            var default_from = "<?php echo $default_from_email ?>";
            var familias = null;
            var descontosPontos = null;
            var count = 0;
            function loadDefaultValues() {


                $('#subject').val(default_subject);
                $('#from').val(default_from);
                var content = getEmailContent();
                $('#content').val(content.text);
                $('#content').attr('rows', content.lines);
                $('.loading_icon').hide();

                $('form').show();
            }


            function loadPromotionData() {

                $.ajax({
                    type: "GET",
                    url: "http://localhost:49822/api/descontosdiretos/",
                    dataType: "json",
                    success: function (resp) {

                        console.log("Ddiretos: " + resp);
                        familias = resp;
                        $.ajax({
                            type: "GET",
                            url: "http://localhost:49822/api/descontospontos/",
                            dataType: "json",
                            success: function (resp) {

                                console.log("Dpontos: " + resp);
                                descontosPontos = resp;
                                if ($("#checkbox1").is(":checked"))
                                    loadDefaultValues();



                            },
                            error: function (e) {
                                alert("Erro ao recolher dados dos pontos!");
                            }
                        });

                    },
                    error: function (e) {
                        alert("Erro ao recolher dados dos descontos por famílias!");
                    }
                });







            }

            function getEmailContent() {
                var email = []
                var linecounter = 8;
                /*
             $.ajax({
                    type: "GET",
                    url: "http://localhost:49822/api/clientes/",
                    dataType: "json",
                    success: function (resp) {

                        console.log(resp);

                    },
                    error: function (e) {
                        alert("Erro ao recolher dados do cliente!");
                    }
                });
*/
                email.push("Aproveite todas a promoções exclusivas a clientes fidelizados!");
                email.push("Este mês, todos os artigos da categorias seguintes têm desconto direto em cartão:");
                email.push("");
                if (familias == null || descontosPontos == null) return {text: "", lines: 0};

                if (familias.lenght == 0)  {
                    linecounter++;
                    email.push("Nenhuma categoria em desconto"); 
                }
                else {
                    familias.forEach(function (familia) {
                        linecounter++;
                        email.push(familia.DescriFamilia + " - " + familia.DescFamilia + " %" );
                    });
                }
                email.push("");

                email.push("Use também os seu pontos para obter descontos no valor total duma compra. Neste momento tem <CAMPOPONTOS>");
                email.push("");
                if (descontosPontos.lenght == 0)  {
                    linecounter++;
                    email.push("Nenhum desconto em pontos disponível"); 
                }
                else {
                    descontosPontos.forEach(function (pontos) {
                        linecounter++;
                        console.log(pontos);
                        email.push(pontos.pontos + " pontos - " + pontos.desconto + " %" );
                    });
                }
                email.push(""); 
                email.push("Venha visitar-nos e aproveite!"); 





                return {text: email.join('\n'), lines: linecounter};
            }

            $(document).ready(function () {
                $('form').attr('hidden',true);

                $('#checkbox1').change(function() {

                    var ischecked = $(this).is(":checked");
                    $(".email_field").attr("disabled", ischecked);

                    if (ischecked) {
                        loadDefaultValues();
                    }

                });

                $('#checkbox1').attr("checked", true);
                loadPromotionData();

                $('form').on('submit', function() {
                    $('.submit').attr("disabled", true);
                    var content = $('#content').val();
                    var from = $('#from').val();
                    var subject = $('#subject').val();

                    if (content.indexOf("<CAMPOPONTOS>") == -1) {
                        alert("O email deve conter o <CAMPOPONTOS> para ser preenchido com os pontos de cada cliente");  
                        $('.submit').attr("disabled", false);  
                        return false; 
                    }
                    else {
                        $.ajax({
                            type: "GET",
                            url: "http://localhost:49822/api/clientes/",
                            dataType: "json",
                            success: function (resp) {
                                var emails = 0;
                                resp.forEach(function (client) {
                                    if (client.CDU_Email != "") emails ++;
                                });
                                resp.forEach(function (client) {
                                    if (client.CDU_Email != "")
                                        $.ajax({
                                            type: "GET",
                                            url: "http://localhost:49822/api/clientes/" +  client.CodCliente ,
                                            dataType: "json",
                                            success: function (resp) {
                                                console.log(resp);
                                                $.ajax({
                                                    type: "POST",
                                                    url: "email_form.php",
                                                    dataType: "json",
                                                    data: {do: "send"},
                                                    success: function (resp) {
                                                        console.log(resp);

                                                    },
                                                    error: function (e) {
                                                        alert("Erro ao enviar email");
                                                    }
                                                });  

                                            },
                                            error: function (e) {
                                                alert("Erro ao recolher dados do cliente!");
                                            }
                                        });  
                                });

                            },
                            error: function (e) {
                                alert("Erro ao recolher dados dos clientes!");
                            }
                        });  

                    }

                    return false; 
                });

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
                    <div class="row loading_icon">
                        <div class="col-xs-3 col-centered ">
                            <span class="glyphicon glyphicon-repeat glyphicon-repeat-animate"></span> 
                        </div>
                    </div>
                    <form class="form-horizontal" role="form" action="email_form.php?do=send" method="POST" >
                        <div class="form-group">
                            <label class="col-sm-1 control-label" >From</label>
                            <div class="col-sm-10">
                                <input type="email" id="from" class="form-control email_field" id="from" placeholder="Enter email" value="" disabled>
                            </div>
                        </div>
                        <div class="form-group">

                            <label class="col-sm-1 control-label" >Subject</label>
                            <div class="col-sm-10">
                                <input type="text" id="subject" class="form-control email_field" placeholder="Subject" value="" disabled>
                            </div>
                        </div>


                        <div class="form-group">
                            <label class="col-sm-1 control-label" >Content</label>
                            <div class="col-sm-10">
                                <textarea id="content" class="form-control email_field" rows="0" disabled></textarea>
                                <p class="help-block">You can use this area to customize the email to send</p>

                            </div>
                        </div>
                        <div class="checkbox form-group">
                            <div class="col-sm-offset-1 col-sm-10">
                                <label class="control-label">
                                    <input id="checkbox1" type="checkbox"> Send default email
                                </label>
                            </div>
                        </div>
                        <br/>
                        <div class="form-group">
                            <div class="col-sm-offset-1 col-sm-10">
                                <button class="submit" type="submit" class="btn btn-default">Send Newsletter</button>
                            </div>
                        </div>
                    </form>
                </div>


                </body>
            </html>

        <?php
     }
        ?>