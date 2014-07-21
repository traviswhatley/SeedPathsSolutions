//Load the dom into a jQuery object
// after its fully loaded (.ready())
$(document).ready(function () {
    //selecting my tab links
    $('.about li').on('click', function () {
        //when we click on our li, run this function
        //get the url from data-url for this li
        var url = $(this).data('url');
        //AJAX GET request to the url for this tab
        $.get(url, function (data) {
            //selecting our tab content area
            $('#tabContent').html(data);
        });
        //remove the current active tab
        $('.about li').removeClass('active');
        //add the active class to our current tab
        $(this).addClass('active');
        
    });
    
});
