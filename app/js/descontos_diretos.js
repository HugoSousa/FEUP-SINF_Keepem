var familias_desconto = [];
var produtos_familia = [];
$(document).ready(function () {
	$(document).on('click', '#dropdown_list li a', function() {
		var familia_selecionada = $(this).find('span').html();
		var descricao_familia_selecionada = $(this).clone().children().remove().end().text(); //get text of <a> only, without children nodes
		console.log(familia_selecionada);
		console.log(descricao_familia_selecionada);
		$('#dropdown_title').html(descricao_familia_selecionada);
		
		$('#desconto_direto_familia').text(familias_desconto[familia_selecionada]);
			$('.show-category').removeClass('hide');
		
		$.ajax({
			type: "GET",
			url: "http://localhost:49822/api/artigos/" + familia_selecionada,
			dataType: "json",
			success: function (resp) {
				console.log(resp);
				console.log("EMPTY PRODUTOS");
				$('#produtos').empty();
				
				var desconto_atual = familias_desconto[familia_selecionada];
				for(var i = 0; i < resp.length; i++){
					produtos_familia.push(resp[i]);
					
					var imagem = resp[i].Imagem;
					if(! imagem){
						imagem = "no_image";
					}
					
					$('#produtos').append(
						'<div class="col-sm-6 col-md-2">' +
							'<div class="thumbnail">' +
								'<img src="images/{' + imagem + '}.jpg" >' +
								'<div class="caption">' +
									'<h4>' + resp[i].DescArtigo + '</h4>' +
									'<span><del>' + (resp[i].Preco).toFixed(2) + '</del></span>' +
									'<span class="pull-right"><b>'+ ((1.0 - desconto_atual/100.0) * resp[i].Preco).toFixed(2) + '</b></span>' +
									'<p>Poupa: <span class="pull-right">' + ((desconto_atual/100.0) * resp[i].Preco).toFixed(2) + '</span>' +
									'</p>' +
								'</div>' +
							'</div>' +
						'</div>'
					);
					
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
				$('#dropdown_list').append('<li role="presentation"><a role="menuitem" tabindex="-1" href="#">' + resp[i].DescriFamilia + ' - ' + resp[i].DescFamilia + '% <span style="display:none">' + resp[i].NomeFamilia + '</span></a></li>');
				familias_desconto[resp[i].NomeFamilia] = resp[i].DescFamilia;
			}
			
        },
        error: function (e) {
            alert("Erro ao recolher dados dos descontos diretos!");
        }
    });
});