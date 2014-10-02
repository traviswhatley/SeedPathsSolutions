//load the DOM into jQuery
$(document).ready(function () {
    //functions go inside the 
    // document.ready() callback function
    $('li').on('click', function () {
        //when we click, change the
        // color property only for the
        // li that we clicked on
        //$(this).css('color', 'red').css('background-color', 'gray');
        //$(this).fadeOut(2000);
    });

    //Tab functions START
    $('.tabSelection li').on('click', function () {
        //bind an click event to each li under the
        // tabSelection class element
        var tabID = $(this).data('tab-id');
        //select the active tab
        var activeTab = $('.active');
        //select tab to activate
        var selectedTab = $('#' + tabID);
        //remove the active class from the active tab
        //  and add the hide class to the active tab
        activeTab.removeClass('active');
        activeTab.addClass('hide');
        //remove the hide class from the selectedTab
        // and add the active class to the selectedTab
        selectedTab.removeClass('hide').addClass('active');
    });
    //Tab functions END

    //Carousel Function START
    $('.carousel-next').on('click', function () {
        //get the active slide
        var activeSlide = $('.carousel.active');
        //get the next slide
        var x = activeSlide.siblings('.active')
        var nextSlide = activeSlide.next();
        //make sure its a carousel slide
        if (!nextSlide.hasClass('carousel')) {
            nextSlide = $('.carousel').first();
        }
        
        //remove the active class, add hide class to
        // the active slide
        activeSlide.removeClass('active').addClass('hide');
        //remove the hide class, add the active class
        // to the next slide
        nextSlide.removeClass('hide').addClass('active');
    });
    //Carousel Function END

    //interval swapping
    var carouselNext = function () {


    }

    
    $('span.next').on('click', function () {
        //get carousel type
        var carousel = $(this).data('carousel');
        //get the active slide
        var activeSlide = $('.' + carousel + '.active');
        //get the next slide
        var nextSlide = activeSlide.next();
        //make sure its a carousel slide
        if (!nextSlide.hasClass(carousel)) {
            nextSlide = $('img.' + carousel).first();
        }

        //remove the active class, add hide class to
        // the active slide
        activeSlide.removeClass('active').addClass('hide');
        //remove the hide class, add the active class
        // to the next slide
        nextSlide.removeClass('hide').addClass('active');
    });

    //SIMPLE AJAX GET
    //$('#content .ajax-get').on('click', function () {
    //    //ajax get, we specify jQuery($).get()
    //    $.get('/ajaxget/cats', function (data) {
    //        //replace the #content HTML with the
    //        // HTML returned from our AJAX GET  
    //        // request.
    //        $('#content').html(data);
    //    });
    //});

    //MUCH BETTER AJAX GET CODE
    //use the second selector to apply this function to
    // any matching elements that appear on the page
    // AT ANY TIME.
    $('#content').on('click', '.ajax-get', function () {
        //get the url to GET from the data-url attribute
        var urlRequest = $(this).data('url');
        //make the AJAX request
        $.get(urlRequest, function (data) {
            $('#content').html(data);
        });
    });

    //AJAX POST FOR CONTACT FORM
    $('#contactForm').on('submit', function (event) {
        //prevents the default behavior of the form
        // (doesn't allow it to be submitted)
        event.preventDefault();
        //see if the form is valid
        if ($(this).valid()) {
            //AJAX POST
            //getting the URL to POST to from the
            // action attribute of the <form> element
            var urlToPostTo = $(this).attr('action');
            //serializing converts the form fields
            // into a string that we can pass into our
            // $.post() function
            var dataToSend = $(this).serialize();
            $.post(urlToPostTo, dataToSend, function (data) {
                //update the #container elements with the 
                // new HTML returned in the "data" param
                $('#container').html(data);
            });
        }

    });
    
    


});
