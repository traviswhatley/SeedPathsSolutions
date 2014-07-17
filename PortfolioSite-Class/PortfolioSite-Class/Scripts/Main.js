//load the DOM into jQuery
$(document).ready(function () {
    //after the DOM is loaded, then execute this code
    
    //when we click on the homeLink, run some code
    $('.homeLink').on('click', function () {
        //get the url value from the
        // data-url attribute
        var url = $(this).data('url');
        //use a .get request to update our content
        $.get(url, function (data) {
            //update the content div with the 
            // data returned from our GET request.
            $('#content').html(data);
        });
    });

});