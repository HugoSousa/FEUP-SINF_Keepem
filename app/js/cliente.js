$(document).ready(function () {
    var codCliente = getParameterByName('codCliente');

    $("#cartaoClienteH3").hide();
    $("#criarCartaoCliente").hide();
    $("#pontosH3").hide();

    $.ajax({
        type: "GET",
        url: "http://localhost:49822/api/clientes/" + codCliente,
        dataType: "json",
        success: function (resp) {

            $("#nomeCliente").append(resp.NomeCliente);
            $("#numContribuinte").append(resp.NumContribuinte);

            if (resp.CDU_idCartaoCliente == null || resp.CDU_idCartaoCliente == "null") {
                $("#cartaoClienteH3").show();
                $("#criarCartaoCliente").show();
            } else {
                $("#cartaoClienteH3").show();
                $("#cartaoCliente").append(resp.CDU_idCartaoCliente);
                
                $.ajax({
                    type: "GET",
                    url: "http://localhost:49822/api/cartoesclientes/" + resp.CDU_idCartaoCliente,
                    dataType: "json",
                    success: function (resp) {

                        $("#pontosH3").show();
                        $("#pontos").append(resp.CDU_Pontos);

                    },
                    error: function (e) {
                        alert("Erro ao recolher dados do cliente!");
                    }
                });
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
    
    $("#logout").click(function () {
        window.location.href = "logout.php";
    });

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
});