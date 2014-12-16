$(document).ready(function () {
    var codCliente = getParameterByName('codCliente');

    $("#cartaoClienteH4").hide();
    $("#criarCartaoCliente").hide();
    $("#pontosH4").hide();

	
	$("#subscribe_group > .btn").click(function(e){
		if( ! $(this).hasClass('active')){	
		
			var clicked_button = $(this);
		
			console.log("clicked");
			var subscribe_data;
			if(e.target.id == 'subscribe_button')
				subscribe_data = true;
			else
				subscribe_data = false;
				
			$.ajax({
				type: "PUT",
				url: "http://localhost:49822/api/clientes/1",
				dataType: "json",
				contentType: "application/json",
				data: JSON.stringify({
					"CodCliente": codCliente,
					"CDU_Subscribed": subscribe_data
				}),
				success: function (resp) {
					
					clicked_button.addClass("active").siblings().removeClass("active");
				},
				error: function (e) {
					console.log("A");
					$(this).removeClass("active");
					alert("Erro. Não foi possível enviar a sua alteração para o servidor.");
				}	
			});
		}
	});
		
		
		
		

    $.ajax({
        type: "GET",
        url: "http://localhost:49822/api/clientes/" + codCliente,
        dataType: "json",
        success: function (resp) {

            $("#nomeCliente").append(resp.NomeCliente);
            $("#numContribuinte").append(resp.NumContribuinte);
            
			$("#cartaoClienteH4").show();
			$("#cartaoCliente").append(resp.CDU_idCartaoCliente);
			$("#pontosH4").show();
			$("#pontos").append(resp.Pontos);
			if(resp.Pontos > 0){
				$('#numero_pontos_expiracao').text(resp.PontosProximaExpiracao);
				var data = resp.DataProximaExpiracao.split(" ")[0];
				$('#data_pontos_expiracao').text(data);
				$('#expiracao_pontos').show();
			}
			
			if(resp.CDU_Subscribed)
				$('#subscribe_button').addClass('active');
			else
				$('#unsubscribe_button').addClass('active');
				

        },
        error: function (e) {
            alert("Erro ao recolher dados do cliente!");
        }
    });


    
});

function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }