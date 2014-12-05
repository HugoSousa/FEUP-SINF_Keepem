var familias_desconto = {};
var produtos_familia = {};

$(document).ready(function () {
	$(document).on('click', '#dropdown_list li a', function() {
		var familia_selecionada = $(this).html();
		$('#dropdown_title').html(familia_selecionada);
		
		$('#desconto_direto_familia').text(familias_desconto[familia_selecionada]);
		$('.show-category').removeClass('hide');
		
		$.ajax({
			type: "GET",
			url: "http://localhost:49822/api/artigos/" + familia_selecionada,
			dataType: "json",
			success: function (resp) {
				console.log("EMPTY PRODUTOS");
				$('#produtos').empty();
				
				for(var i = 0; i < resp.length; i++){
				
					//guardar os artigos no array produtos_familia
					//implementar paginacao / search
				}				
			},
			error: function (e) {
				alert("Erro ao recolher dados dos artigos da familia!");
			}
		});
	});
	
	$.ajax({
        type: "GET",
        url: "http://localhost:49822/api/descontosdiretos",
        dataType: "json",
        success: function (resp) {
			
			for(var i = 0; i < resp.length; i++){
				$('#dropdown_list').append('<li role="presentation"><a role="menuitem" tabindex="-1" href="#">' + resp[i].NomeFamilia + '</a></li>');
				familias_desconto[resp[i].NomeFamilia] = resp[i].DescFamilia;
			}
			
        },
        error: function (e) {
            alert("Erro ao recolher dados dos descontos diretos!");
        }
    });
});