/*防止文档在完全加载（就绪）之前(不包括图片等)运行 jQuery 代码*/
$(document).ready(
    function () {
        $(".calendar_icon").hover(function () {
            $(this).css("display", "none");
            $(".calendar").css("display", "inline-block");
        });
        $(".calendar").mouseout(function () {
            $(this).css("display", "none");
            $(".calendar_icon").css("display", "inline-block");
        });
        getCurrentDate(new Date());
    }
);
function getCurrentDate(date) {
    var h = date.getHours();
    var m = date.getMinutes();
    var s = date.getSeconds();
    var str = (h < 10 ? ('0' + h) : h) + ':' + (m < 10 ? ('0' + m) : m) + ':' + (s < 10 ? ('0' + s) : s);
    $(".currentTime").html(str);
    setTimeout("getCurrentDate(new Date())", 1000);
}