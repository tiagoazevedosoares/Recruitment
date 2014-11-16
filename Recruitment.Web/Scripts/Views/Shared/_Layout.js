var mouse_is_inside = false;
$(document).ready(function () {
    var $l = Ladda.create(document.getElementById("buttonSearch"));

    $("#searchText").on("input propertychange paste", function () {
        var container = $("#quickSearchResult");
        var input = $(this).val();
        if (input.length > 2) {
            var results_loaded = false;
            window.setTimeout(function () {
                if (!results_loaded) $l.start();
            }, 500)
            $.get("/Home/QuickSearch", { searchText: input }, function (data) {
                results_loaded = true;
                $l.stop();

                container.show();
                container.html(data);
            });
        }
        else {
            if ($l !== "undefined")
                $l.stop();

            container.html("");
        }
    });

    $(document).mouseup(function (evt) {
        var container = $("#quickSearchResult");

        if (!container.is(evt.target) && container.has(evt.target).length === 0)
            container.hide();
    });
});