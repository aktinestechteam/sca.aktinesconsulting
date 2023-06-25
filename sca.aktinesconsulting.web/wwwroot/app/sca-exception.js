

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
    })
    $('#btnUpload').click(function () {
        //Set the URL.
        var url = $("#fmUpload").attr("action");
        //Add the Field values to FormData object.
        var formData = new FormData();
        if (!$("#formFile")[0].files || $("#formFile")[0].files.length===0) {
            showErrorMessage(`File has not selected for process.`);
            return;
        }
        formData.append("file", $("#formFile")[0].files[0]);
        dtBookingEntry.clear().draw();
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false
        }).done(function (response) {
            if (response) {
                var result = $.parseJSON(response);
                var rows = [];
                $.each(result, function (k, v) {
                    rows.push([
                        v["AWB"],
                        v["BookingCreatedDate"],
                        v["FlightDepartureDate"],
                        v["BookingTime"],
                        v["FlightDepartureTime"],
                        v["BookingOrigin"],
                        v["BookingDestination"],
                        v["BookingRateType"],
                        v["AgentCode"],
                        v["AgentName"],
                        v["BookingDestinationCountry"],
                        v["BookingDestinationRegion"],
                        v["BookingLastUpdatedBy"],
                        v["BookingOriginCountry"],
                        v["BookingOriginSalesArea"],
                        v["BookingOriginRegion"],
                        v["BookingReference"],
                        v["Channel"],
                        v["SpecialHandlingCodes"],
                        v["ChargeableWeight"],
                        v["Currency"],
                        v["RevGBP"],
                        v["RevForeign"],
                        v["YieldGBP"],
                        v["YieldForeign"],
                        v["Volume"],
                        v["ProductCode"],
                        v["ProductName"],
                        v["FlightNumber"],
                        v["MetalInfo"],
                        v["ExceptionId"],
                        v["ExceptionDescription"],
                        v["ExceptionRuleExist"],
                    ]);
                });
                dtBookingEntry.rows.add(rows).draw();
            }
        });
    });
    function showErrorMessage(message) {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-right",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": 100,
            "hideDuration": 200,
            "timeOut": 2000,
            "extendedTimeOut": 100,
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        }
        toastr.error(message)
    }

    $("#btnExceptions").click(function () {
        window.location.href = '/scaexception/setting/view';
    });
    $("#btnVersionHistory").click(function () {
        window.location.href = '/sca/bookingentry/versionhistory';
    });

});