// Scroll to top functionality
$(window).scroll(function() {
    if ($(this).scrollTop() > 300) {
        $('.scroll-to-top').addClass('visible');
    } else {
        $('.scroll-to-top').removeClass('visible');
    }
});

$('.scroll-to-top').click(function() {
    $('html, body').animate({scrollTop: 0}, 800);
    return false;
});