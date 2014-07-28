//load the DOM into a jQuery object
//.ready waits for the document to be completely loaded
// and after it is, then run a function
$(document).ready(function () {

    //product view thumbnail swapper 1.0
    //bind an click event to the thumbnail images
    $('.product-thumbnails img').on('click', function () {
        //placed the value of the image src that we clicked on into
        // a variable named thumbImg
        var thumbImg = $(this).attr('src');
        //replace the src attribute on the main image with our thumbnail
        // image src value
        $('.product-image-main img').attr('src', thumbImg);
        
        //remove any 'active' from our thumbnails
        $('.product-thumbnails img').removeClass('active');

        //add the 'active' class to the thumbnail
        // we just clicked on
        $(this).addClass('active');
    });

    //AJAX post for the Add to cart
    //bind an submit event to our form
    $('.product-add form').on('submit', function (event) {
        //prevent the form from submitting
        event.preventDefault();
        //do the ajax post, make sure to 
        // serialize (convert to a string) the
        // form data.
        $.post('/Cart/Add/', $(this).serialize(), function (data) {
            //select the cart, and replace its HTML
            // with the data variable
            $('.miniCart').html(data)
        });
        

    });

});