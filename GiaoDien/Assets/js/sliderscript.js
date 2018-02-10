$(document).ready(function () {
    $(function () {
        var slider = $('.bxslider').bxSlider({
            mode: "fade",
            pager: false,
            preloadImages: 'all',
            controls : false
        });

        function showNextSlide() {
            slider.goToNextSlide();
        }
        setInterval(showNextSlide, 9000);
    });
})