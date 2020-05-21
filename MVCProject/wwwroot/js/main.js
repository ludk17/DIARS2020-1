

//var $ = jQuery;
//var h1 = $("h1#titulo");
//h1.css('color', 'red');

var html = $('#contenido').html();
console.log(html);

$('#contenido').html("<h1>Cambio de contenido</h1>")


for (var i = 0; i < 10; i++) {

}

if (true) {

} else {

}


$('button').on('click', function () {    

    $("h1").addClass("red");

    alert($("h1").hasClass("green"));

    $("h1").removeClass("red");   

});


