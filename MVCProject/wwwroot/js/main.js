
//$('button').val()

$('button').on('click', function () {

    //$.ajax({
    //    url: 'http://localhost:64757/home/create',
    //    type: 'get'
    //}).done(function (response) {
    //    $("div#contenido").html(response);
    //});   

    
});


$('a').on('click', function (event) {
    event.preventDefault();
    alert("Hola Mundo");
});

$('form').on('submit', function (e) {
    alert("Hola Formulario");
    e.preventDefault();
});