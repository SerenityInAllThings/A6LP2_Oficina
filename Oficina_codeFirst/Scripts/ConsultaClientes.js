function redirecionar(url) {
    console.log(url);
    location.href = url + '?codigoAtendimento=' + $("input[name$=codigoAtendimento]").val()
}