$(document).ready(function () {
    //show/hide the comments
    $('.showComments').on('click', function () {
        var parent = $(this).parent();
        var commentsToShowOrHide = parent.find('.commentsDiv');
        commentsToShowOrHide.slideToggle();
    });
    
    //handle the Like button
    $('.like').on('click', function () {
        //what post does the user want to like?
        var postID = $(this).data('postid');
        //store the this element into a variable
        var theLikeButton = $(this);
        //do the AJAX get request to like the post
        $.get('/Home/LikePost/' + postID, function (data) {
            //update the HTML with the current number of likes
            theLikeButton.parent().html(data);
        });
    });
    
    //wiring up the AJAX POST for the comment form
    $('.commentsDiv form').on('submit', function (event) {
        //prevent the form from posting normally
        event.preventDefault();
        var theForm = $(this);
        $.post(theForm.attr('action'), theForm.serialize(), function (data) {
            //update our html
            theForm.before(data);
            //clear out the values of the comment form
            theForm.find('.commentAuthor, .commentBody').val('');
        });
        
    });
    
});
