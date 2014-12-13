<?php include("navbar.php"); ?>

<script src="js/descontos_pontos.js"></script>

<div class="container">
    <div class="jumbotron center-middle" style="display:none; margin-bottom: 50px" id="pontos_info">
        <p class="text-center">Tem <span id="pontos_cliente">X</span> pontos</p>
        <div class="text-center" id="pontos_expiracao_info" style="display:none"><small>dos quais <span id="pontos_expiracao_cliente">Y</span> expiram em <span id="data_expiracao_cliente">Z</</small>
        </div>
    </div>

    <div class="table-responsive center-middle">
        <table class="table text-center" id="descontos_table">
            <thead>
                <tr>
                    <th class="nosort">Pontos</th>
                    <th class="nosort">Desconto</th>
                </tr>
            </thead>
            <tbody>


            </tbody>
        </table>
    </div>
</div>

</body>

</html>