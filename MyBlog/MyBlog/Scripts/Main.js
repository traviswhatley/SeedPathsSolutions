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
});
