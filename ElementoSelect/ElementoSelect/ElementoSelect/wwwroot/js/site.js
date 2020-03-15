// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const selectElement = document.getElementById('ClienteId');
selectElement.addEventListener('change', (event) => {
    console.log(event);
    console.log(event.target.selectedOptions);
    alert(`Seleccionaste ${event.target.value}`);

});



////Select OdbcDriver Event
//$('#DriverId').on('change', function () {
//    var driverId = $(this).val();
//    if (driverId === 14 || driverId === 15) {
//        btnTest.data("validate", "file");
//        btnTest.data("type", "file");
//    } else {
//        btnTest.data("validate", "odbc");
//        btnTest.data("type", "odbc");
//    }
//    console.log(btnTest.data("validate"));
//    $.ajax({
//        type: "GET",
//        url: '/Odbc/driverfields/' + driverId,
//        success: function (data) {
//            $.each(data, function (k, v) {
//                let slctor = '#' + k;
//                v ? $(slctor).removeClass('d-none') : $(slctor).addClass('d-none');
//            });
//            ajaxCallGetFiles(driverId);
//        },
//        dataType: "JSON"
//    });

//});


//$(function () {
//    //Select OdbcDriver Event
//    $('#Id').on('change', function () {
//        var driverId = $(this).val();
//        $.ajax({
//            type: "GET",
//            url: '/Odbc/driverfields/' + driverId,
//            success: function (data) {
//                $.each(data, function (k, v) {
//                    let slctor = '#' + k;
//                    v ? $(slctor).removeClass('d-none') : $(slctor).addClass('d-none');
//                });
//                ajaxCallGetFiles(driverId);
//            },
//            dataType: "JSON"
//        });
//    });

//    function ajaxCallGetFiles(driverId) {
//        let select = $('#FilePath');
//        select.empty();
//        if (driverId !== '0') {
//            $.ajax({
//                type: 'GET',
//                url: '/Odbc/ShowFiles/' + filter,
//                success: function (data) {
//                    $.each(data, function (key, value) {
//                        select.append(
//                            $('<option>', {
//                                value: value.value,
//                                text: value.text,
//                                selected: value.selected,
//                                disabled: value.disabled
//                            })
//                        );
//                    });
//                }
//            });
//        }
//    }
//});