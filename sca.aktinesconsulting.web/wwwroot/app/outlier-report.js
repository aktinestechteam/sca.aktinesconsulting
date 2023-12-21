$(function () {
    var dtBookingEntry = $("#dtBookingEntry").DataTable({
        responsive: false,
        pagingType: "numbers",
        scrollX: true,
        scrollY: '60vh',
        paging: false,
        dom: 'Bfrtip',
        buttons: [
            'colvis',
            'excel',
        ]
    });

    $('#btnRun').click(function () {
        $("#errorMsg").text("");

        if (parseInt($('#cmbYear').val()) === 0 ||
            parseInt($('#cmbMonth').val()) === 0
        ) {
            $("#errorMsg").text("Please Select mandatory fields");
            $("#errorMsg").show();
            return;
        }
        $("#errorMsg").hide();
        dtBookingEntry.clear().draw();
        $('.loader').show();
        var url = '/Report/OutlierReport';
        var data = {
            LastBookingVersionYearId: parseInt($('#cmbYear').val()),
            LastBookingVersionMonthId: parseInt($('#cmbMonth').val())
        };
        $.ajax({
            url: url,
            method: 'POST',
            cache: false,
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                debugger;
                $('.loader').hide();
                if (response) {
                    var rows = [];
                    $.each(response, function (k, v) {
                        rows.push([
                            v["bookingOrigin"],
                            v["bookingDestination"],
                            v["awb"],
                            v["agentName"],
                            v["leChargeableWeight"],
                            v["leRevForeign"],
                            v["beChargeableWeight"],
                            v["beEmailWeight"],
                            v["beRevForeign"],
                            v["beEmailRevenue"],
                            0,
                            0,
                            0
                        ]);
                    });
                    dtBookingEntry.rows.add(rows).draw();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $('.loader').hide();
            }
        })



    });

});