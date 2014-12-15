var codCliente = getParameterByName("codCliente");
var pontosCliente;

$(document).ready(function () {
		
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
	
	console.log(codCliente);
	
	$.ajax({
        type: "GET",
        url: "http://localhost:49822/api/clientes/" + codCliente,
        dataType: "json",
        success: function (resp) {
			
			var expira = false;
			pontosCliente = resp.Pontos;
			
			$('#pontos_cliente').text(resp.Pontos);
			if(resp.PontosProximaExpiracao > 0){
				console.log("here");
				expira = true;
				$('#pontos_expiracao_cliente').text(resp.PontosProximaExpiracao);
				$('#data_expiracao_cliente').text(resp.DataProximaExpiracao);
			}
			$('#pontos_info').show();
			
			if(expira)
				$('#pontos_expiracao_info').show();
			
			
			getDescontosPontos();
        },
        error: function (e) {
            alert("Erro ao recolher dados do cliente!");
        }
    });
	
	
	
});

var getDescontosPontos = function() {
    
	var table = $('#descontos_table').DataTable();
	
	$.ajax({
        type: "GET",
        url: "http://localhost:49822/api/descontospontos",
        dataType: "json",
        success: function (resp) {
			console.log(resp);
			var pontos;
			var desconto;
			var colorRow;
            //$('#descontos_table tr:last').after('<tr>...</tr><tr>...</tr>');
			for(var i=0; i < resp.length; i++){
				pontos = resp[i].pontos;
				desconto = resp[i].desconto;
				
				var node = table.row.add(resp[i]).draw().node();
				if(pontosCliente >= pontos)
					$(node).addClass("success");
				else
					$(node).addClass("warning");
					
				//$('#descontos_table tr:last').after('<tr' + colorRow + '><td>' + pontos + '</td><td>' + desconto + '</td></tr>');
			}
        },
        error: function (e) {
            alert("Erro ao recolher dados do descontos por pontos!");
        }
    });
	
};

function getParameterByName(name) {
	name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
	var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
		results = regex.exec(location.search);
	return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}
