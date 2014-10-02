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

    //
    


});
