const apiUrl = "http://localhost:1916/";

$(document).ready(() => {
    $('#status').hide();
    $("#botao-entrar").click(() => {
        $.ajax({
            url: apiUrl + "Autenticacao/AutenticarUsuario",
            dataType: 'json',
            type: "POST",
            async: true,
            beforeSend: () => {
                $('#status').html('Autenticando usuário');
                $('#status').show();
            },
            data: {
                login: $("input[name$=txtLogin]").val(),
                senha: $("input[name$=txtSenha]").val(),
            },
            success: (retorno) => {
                console.log(retorno)
                if (retorno.OK) {
                    $('#status').html(retorno.Mensagem);
                    setTimeout(redirecionarParaHome, 2000);
                    $('#status').show();
                } else {
                    $('#status').html(retorno.Mensagem);
                    $('#status').show();
                }
            },
            error: (retorno) => {
                $('#status').html(retorno.Mensagem);
                $('#status').show();
            },
        });
    });
});

function redirecionarParaHome() {
    window.location.href = "/Home";
}