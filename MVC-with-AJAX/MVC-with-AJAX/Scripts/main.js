//JavaScript goes here

$(document).ready(function () {
    //after the document is loaded, run this code
    // we use the secondary selector to bind a click event to any elements with the ajax-link class that are on the page currently, or that will appear at a later time.
    $('body').on('click', '.ajax-link', function () {
        // get the data-url value from the <li> item we clicked on
        var url = $(this).data('url');
        //do the ajax GET request
        $.get(url, function (data) {
            //made the request, now do something with the response (data).

            //updated the content div with the string html stored in the data parameter
            $('.content').html(data);
        });
    });

    //AJAX FORM POSTS
    $('.ajax-form').on('submit', function () {

    });

    $('body').on('submit', '.ajax-form', function (event) {
        //event is the action of submitting the form

        //preventing the default behavior, in this case not allowing the form to submit normally.
        event.preventDefault();

        //make the AJAX POST request
        // first param: url to post to
        // second param: sends the input field data
        // third param: what to do with the response.

        alert($(this).serialize());
        $.post($(this).data('posturl'), $(this).serialize(), function (data) {
            //update our content area
            $('.content').html(data);
        });
    });
});