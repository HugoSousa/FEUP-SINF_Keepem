$(document).ready(function () {

    $("#formNovoCliente").submit(function (event) {
        event.preventDefault();
        
        if($("#inputNumContribuinte").val().length != 9)
        {
            alert("O número de contribuinte deve conter 9 dígitos!");
        }
        else
        {
            if($("#inputPassword").val().length < 5)
            {
                alert("A password deve conter no mínimo 5 caracteres!");
            }
            else
            {
                var data = {}
                var Form = this;

                $.each(this.elements, function (i, v) {
                    var input = $(v);
                    data[input.attr("name")] = input.val();
                    delete data["undefined"];
                });

                $.ajax({
                    type: "POST",
                    url: "http://localhost:49822/api/clientes",
                    data: JSON.stringify(data),
                    contentType: "application/json",
                    dataType: "json",
                    success: function (resp) {
                        alert("Cliente criado com sucesso!");

                        window.location.href = "index.php";
                    },
                    error: function (e) {
						console.log(JSON.stringify(e));
                        alert("Erro ao criar cliente!");
                    }
                });
            }
        }
    });
});