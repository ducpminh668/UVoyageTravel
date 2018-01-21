$(document).ready(function () {
    $(function () {
        var slider = $('.bxslider').bxSlider({
            mode: "fade",
            pager: false
        });

        function showNextSlide() {
            slider.goToNextSlide();
        }
        setInterval(showNextSlide, 9000);
    });

    $("#in-date-checkin").datetimepicker({
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        todayBtn: true,
        minView: 2,
        autoclose: true
    }).on('changeDate', function (ev) {

        var checkinTime = new Date($("#in-date-checkout").val($("#in-date-checkin").val()));
        console.log(checkinTime);
        $("#in-date-checkout").val($("#in-date-checkin").val());
        $("#in-date-checkout").datetimepicker('setStartDate', $("#in-date-checkin").val());
        $("#in-date-checkout").datetimepicker('show');

    });

    $("#in-date-checkout").datetimepicker({
        todayHighlight: true,
        format: 'dd-mm-yyyy',
        todayBtn: true,
        minView: 2,
        autoclose: true
    });
    $('.icon-arrow-right').addClass('fa fa-caret-right');
    var now = new Date();
    var nowString = (now.getDate()) + "-" + (now.getMonth() + 1) + "-" + now.getFullYear();
    var tomorowString = (now.getDate() + 1) + "-" + (now.getMonth() + 1) + "-" + now.getFullYear();
    $("#in-date-checkin").val(nowString);
    $("#in-date-checkout").val(tomorowString);

    $('#ic-date-checkin').click(function () {
        $("#in-date-checkin").datetimepicker('show');
    });
    $('#ic-date-checkout').click(function () {
        $("#in-date-checkout").datetimepicker('show');
    });
});
