<?php
if (isset($_GET['do']) && strcmp($_GET['do'],"send") == 0)
 {

       $result; 
       $from = $_POST['from'];
       $text = $_POST['content'];
       $emess = $text;
       $to = $_POST['to'];
     
       $ehead = "From: ".$from."\r\n";
       $subj = "%CLIENTNAME% aproveita as promoÇões deste mês!";
       $mailsend=mail("$to",htmlspecialchars("$subj"),htmlspecialchars("$emess"),"$ehead"."\nContent-Type: text/html; charset=UTF-8\n");
       $message = "Email was sent.";
       $result['result'] = $mailsend;
       unset($_GET['do']);
      echo json_encode($result);

 }
    else {
?>


<html>
<body>
<form action="email_form.php?do=send" method="POST">
<p>* Required fields</p>
<?php
   if (isset($message) && strcmp($message, "") != 0) echo '<p style="color:red;">'.$message.'</p>';
?>
   <table border="0" width="500">
     <tr><td align="right">From: </td>
         <td><input type="text" name="from" size="30" value="<?php isset($from) ? $from :   "info@pribela.pt" ?>"></td></tr>
     <tr><td align="right">To: </td>
         <td><input type="text" name="mname" size="30" value="<?php isset($to) ?  $to :  "ei11084@fe.up.pt" ?>"></td></tr>
     <tr><td align="right">* Last Name: </td>
         <td><input type="text" name="lname" size="30" value="<? echo @$lname ?>"></td></tr>
   </table>
<p>
   <table border="0" width="500">
     <tr><td align="right">* Primary Email: </td>
         <td><input type="text" name="femail" size="30" value="<?php echo @$femail ?>"></td></tr>
     <tr><td align="right">Secondary Email: </td>
         <td><input type="text" name="f2email" size="30" value="<?php echo @$f2email ?>"></td></tr>
   </table>
<p>
   <table border="0" width="600">
     <tr><td align="right">* Street Address: </td>
         <td><input type="text" name="saddy" size="40" value="<?php echo @$saddy ?>"></td></tr>
     <tr><td align="right">Apartment/Suite Number: </td>
         <td><input type="text" name="sapt" size="10" value="<?php echo @$sapt ?>"></td></tr>
     <tr><td align="right">* City: </td>
         <td><input type="text" name="scity" size="30" value="<?php echo @$scity ?>"></td></tr>
         <td align="right">State: </td>
         <td><input type="text" name="sstate" size="10" value="<?php echo @$sstate ?>"></td></tr>
     <tr><td align="right">* Zip/Post Code: </td>
         <td><input type="text" name="szip" size="10" value="<?php echo @$szip ?>"></td></tr>
     <tr><td align="right">Country: </td>
         <td><input type="text" name="scountry" size="30" value="<?php echo @$scountry ?>"></td></tr>
   </table>
<p>
   <table border="0" width="500">
     <tr><td align="right">* Phone Number 1: </td>
         <td><input type="text" name="fphone1" size="20" value="<?php echo @$fphone1 ?>"></td></tr>
     <tr><td align="right">Phone Number 2: </td>
         <td><input type="text" name="fphone2" size="20" value="<?php echo @$fphone2 ?>"></td></tr>
     <tr><td align="right">Phone Number 3: </td>
         <td><input type="text" name="fphone3" size="20" value="<?php echo @$fphone3 ?>"> <input style="display:none;" name="info" type="text" value=""> </td></tr>
   </table>
<p>
   <table border="0" width="500"><tr><td>
     Comments:<br />
     <TEXTAREA name="info" ROWS="10" COLS="60"></TEXTAREA>
     </td></tr>
     <tr><td align="right"><input type="submit" value="Send Now">
     </td></tr>
   </table>
   </form>
</body>
</html>

<?php
    }
    ?>