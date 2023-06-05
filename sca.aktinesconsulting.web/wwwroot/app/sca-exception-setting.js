$(function () {
    var dtExceptions = $("#dtExceptions").DataTable({
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
    getSCAExceptions();
    function getSCAExceptions() {
        dtExceptions.clear().draw();
        $.ajax({
            'url': '/scaexceptionsetting/getall',
            'method': 'GET',
            'dataType': 'json',
            cache: false,
            'contentType': 'application/json',
            success: function (response) {
                if (response && response.length > 0) {
                    var rows = [];
                    $.each(response, function (k, v) {
                        var editButton = '<a href="javascript:void(0)" class="edit-exception" data-scaexceptionid=' + v["scaExceptionId"] + '><i class="fa fa-edit"></i></a>'
                        var deleteButton = '<a href="javascript:void(0)" class="delete-exception" data-scaexceptionid=' + v["scaExceptionId"] + '><i class="fa fa-trash"></i></a>'
                        rows.push([
                            v["scaExceptionId"],
                            editButton,
                            deleteButton,
                            v["startDateText"],
                            v["endDateText"],
                            v["description"],
                            v["bookingOrigin"],
                            v["bookingDestination"],
                            v["bookingRateType"],
                            v["agentCode"],
                            v["bookingDestinationCountry"],
                            v["bookingDestinationRegion"],
                            v["bookingOriginCountry"],
                            v["bookingOriginSalesArea"],
                            v["bookingOriginRegion"],
                            v["channel"],
                            v["specialHandlingCodes"],
                            v["productCode"],
                            v["metalInfo"],
                            v["excludeBookingOrigin"],
                            v["excludeBookingDestination"],
                            v["excludeBookingRateType"],
                            v["excludeBookingDestinationRegion"],
                            v["excludeAgentCode"],
                            v["excludeBookingDestinationCountry"],
                            v["excludeBookingOriginCountry"],
                            v["excludeBookingOriginSalesArea"],
                            v["excludeBookingOriginRegion"],
                            v["excludeChannel"],
                            v["excludeSpecialHandlingCodes"],
                            v["excludeProductCode"],
                            v["excludeMetalInfo"],
                            getOperatorValue(v["isChargeableWeightRange"], v["chargeableWeight"], v["isChargeableWeightLessThan"], v["isChargeableWeightEqualTo"], v["isChargeableWeightLessthanEqualTo"], v["isChargeableWeightGreaterThan"], v["isChargeableWeightGreaterThanEqualTo"]),
                            v["chargeableWeightRangeFrom"],
                            v["chargeableWeightRangeTo"],
                            getOperatorValue(v["isVolumeRange"], v["volume"], v["isVolumeLessThan"], v["isVolumeEqualTo"], v["isVolumeLessthanEqualTo"], v["isVolumeGreaterThan"], v["isVolumeGreaterThanEqualTo"]),
                            v["volumeRangeFrom"],
                            v["volumeRangeTo"]
                        ]);
                    });
                    dtExceptions.rows.add(rows).draw();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });

    }
    $('#btnAdd').click(function () {
        window.location.href = '/scaexception/setting/add';
    });
    $(document).on('click', '.edit-exception', function () {
        var entry = this;
        var scaExceptionid = entry.getAttribute('data-scaexceptionid');
        window.location.href = '/scaexception/setting/update/' + scaExceptionid;
    });
    $(document).on('click', '.delete-exception', function () {
        var entry = this;
        var scaExceptionid = entry.getAttribute('data-scaexceptionid');
        Swal.fire({
            title: '<span style="font-size:14px">Do you want to Delete <span style="color:#e63339;font-size:14px"> Exception : ' + scaExceptionid + '</span></span><br> Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/scaexceptionsetting/delete?scaExceptionId=' + scaExceptionid,
                    method: 'POST',
                    cache: false,
                    contentType: 'application/json',
                    success: function (response) {
                        Swal.fire(
                            'Deleted!',
                            'Your exception has been deleted.',
                            'success'
                        )
                        getSCAExceptions();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });



            }
        })
    });
    function getOperatorValue(isApplicable, value, opLessThan, opEqualTo, opLessthanEqualTo, opGreaterThan, opGreaterThanEqualTo) {
        if (!value)
            return value;
        var operator = "";
        if (!isApplicable) {

            if (opLessThan) operator = "<";
            else if (opEqualTo) operator = "=";
            else if (opLessthanEqualTo) operator = "<=";
            else if (opGreaterThan) operator = ">";
            else if (opGreaterThanEqualTo) operator = ">=";
            operator = operator + ' ' + value;
        }
        else {
            operator = value;
        }

        return operator ? operator : '';
    }

});

