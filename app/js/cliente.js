$(document).ready(function () {
    var codCliente = getParameterByName('codCliente');

    $("#cartaoClienteH4").hide();
    $("#criarCartaoCliente").hide();
    $("#pontosH4").hide();

    $.ajax({
        type: "GET",
        url: "http://localhost:49822/api/clientes/" + codCliente,
        dataType: "json",
        success: function (resp) {

            $("#nomeCliente").append(resp.NomeCliente);
            $("#numContribuinte").append(resp.NumContribuinte);

            if (resp.CDU_idCartaoCliente == null || resp.CDU_idCartaoCliente == "null") {
                $("#cartaoClienteH4").show();
                $("#criarCartaoCliente").show();
            } else {
                $("#cartaoClienteH4").show();
                $("#cartaoCliente").append(resp.CDU_idCartaoCliente);
                $("#pontosH4").show();
                $("#pontos").append(resp.Pontos);
            }

        },
        error: function (e) {
            alert("Erro ao recolher dados do cliente!");
        }
    });

    $("#criarCartaoCliente").click(function () {
        $.ajax({
            type: "PUT",
            url: "http://localhost:49822/api/clientes/1",
            data: JSON.stringify({
                "CodCliente": codCliente
            }),
            contentType: "application/json",
            dataType: "json",
            success: function (resp) {
                alert("Cartão de cliente criado com sucesso!");
                
                window.location.href = "cliente.php?codCliente=" + codCliente;
            },
            error: function (e) {
                alert("Erro ao criar cartão de cliente!");
            }
        });
    });

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
});