$(function() {

    $('#login-form-link').click(function (e) {
		$("#login-form").delay(100).fadeIn(100);
 		$("#register-form").fadeOut(100);
		$('#register-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
    });

    $('#register-form-link').click(function (e) {
		$("#register-form").delay(100).fadeIn(100);
 		$("#login-form").fadeOut(100);
		$('#login-form-link').removeClass('active');
		$(this).addClass('active');
		e.preventDefault();
    });

$('#register_submit').click(function () {
        debugger;
        var emailvalue = $('#registername').val();
        var senhavalue = $('#registerpassword').val();
        var confirmsenha = $('#confirm_password').val();
        
        if (emailvalue.length == 0 || senhavalue.length == 0 || confirmsenha.length == 0)
        {
            $(function () {
                swal({
                    title: "Atenção",
                    type: "warning",
                    html: "Verifique se digitou corretamente o e-mail e a senha."
                })
            })
        }
    });

});

