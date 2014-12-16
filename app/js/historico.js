var codCliente = getParameterByName("codCliente");

$(document).ready(function () {
	
	$('#historico_table').delegate('tbody > tr', 'click', function ()
	{
		// 'this' refers to the current <td>, if you need information out of it
		codFatura = $(this).find("td:first").text();
		window.location = "/fatura.php?codCliente=" + codCliente + "&codFatura=" + codFatura;
		console.log("click");
		
	});
	
	$('#historico_table').dataTable({
		"searching": false,
		"columns": [
			{
				"data": "NumDoc"
			},
			{
				"data": "Data",
				"width": "20%"
			},
			{
				"data": "PontosUsados"
			},
			{
				"data": "PrecoInicial"
			},
			{
				"data": "PrecoFinal"
			},
			{
				"data": "Poupanca"
			}
	    ]
	});
			
	$.ajax({
		type: "GET",
		url: "http://localhost:49822/api/docvendacliente/" + codCliente,
		dataType: "json",
		success: function (resp) {
			
			var table = $('#historico_table').DataTable();
			
			console.log(resp);
			
			for(var i=0; i < resp.length; i++){
				num = resp[i].NumDoc;
				data = resp[i].Data;
				var datasplit = data.split("T");
				
				resp[i].Data = datasplit[0]
				//resp[i].Poupanca = Math.abs((resp[i].PrecoFinal - resp[i].PrecoInicial).toFixed(2));
				
				resp[i].Poupanca = resp[i].DescontoFidelizacao;
				for(var j=0; j < resp[i].LinhasDoc.length; j++){
					resp[i].Poupanca += resp[i].LinhasDoc[j].DescontoFidelizacao;
				}
				
				resp[i].PrecoInicial = (resp[i].PrecoFinal + resp[i].Poupanca).toFixed(2);
				resp[i].PrecoFinal = resp[i].PrecoFinal.toFixed(2);
				resp[i].Poupanca = resp[i].Poupanca.toFixed(2);
				
				//console.log(num);
				//console.log(data);
				
				table.row.add(resp[i]).draw();
					
			}
			
			
		},
		error: function (e) {
			alert("Erro ao recolher documento de venda do cliente");
		}
	});
});

function getParameterByName(name) {
	name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
	var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
		results = regex.exec(location.search);
	return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}