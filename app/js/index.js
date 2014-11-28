$(document).ready(function () {
    $("#clienteExistente").click(function () {
        window.location.href = "entrar.php";
    })

    $("#novoCliente").click(function () {
        window.location.href = "novoCliente.php";
    })
    

    function getParameterByName(name) {
        name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
        var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
            results = regex.exec(location.search);
        return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
    }
});