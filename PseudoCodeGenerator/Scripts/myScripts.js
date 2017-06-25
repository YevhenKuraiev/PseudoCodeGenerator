$(document).ready(function () {
    var firstColor = $("#shrink > div").css("background-color");
    var secondColor = "rgba(255,255,255,0.5)";
    var shrink = $("#shrink");
    var doggy = $("#shrink > div");
    var angle;
    doggy.mousedown(function (eventDown) {
        eventDown.preventDefault();
        var differenceUp = (eventDown.pageY - doggy.offset().top);
        var differenceDown = ((doggy.offset().top + doggy.height()) - eventDown.pageY);
        $(document).mousemove(function (eventMove) {
            if (eventMove.pageY >= (shrink.offset().top + differenceUp) && eventMove.pageY <= (shrink.offset().top + shrink.height() - differenceDown)) {
                doggy.offset({ top: (eventMove.pageY - differenceUp) });
            }
            else if (eventMove.pageY <= (shrink.offset().top + differenceUp)){
                doggy.offset({ top: shrink.offset().top });
            }
            else if (eventMove.pageY >= (shrink.offset().top + shrink.height() - differenceDown)) {
                doggy.offset({ top: shrink.offset().top + shrink.height() - doggy.height() });
            }
        });
        doggy.css({ "background-color": secondColor });
    });
    $(document).mouseup(function (eventUp) {
        $(document).unbind("mousemove");
        doggy.css({ "background-color": firstColor });
        if (doggy.offset().top == shrink.offset().top + shrink.height() - doggy.height()) {
            $(".pseudoCodeArea").fadeOut(300);
        }
        else {
            doggy.animate({ top: 0 }, 100);
        }
    });
});