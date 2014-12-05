var codCliente = "3";
var pontosCliente;

$(document).ready(function () {
	
	$.ajax({
        type: "GET",
        url: "http://localhost:49822/api/clientes/" + codCliente,
        dataType: "json",
        success: function (resp) {
			
			pontosCliente = resp.Pontos;
			$('#pontos_cliente').text(resp.Pontos);
			$('#pontos_expiracao_cliente').text(resp.PontosProximaExpiracao);
			$('#data_expiracao_cliente').text(resp.DataProximaExpiracao);
			
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