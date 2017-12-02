function Msg_Warning(StrWaring) {
    swal({
        title: 'Atenção',
        type: 'warning',
        text: StrWaring
    });
}

function Msg_Warning(StrError) {
    swal({
        title: 'Erro',
        type: 'error',
        text: StrError
    });
}

function Msg_Warning(StrSuccess) {
    swal({
        title: 'Sucesso',
        type: 'success',
        text: StrSuccess
    });
}

$(document).ready(function () {

    function limpa_formulário_cep() {
        // Limpa valores do formulário de cep.
        $("#rua").val("");
        //$("#bairro").val("");
        $("#cidade").val("");
        $("#uf").val("");
        //$("#ibge").val("");
    }

    //Quando o campo cep perde o foco.
    $("#cep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep !== "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#rua").val("...");
                //$("#bairro").val("...");
                $("#cidade").val("...");
                $("#uf").val("...");
                //$("#ibge").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("//viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#rua").val(dados.logradouro);
                        //$("#bairro").val(dados.bairro);
                        $("#cidade").val(dados.localidade);
                        $("#uf").val(dados.uf);
                        //$("#ibge").val(dados.ibge);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });
});

$(function () {

    // ## EXEMPLO 1
    // Aciona a validação a cada tecla pressionada
    var temporizador = false;
    $("#cpf_cnpj").keypress(function () {

        // O input que estamos utilizando
        var input = $(this);

        // Limpa o timeout antigo
        if (temporizador) {
            clearTimeout(temporizador);
        }

        // Cria um timeout novo de 500ms
        temporizador = setTimeout(function () {
            // Remove as classes de válido e inválido
            input.removeClass('valido');
            input.removeClass('invalido');

            // O CPF ou CNPJ
            var cpf_cnpj = input.val();

            // Valida
            var valida = valida_cpf_cnpj(cpf_cnpj);

            // Testa a validação
            if (valida) {
                input.addClass('valido');
            } else {
                input.addClass('invalido');
            }
        }, 500);

    });
});

 $("#cpf_cnpj").inputmask({
     mask: ['999.999.999-99', '99.999.999/9999-99'],
     keepStatic: true
 });

 $("#txFone1").inputmask({
     mask: ['(99) 9999-9999'],
     keepStatic: true
 });

 $("#txFone2").inputmask({
     mask: ['(99) 99999-9999'],
     keepStatic: true
 });

//$(document).ready(function () {
//    $('ul.nav li.dropdown').hover(function () {
//        $(this).find('.mega-dropdown-menu').stop(true, true).delay(200).fadeIn(200);
//    }, function () {
//        $(this).find('.mega-dropdown-menu').stop(true, true).delay(200).fadeOut(200);        
//    });
//});



