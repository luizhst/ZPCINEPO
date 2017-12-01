$(function () {
    $('#login-form-link').click(function (e) {
        $("#register-form").hide("low");
        $("#empresa-form").hide("low");
        $("#MenuCadastro").hide("low");
        $("#login-form").show("fast");
        $('#register-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });

    $('#register-form-link').click(function (e) {
        $("#login-form").hide("low");
        $("#empresa-form").hide("low");
        $("#register-form").show("fast");
        $("#MenuCadastro").show("fast");
        $('#login-form-link').removeClass('active');
        $(this).addClass('active');
        e.preventDefault();
    });



    $('#register_submit').click(function () {
        debugger;
        var emailvalue = $('#registername').val();
        var senhavalue = $('#registerpassword').val();
        var confirmsenha = $('#confirm_password').val();

        if (emailvalue.length == 0 || senhavalue.length == 0 || confirmsenha.length == 0) {
            $(function () {
                swal({
                    title: "Atenção",
                    type: "warning",
                    html: "Verifique se digitou corretamente o e-mail e a senha."
                })
            })
        }
    });

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
            if (cep != "") {

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

 $(function () {
        // You can specify some validation options here but not rules and messages
     $('#form1').validate();
     jQuery.extend($.validator.messages, {
         email: "Digite um endereço de email válido."
     })
        // Add a custom class to your name mangled input and add rules like this
        $('#registername').rules('add', {
            required: true,
            email: true,
            messages: {                
                required: 'Digite um endereço de email válido.',
            }
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
});

$(document).ready(function () {
    $('ul.nav li.dropdown').hover(function () {
        $(this).find('.mega-dropdown-menu').stop(true, true).delay(200).fadeIn(200);
    }, function () {
        $(this).find('.mega-dropdown-menu').stop(true, true).delay(200).fadeOut(200);        
    });
});

function ProximaEtapa() {
    debugger;
    $("#register-form").hide("low");
    $("#login-form").hide("low");
    $('#login-form-link').hide("low");
    $("#empresa-form").show("fast");
    $('#register-form-link').addClass('active');
    $('#colSize').removeClass('col-xs-6');
    $('#colSize').addClass('col-xs-12');
    
};

