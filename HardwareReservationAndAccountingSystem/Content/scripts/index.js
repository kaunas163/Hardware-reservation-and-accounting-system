/* =================================================================
   Data filtering by text with JavaScript.
================================================================= */

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

/* =================================================================
   FullCalendar library.
================================================================= */

// import { Calendar } from '@fullcalendar/core';
// import dayGridPlugin from '@fullcalendar/daygrid';

// document.addEventListener('DOMContentLoaded', function() {
//   var calendarEl = document.getElementById('calendar');

//   var calendar = new Calendar(calendarEl, {
//     plugins: [ dayGridPlugin ]
//   });

//   calendar.render();
// });




// $(function () {

//     var eventsData = $(".hidden-events-data .reservation-data-item");
//     var eventsArray = [];

//     for (var i = 0; i < eventsData.length; i++) {
//         var event = {
//             title: $(eventsData[i]).data("bundle"),
//             start: $(eventsData[i]).data("from"),
//             end: $(eventsData[i]).data("to"),
//             textColor: "white",
//             data: {
//                 description: $(eventsData[i]).data("reservationid")
//             }
//         };
//         eventsArray.push(event);
//     }

//     $('#calendar').fullCalendar({
//         selectable: true,
//         header: {
//             right: 'month,agendaWeek,agendaDay,listWeek prev,next'
//         },
//         select: function (startDate, endDate) {
//             $('#reservationModal, #equipmentBundleCalendarModal').on('show.bs.modal', function (event) {
//                 var modal = $(this);

//                 var localDateFrom = $.fullCalendar.moment(startDate).format("YYYY-MM-DD HH:mm");
//                 var localDateTo = $.fullCalendar.moment(endDate).format("YYYY-MM-DD HH:mm");

//                 modal.find("#dateFrom").val(localDateFrom);
//                 modal.find("#dateTo").val(localDateTo);
//             });

//             $('#reservationModal, #equipmentBundleCalendarModal').modal({
//                 focus: true
//             });
//         },
//         eventClick: function (calEvent) {
//             //alert('Event: ' + calEvent.title);

//             $('#eventModal').on('show.bs.modal', function (event) {
//                 var modal = $(this);

//                 //var localDateFrom = $.fullCalendar.moment(startDate).format("YYYY-MM-DD HH:mm");
//                 //var localDateTo = $.fullCalendar.moment(endDate).format("YYYY-MM-DD HH:mm");

//                 modal.find(".title").text(calEvent.title);
//                 modal.find(".from").text($.fullCalendar.moment(calEvent.start).format("YYYY-MM-DD HH:mm"));
//             modal.find(".to").text($.fullCalendar.moment(calEvent.end).format("YYYY-MM-DD HH:mm"));
//             });

//             $('#eventModal').modal({
//                 focus: true
//             });

//         },
//         events: eventsArray
//     });

// });


/* =================================================================
   Grid options.
================================================================= */

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

/* =================================================================
   Toggle equipment types in equipment page.
================================================================= */

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

/* =================================================================
   Images lightbox for equipment bundle gallery.
================================================================= */

$(document).ready(function() {
    lightbox.option({
        'resizeDuration': 200,
        'wrapAround': true
    });
});

/* =================================================================
   Adding equipment to equipment bundle.
   Or choose equipment bundle for reservation.
   Checkboxes or radios.
================================================================= */

$(".equipment-or-bundle-list-item-with-selection").on("click", function () {

    if ($(this).hasClass("radio")) {
        $(".equipment-or-bundle-list-item-with-selection").removeClass("active");
        $(".equipment-or-bundle-list-item-with-selection input").attr("checked", false);
        $(this).addClass("active");
        $(this).find("input").attr("checked", true);
    } else {
        $(this).toggleClass("active");
        var checkbox = $(this).find("input");
        checkbox.attr("checked", !checkbox.attr("checked"));
    }

});

/* =================================================================
   Export modal
================================================================= */

$(document).ready(function() {
    $('.export-modal .modal-body .filter-group .buttons-group .btn').on('click', function() {
        $(this).siblings().removeClass('btn-dark').addClass('btn-link')
        $(this).removeClass('btn-link').addClass('btn-dark');
    });
});

/* =================================================================
   View modes
================================================================= */

$(document).ready(function() {
    $('.page-filters .view-mode .mode.btn').on('click', function() {
        $(this).siblings().removeClass('active');
        $(this).addClass('active');
        $('.view-mode-content-block').removeClass('active');
    });

    $('.page-filters .view-mode .mode.btn.mode-list').on('click', function() {
        $('.view-mode-content-block.view-mode-list').addClass('active');
    });

    $('.page-filters .view-mode .mode.btn.mode-table').on('click', function() {
        $('.view-mode-content-block.view-mode-table').addClass('active');
    });
});

/* =================================================================
   ...
================================================================= */




