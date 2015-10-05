$(document).ready(function() {
    $("#privacyLink").click(function() {
        event.preventDefault();
        var url = $(this).attr('href');

        $('#privacy').load(url);
    });
})