$(document).ready(function() {
    $('#PageSizeEnum').change(function () {
        var pageSize = $('select[name="PageSizeEnum"] option:selected').text();
        var pageNumber = $('#PageInfo_PageNumber').val();
        $.ajax({
            method: "POST",
            url: "/Home/Index",
            data: { page: pageNumber, pageSize: pageSize }
        }).success(function(html) {
            $(".home-index-ListModel").empty().append(html);
            $('#PageInfo_PageSize').val(pageSize);
            //$('select[name="page"]').val(pageSize);
        });
    });
});
