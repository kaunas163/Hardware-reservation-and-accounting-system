/*********************************************************************
 * Data filtering by text with JavaScript.
*********************************************************************/

$(document).ready(function () {

    var searchBox = $(".page-header .page-filters .filter-by-text");
    var dataBlocks = $(".content-block");

    $(searchBox).keyup(function () {
        var searchTerm = new RegExp($(searchBox).val(), "i");

        dataBlocks.filter(function() {
            $(this).each(function () {

                if ($(this).find(".heading p").text().match(searchTerm)
                    || $(this).find(".description p").text().match(searchTerm)) {
                    $(this).parent().show();
                } else {
                    $(this).parent().hide();
                }

            });
        });
    });

});

/*********************************************************************
 * FullCalendar library.
*********************************************************************/

$(function () {

    $('#calendar').fullCalendar({
        selectable: true,
        header: {
            right: 'month,agendaWeek,agendaDay,listWeek prev,next'
        },
        select: function (startDate, endDate) {
            $('#exampleModal').modal({
                focus: true
            });
        }
    });

});