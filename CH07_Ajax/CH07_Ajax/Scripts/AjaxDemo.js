$(document).ready(function() {
    $("#privacyLink").click(function() {
        event.preventDefault();
        var url = $(this).attr('href');

        $('#privacy').load(url);
    });

    $("#commentForm").submit(function(event) {
        event.preventDefault();

        var data = $(this).serialize(); //序列化表單為字串
        var url = $(this).attr('action');

        $.post(url, data, function(response) {
            if ($("#comments>li").length > 10)
                $("#comments>li").remove();

            $("#comments").append(response);
            $("#inputComment").val("");
        });
    });
})