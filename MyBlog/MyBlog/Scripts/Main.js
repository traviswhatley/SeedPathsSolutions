//loading the DOM into jQuery
$(document).ready(function () {
    //here is where we put our code
    //we are selecting anything with the class of
    // 'likes', when it is clicked, 
    // run a function
    $('.likes').on('click', function () {
        //when we click, run this code
        //getting the id from data-id in
        // our likes div
        var id = $(this).data('id');
        //put our likes div into a variable
        var likesDiv = $(this);
        //make a request to add a like
        $.get('/Home/Like/' + id, function (data) {
            //replace the html of the like div
            // that was clicked (likesDiv), with the 
            // string returned from our GET
            likesDiv.html(data);
        });
    });

    //adding a comment, bind a submit event to the addComment forms
    $('.addComment form').on('submit', function (event) {
        //stop the form from submitting normally
        event.preventDefault();
        //put this (the form) into a variable
        var theForm = $(this);

        //do the AJAX POST, use the serialize
        // command to make a string of data
        $.post('/home/addComment', $(this).serialize(), function (data) {
            //add the new comment HTML 
            // before the addComment div
            theForm.parent().prepend(data);
            //clear the input fields
            theForm.find('#Name').val("");
            theForm.find('#Body').val("");
        }); // closes the $.post()
    }); // closes the on submit()
}); //closes document.ready()

