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
            $('#reservationModal, #equipmentBundleCalendarModal').modal({
                focus: true
            });
        }
    });

});


/*********************************************************************
 * Grid options.
*********************************************************************/

$(document).ready(function () {

    $(".grid-options i").on("click", function() {
        $(this).siblings().removeClass("active");
        $(this).addClass("active");
    });

    $(".grid-options .fa-th-large").on("click", function () {
        $(".equipment, .bundle, .equipment-type").parent(".col-md-12").removeClass("col-md-12").addClass("col-md-4");
    });

    $(".grid-options .fa-th-list").on("click", function () {
        $(".equipment, .bundle, .equipment-type").parent(".col-md-4").removeClass("col-md-4").addClass("col-md-12");
    });

});

/*********************************************************************
 * Toggle equipment types in equipment page.
*********************************************************************/

$(document).ready(function() {
    $(".page-header .page-filters .equipment-types span").on("click", function () {

        $(this).removeClass("disabled");

        if ($(this).attr("class") !== "all-types") {
            $(this).siblings().addClass("disabled");
            $(".page-content .equipment").parent().hide();
            $(".page-content .equipment[data-equipmentType='" + $(this).text() + "']").parent().show();
        } else {
            $(this).siblings().removeClass("disabled");
            $(".page-content .equipment").parent().show();
        }

    });
});

/*********************************************************************
 * Images lightbox for equipment bundle gallery.
*********************************************************************/

$(document).ready(function() {
    lightbox.option({
        'resizeDuration': 200,
        'wrapAround': true
    });
});

/*********************************************************************
 * Adding equipment to equipment bundle. Checkboxes.
*********************************************************************/

$(".equipment-list-item-with-checkbox").on("click", function() {
    $(this).toggleClass("active");
    var checkbox = $(this).find("input[type='checkbox']");
    checkbox.attr("checked", !checkbox.attr("checked"));
});