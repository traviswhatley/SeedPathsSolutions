//load the DOM into jQuery
$(document).ready(function () {
    //functions go inside the 
    // document.ready() callback function
    $('li').on('click', function () {
        //when we click, change the
        // color property only for the
        // li that we clicked on
        $(this).css('color', 'red').css('background-color', 'gray');
        $(this).fadeOut(2000);
    });
});
