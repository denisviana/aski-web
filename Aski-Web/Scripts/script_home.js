
$(document).ready(function(){


    $('select').formSelect();
    $('.tabs').tabs();


    $('#disciplines').change(function () {

        var id = $(this).val();
        console.log(id);

        $('#answerId').empty();

        $.ajax({

            type: "POST",
            url: '/Home/GetSpecialistUsers',
            data: { data : id },
            dataType: 'json',
            success: function (response) {


                var users = $.parseJSON(JSON.stringify(response));

                

                $.each(users, function (index, value) {

                    var card_container = $('<div class="card horizontal card-answer waves-effect" style="padding-left: 10px;padding-right:10px"></div>');
                    var card_image = $('<div class="card-image valign-wrapper"></div>');
                    var image = $('<img style="width: 40px; display: inline-block" class="circle responsive-img" src="http://pronksiapartments.ee/wp-content/uploads/2015/10/placeholder-face-big.png">');
                    var card_content = $('<div class="card-content"></div>');

                    var name = $('<span style="font-weight: 700; display: block">' + value.Name + '</div>');
                    var tempo = $('<span style="font-size: 12px; display: block;">Tempo de resposta: 10min</span>');
                    var star = $('<span class="fa fa-star checked"></span>');

                    card_content.append(name, tempo, star, star, star, star);
                    card_image.append(image);
                    card_container.append(card_image, card_content);

                    $('#answerId').append(card_container);

                });

            },
            failure: function () {
            },
            error: function () {
            }
        });

    });

});