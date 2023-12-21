

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
        $("#errorMsg").text("");
        if (parseInt($('#cmbYear').val()) === 0 ||
            parseInt($('#cmbMonth').val()) === 0 ||
            parseInt($('#cmbDay').val()) === 0
        ) {
            $("#errorMsg").text("Please Select mandatory fields");
            $("#errorMsg").show();
            return;
        }

        if (!$("#formFile")[0].files || $("#formFile")[0].files.length === 0) {
            $("#errorMsg").text(`File has not selected for upload.`);
            $("#errorMsg").show();
            return;
        }

        $("#errorMsg").hide();
        dtBookingEntry.clear().draw();
        var url = "/LastBookingEntry/IsExist?LastBookingVersionYearId=" + parseInt($('#cmbYear').val()) + "&LastBookingVersionMonthId=" + parseInt($('#cmbMonth').val()) + "&LastBookingVersionDayId=" + parseInt($('#cmbDay').val());
        $.ajax({
            type: 'GET',
            url: url,
            processData: false,
            contentType: false
        }).done(function (response) {
            if (response) {
                var confirmationObj = {
                    title: '<span style="font-size:14px">Data alredy exist</span>',
                    text: "Data already exists. Do you want to overwrite the existing data?",
                    icon: 'question',
                    showCancelButton: true,
                    confirmButtonColor: '#3085d6',
                    cancelButtonColor: '#d33',
                    confirmButtonText: 'Yes, overwrite it!'
                }
                Swal.fire(confirmationObj).then((result) => {
                    if (result.isConfirmed) {
                        UploadLastBookingEntryRport();
                    }
                });
            }
            else {
                UploadLastBookingEntryRport();
            }
        });
        
        //UploadLastBookingEntryRport();

    });

    function UploadLastBookingEntryRport() {
        $('.loader').show();
        //Set the URL.
        var url = $("#fmUpload").attr("action");
        //Add the Field values to FormData object.
        var formData = new FormData();
        if (!$("#formFile")[0].files || $("#formFile")[0].files.length === 0) {
            showErrorMessage(`File has not selected for process.`);
            return;
        }
        formData.append("file", $("#formFile")[0].files[0]);
        formData.append('lastBookingVersionYearId', $('#cmbYear').val());
        formData.append('lastBookingVersionMonthId', $('#cmbMonth').val());
        formData.append('lastBookingVersionDayId', $('#cmbDay').val());
      
        $.ajax({
            type: 'POST',
            url: url,
            data: formData,
            processData: false,
            contentType: false
        }).done(function (response) {
            $('.loader').hide();
            if (response) {
                toastr.success("Last booking entries successfully imported");
                refreshData(response);
            }
            else {
                $("#errorMsg").text(`The date filter selection and FLIGHT_DEP_DATE do not match. Please verify FLIGHT_DEP_DATE in upload file.`);
                $("#errorMsg").show();
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

    $("#btnDownload").click(function (e) {
        $("#errorMsg").text("");
        if (parseInt($('#cmbYear').val()) === 0 ||
            parseInt($('#cmbMonth').val()) === 0 ||
            parseInt($('#cmbDay').val()) === 0
        ) {
            $("#errorMsg").text("Please Select mandatory fields");
            $("#errorMsg").show();
            return;
        }
        $("#errorMsg").text("");
        $("#errorMsg").hide();

        $('.loader').show();
        var url = "/LastBookingEntry/IsExist?LastBookingVersionYearId=" + parseInt($('#cmbYear').val()) + "&LastBookingVersionMonthId=" + parseInt($('#cmbMonth').val()) + "&LastBookingVersionDayId=" + parseInt($('#cmbDay').val());
        $.ajax({
            type: 'GET',
            url: url,
            processData: false,
            contentType: false
        }).done(function (response) {
            $('.loader').hide();
            if (response) {
                var downloadurl = "/LastBookingEntry/ExportToExcel?LastBookingVersionYearId=" + parseInt($('#cmbYear').val()) + "&LastBookingVersionMonthId=" + parseInt($('#cmbMonth').val()) + "&LastBookingVersionDayId=" + parseInt($('#cmbDay').val());
                e.preventDefault(); // Prevent the default behavior of navigating to a new page
                window.location.href = downloadurl;
              
            }
            else {
                toastr.error("Data not Exist");
            }
        });
    });

    $("#btnDuplicate").click(function () {
        $("#errorMsg").text("");
        if (parseInt($('#cmbYear').val()) === 0 ||
            parseInt($('#cmbMonth').val()) === 0 ||
            parseInt($('#cmbDay').val()) === 0
        ) {
            $("#errorMsg").text("Please Select mandatory fields");
            $("#errorMsg").show();
            return;
        }
        $("#errorMsg").text("");
        $("#errorMsg").hide();
        dtBookingEntry.clear().draw();
        var url = "/LastBookingEntry/IsExist?LastBookingVersionYearId=" + parseInt($('#cmbYear').val()) + "&LastBookingVersionMonthId=" + parseInt($('#cmbMonth').val()) + "&LastBookingVersionDayId=" + parseInt($('#cmbDay').val());
        $.ajax({
            type: 'GET',
            url: url,
            processData: false,
            contentType: false
        }).done(function (response) {
            if (response) {
                getDuplicateEnties();
            }
            else {
                toastr.error("Data not Exist");
            }
        });
    });

    function getDuplicateEnties() {

        $('.loader').show();

        var url = "/LastBookingEntry/GetDuplicates?LastBookingVersionYearId=" + parseInt($('#cmbYear').val()) + "&LastBookingVersionMonthId=" + parseInt($('#cmbMonth').val()) + "&LastBookingVersionDayId=" + parseInt($('#cmbDay').val());
        $.ajax({
            type: 'GET',
            url: url,
            processData: false,
            contentType: false
        }).done(function (response) {
            $('.loader').hide();
            if (response) {
                refreshData(response);
            }
            else {
                toastr.error("Data not Exist");
            }
        });
    }
    function refreshData(data) {
       
        var rows = [];
        $.each(data, function (k, v) {
            var editButton = '<input type="checkbox"  class="edit-bookingEntry"  data-bookingEntryId=' + v["bookingEntryId"] + ' ' + (v["isConsidered"]==true?"Checked":"") + ' style="margin-left:20px">';
            rows.push([
                editButton,
                v["awb"],
                v["bookingLegStatus"],
                v["bookingCreatedDate"],
                v["flightDepartureDate"],
                v["bookingTime"],
                v["flightDepartureTime"],
                v["bookingOrigin"],
                v["bookingDestination"],
                v["bookingRateType"],
                v["agentName"],
                v["bookingRowNumber"],
                v["bookingKey"],
                v["bookingDestinationRegion"],
                v["bookingLastUpdatedBy"],
                v["bookingLastUpdatedByGMT"],
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
                v["bookingLegVolume"],
                v["volume"],
                v["productCode"],
                v["productName"],
                v["flightNumber"],
                v["metalInfo"],
            ]);
        });
        dtBookingEntry.rows.add(rows).draw();
    }

    $(document).on('click', '.edit-bookingEntry', function () {
        let element = $(this);
        let bookingEntryId = element.attr('data-bookingEntryId');
        let isConsidered = element.prop("checked");
        var data = {
            bookingEntryId: Number(bookingEntryId),
            isConsidered: isConsidered,
        }
        $.ajax({
            type: 'POST',
            url: '/lastBookingEntry/updateIsConsidered',
            cache: false,
            data: JSON.stringify(data),
            contentType: 'application/json',
            dataType: 'json',
        }).done(function (response) {
            console.log("Updated");
        });
    });


});