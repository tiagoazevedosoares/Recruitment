$(document).ready(function () {
    $("#searchText").on("input propertychange paste", function () {
        var input = $(this).val();
        if (input.length > 2)
        {
            $.get("Home/QuickSearch", {searchText: input}, function (data) {
                $("#quickSearchResult").html(data);
            });
        }
        else
            $("#quickSearchResult").html("");
    })
})