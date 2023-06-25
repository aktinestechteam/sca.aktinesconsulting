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

    $("#btnFilter").click(function () {
        var scaVersionId = $("#cmbSCAVersions").val();
        if (scaVersionId==='0') {
            showErrorMessage(`Please select version to display.`);
            return;
        }
        getBookingEntries(scaVersionId);
    });

    $("#btnReset").click(function () {
        $("#cmbSCAVersions").val('0');
        dtBookingEntry.clear().draw();
    });

    function getBookingEntries(scaVersionId) {
        dtBookingEntry.clear().draw();
        var url = '/BookingEntry/GetBookingEntries?versionId=' + scaVersionId;
        $.ajax({
            'url': url,
            'method': 'GET',
            'dataType': 'json',
            cache: false,
            'contentType': 'application/json',
            success: function (response) {
                debugger;
                if (response) {
                    var result =response;
                    var rows = [];
                    $.each(result, function (k, v) {
                        rows.push([
                            v["awb"],
                            v["bookingCreatedDate"],
                            v["flightDepartureDate"],
                            v["bookingTime"],
                            v["flightDepartureTime"],
                            v["bookingOrigin"],
                            v["bookingDestination"],
                            v["bookingRateType"],
                            v["agentCode"],
                            v["agentName"],
                            v["bookingDestinationCountry"],
                            v["bookingDestinationRegion"],
                            v["bookingLastUpdatedBy"],
                            v["bookingOriginCountry"],
                            v["bookingOriginSalesArea"],
                            v["bookingOriginRegion"],
                            v["bookingReference"],
                            v["channel"],
                            v["specialHandlingCodes"],
                            v["chargeableWeight"],
                            v["currency"],
                            v["revGBP"],
                            v["revForeign"],
                            v["yieldGBP"],
                            v["yieldForeign"],
                            v["volume"],
                            v["productCode"],
                            v["productName"],
                            v["flightNumber"],
                            v["metalInfo"],
                            v["exceptionId"],
                            v["exceptionDescription"],
                            v["exceptionRuleExist"],
                        ]);
                    });
                    dtBookingEntry.rows.add(rows).draw();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }

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

});