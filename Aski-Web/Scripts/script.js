var current_fs, next_fs, previous_fs;
var left, opacity, scale;
var animating;
var form = $('#msform');

$.validator.addMethod('require-one', function (value) {
    return $('.cb_container.require-one:checked').size() > 0;
}, 'Selecione pelo menos uma das opções.');

$(document).ready(function () {

    var checkboxes = $('.require-one');
    var checkbox_names = $.map(checkboxes, function (e, i) {
        return $(e).attr("name")
    }).join(" ");

    $('select').formSelect();

    $('#chips-want-be-helped').chips({
        placeholder: 'Quero ajuda com',
        autocompleteOptions: {
            data: {
                'Banco de Dados': null,
                'Algoritmos': null,
                'Programação Orientada a Objetos': null,
                'Design de Interação': null,
                'Análise e Projeto de Sistemas': null,
                'Sistemas Operacionais': null,
                'Desenvolvimento de Software': null,
                'Estrutura de Dados': null
            
            },
            limit: Infinity,
            minLength: 1
        }
    });

    $('#chips-want-to-help').chips({
        placeholder: 'Sou bom em',
        autocompleteOptions: {
            data: {
                'Banco de Dados': null,
                'Algoritmos': null,
                'Programação Orientada a Objetos': null,
                'Design de Interação': null,
                'Análise e Projeto de Sistemas': null,
                'Sistemas Operacionais': null,
                'Desenvolvimento de Software': null,
                'Estrutura de Dados': null

            },
            limit: Infinity,
            minLength: 1
        }
    });

    $("#next-fs1").click(function () {

        form.validate({
            errorElement: 'span',
            errorClass: 'helper-text',            
            highlight: function (element, errorClass, validClass) {
                $(element).addClass('invalid');
            },
            unhighlight: function (element, errorClass, validClass) {
                $(element).addClass('valid');
            },
            rules: {
                groups: {
                    checks: checkbox_names
                },
                name: {
                    required: true,
                },
                email: {
                    required: true,
                    email: true
                },
                pass: {
                    required: true,
                    minlength: 6
                },
                confirm_pass: {
                    required: true,
                    equalTo: "#pass"
                },              
                
            },
            messages: {
                name: {
                    required: "Por favor informe seu nome."
                },
                email: {
                    required: "Por favor informe o seu e-mail.",
                    email: "E-mail inválido"
                },
                pass: {
                    required: "Por favor informe a senha.",
                    minLength: "A senha precisa ter no mínimo 6 caracteres."
                },
                confirm_pass: {
                    required: "Por favor repita sua senha.",
                    minLength: "A senha precisa ter no mínimo 6 caracteres.",
                    equalTo: "Senhas não conferem."
                },                
            },
            errorPlacement: function (error, element) {
                $('#cb_error').append(error);
            },
            
        });

        if (form.valid() == true) {

            if (animating) return false;

            animating = true;

            current_fs = $(this).parent();
            next_fs = $(this).parent().next();

            next_fs.show();
            current_fs.animate({ opacity: 0 }, {
                step: function (now, mx) {
                    scale = 1 - (1 - now) * 0.2;
                    left = (now * 50) + "%";
                    opacity = 1 - now;
                    current_fs.css({ 'transform': 'scale(' + scale + ')' });
                    next_fs.css({ 'left': left, 'opacity': opacity });
                },
                duration: 800,
                complete: function () {
                    current_fs.hide();
                    animating = false;
                },
                easing: 'easeInOutBack'
            });
        }           
                

    });

    

});
 

$(".previous").click(function () {
        if (animating) return false;
        animating = true;

        current_fs = $(this).parent();
        previous_fs = $(this).parent().prev();


        //show the previous fieldset
        previous_fs.show();
        //hide the current fieldset with style
        current_fs.animate({ opacity: 0 }, {
            step: function (now, mx) {
                //as the opacity of current_fs reduces to 0 - stored in "now"
                //1. scale previous_fs from 80% to 100%
                scale = 0.8 + (1 - now) * 0.2;
                //2. take current_fs to the right(50%) - from 0%
                left = ((1 - now) * 50) + "%";
                //3. increase opacity of previous_fs to 1 as it moves in
                opacity = 1 - now;
                current_fs.css({ 'left': left });
                previous_fs.css({ 'transform': 'scale(' + scale + ')', 'opacity': opacity });
            },
            duration: 800,
            complete: function () {
                current_fs.hide();
                animating = false;
            },
            //this comes from the custom easing plugin
            easing: 'easeInOutBack'
        });
    });

$(".submit").click(function () {
        return false;
    })