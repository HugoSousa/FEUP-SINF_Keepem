<?php
$result; 
$default_from_email = "newsletter@pribela.pt";
$default_subject_email = "Informações sobre novas oportunidades para clientes fidelizados";


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
?>