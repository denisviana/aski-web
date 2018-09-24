var current_fs, next_fs, previous_fs;
var left, opacity, scale;
var animating;
var form = $('#msform');

var countChips = 0;

$('#course_error').hide();

$(document).ready(function () {

$('select').formSelect();

$('#chips_want_be_helped').chips({
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
    },
    onChipAdd(e,chip){
        var elem = document.querySelector('.chips');
        var instance = M.Chips.getInstance(elem);
        console.log(chip);
        console.log(instance.chipsData);
    },
    onChipDelete(e,chip){
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

$("#next-fs1").click(function (){
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
            minlength: "A senha precisa ter no mínimo 6 caracteres."
            },
            confirm_pass: {
            required: "Por favor repita sua senha.",
            equalTo: "Senhas não conferem."
            },

        },

    });   

    if (form.valid()) {

        var validCheckbox = false;

        var checks = $('.require-one:checked');

        if(checks.length > 0)
            validCheckbox = true;
        else{
            $('#cb_error').append('<span class="helper-text" style="color: red; font-size: 15px;">Selecione pelo menos uma das opções.</span>')
        }
               

        if(validCheckbox){

            var wantBeHelped = $('#cb_1');
            var wantToHelp = $('#cb_2');

            if(wantBeHelped.is(':checked') && wantToHelp.is(':checked')){
                $(".want-be-helped").css("display","block");
                $(".want-to-help").css("display","block");
            }else if(wantBeHelped.is(':checked') && !wantToHelp.is(':checked')){
                $(".want-be-helped").css("display","block");
                $(".want-to-help").css("display","none");
            }else if(!wantBeHelped.is(':checked') && wantToHelp.is(':checked')){
                $(".want-be-helped").css("display","none");
                $(".want-to-help").css("display","block");
            }
        
            if (animating) return false;
                    animating = true;

            current_fs = $(this).parent();
            next_fs = $(this).parent().next();
            next_fs.show();
            current_fs.animate({ opacity : 0}, {
                step: function(now, mx){
                scale = 1 - (1 - now) * 0.2;
                left = (now * 50) + "%";
                opacity = 1 - now;
                current_fs.css({ 'transform': 'scale(' + scale + ')' });
                next_fs.css({ 'left': left, 'opacity': opacity });
                },
                duration: 800,
                complete: function(){
                current_fs.hide();
                animating = false;
                },
                easing: 'easeInOutBack'
            });
        }       

    }
});

$("#next-fs2").click(function(){

    var valid = false;

    if($('#select_course').val() == null){
        $('#select_course_container').append('<span class="helper-text" id="course_error" style="">Escolha seu curso.</span>')
    }else{
        valid = true;
    }

    var elem = document.querySelector('.chips');
    var chips = M.Chips.getInstance(elem);
    if(chips.chipsData.length > 0){
        $('#course_error').hide();
        valid = true;
    }else{
        valid = false;
        $('#course_error').show();
        $('#course_error').addClass('helper-text');
        $('#course_error').css({"color": "red","font-size": "12px"})
        $('#course_error').text("Informe pelo menos uma matéria.");
    }

    if (valid) {   

        if (animating) return false;
                animating = true;

        current_fs = $(this).parent();
        next_fs = $(this).parent().next();
        next_fs.show();
        current_fs.animate({ opacity : 0}, {
            step: function(now, mx){
            scale = 1 - (1 - now) * 0.2;
            left = (now * 50) + "%";
            opacity = 1 - now;
            current_fs.css({ 'transform': 'scale(' + scale + ')' });
            next_fs.css({ 'left': left, 'opacity': opacity });
            },
            duration: 800,
            complete: function(){
            current_fs.hide();
            animating = false;
            },
            easing: 'easeInOutBack'
        });


    }
});

});

