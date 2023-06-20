$(function () {
    var _scaExceptionFieldId = 0;
    var dtExceptionField = $("#dtExceptionField").DataTable({
        columns: [
            { title: 'Id' },
            { title: 'Edit' },
            { title: 'Delete' },
            { title: 'Exception Field Type' },
            { title: 'Value' },
            { title: 'Exception Field Type Id' },
        ],
        responsive: false,
        pagingType: "numbers",
        scrollX: true,
        scrollY: '60vh',
        paging: false,
        dom: 'Bfrtip',
        buttons: [
            {
                extend: ['excel'],
                exportOptions: {
                    columns: ':visible'
                }
            }
        ]
    })

    getSCAExceptionFields();
    function getSCAExceptionFields() {
        dtExceptionField.clear().draw();
        dtExceptionField.columns.adjust().draw();

        var exceptionFieldTypeId = $('#cmbExceptionFieldType').val();
        if (exceptionFieldTypeId == '-1') return;
        var url = exceptionFieldTypeId == '0'
            ? '/SCAExceptionField/GetBySCAExceptionFieldTypeId'
            : '/SCAExceptionField/GetBySCAExceptionFieldTypeId?scaExceptionFieldTypeId=' + exceptionFieldTypeId;
        $.ajax({
            'url': url,
            'method': 'GET',
            'dataType': 'json',
            cache: false,
            'contentType': 'application/json',
            success: function (response) {
                if (response && response.length > 0) {
                    var rows = [];
                    $.each(response, function (k, v) {
                        var editButton = '<a href="javascript:void(0)" class="edit-exception" data-scaExceptionFieldTypeId=' + v["scaExceptionFieldTypeId"] + ' data-scaExceptionFieldId=' + v["scaExceptionFieldId"] + ' data-scaExceptionFieldValue=' + v["name"] + '><i class="fa fa-edit"></i></a>'
                        var deleteButton = '<a href="javascript:void(0)" class="delete-exception" data-scaExceptionFieldId=' + v["scaExceptionFieldId"] + ' data-scaExceptionFieldValue=' + v["name"] + '><i class="fa fa-trash"></i></a>'
                        rows.push([
                            v["scaExceptionFieldId"],
                            editButton,
                            deleteButton,
                            v["scaExceptionFieldType"],
                            v["name"],
                            v["scaExceptionFieldTypeId"]
                        ]);
                    });
                    dtExceptionField.columns(0).visible(false);
                    dtExceptionField.columns(5).visible(false);
                    dtExceptionField.rows.add(rows).draw();
                    dtExceptionField.columns.adjust().draw();
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
            }
        });
    }

    $("#btnFilter").click(function () {
        getSCAExceptionFields();
    });

    $("#btnReset").click(function () {
        dtExceptionField.clear().draw();
        dtExceptionField.columns.adjust().draw();
        $('#cmbExceptionFieldType').val('-1')
    });
    $("#btnAdd").click(function () {
        _scaExceptionFieldId = 0;
        clearErroMsg();
        $("#cmbaddupdateExceptionFieldType").prop("disabled", false);
        $('#cmbaddupdateExceptionFieldType').val(-1);
        $('#txtExpField').val('');
        $('#addupdateModalLabel').text('Add Exception Field');

    });

    $("#btnSave").click(function () {
        var missingField = [];
        if ($("#cmbaddupdateExceptionFieldType").val() === '-1') 
            missingField.push("Exception Field Type");

        if (!$("#txtExpField").val())
            missingField.push("Value");
        
        if (missingField.length > 0) {
            $('#errorMsg').css('display', 'block');
            $('#errorMsg').text('Required - ' + missingField.toString() + ' .')
            return;
        }
        clearErroMsg();
        var data = {
            scaExceptionFieldId: _scaExceptionFieldId,
            name: $('#txtExpField').val(),
            scaExceptionFieldTypeId:$("#cmbaddupdateExceptionFieldType").val()
        }

        $.ajax({
            url: '/scaexceptionfield/addupdate',
            method: 'Post',
            cache: false,
            data:JSON.stringify(data),
            contentType: 'application/json',
            dataType: 'json',
            success: function (response) {
                toastr.success("Exception Field saved successfully");
                getSCAExceptionFields();
                $('#addupdateModal').modal('hide');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $('#addupdateModal').modal('hide');
            }
        });


    });
    function clearErroMsg() {
        $('#errorMsg').css('display', 'none');
        $('#errorMsg').text('');
    }
    $(document).on('click', '.edit-exception', function () {
        var entry = this;
        _scaExceptionFieldId = entry.getAttribute('data-scaExceptionFieldId');
        var scaExceptionFieldValue = entry.getAttribute('data-scaExceptionFieldValue');
        var scaExceptionFieldTypeId = entry.getAttribute('data-scaExceptionFieldTypeId');
        clearErroMsg();
        $('#addupdateModalLabel').text('Update Exception Field');
        $('#txtExpField').val(scaExceptionFieldValue);
        $('#cmbaddupdateExceptionFieldType').val(scaExceptionFieldTypeId);
        $('#addupdateModal').modal('show');
        $("#cmbaddupdateExceptionFieldType").prop("disabled", true);
    });
    $(document).on('click', '.delete-exception', function () {
        var entry = this;
        _scaExceptionFieldId = Number(entry.getAttribute('data-scaExceptionFieldId'));
        var scaExceptionFieldValue = entry.getAttribute('data-scaExceptionFieldValue');
        Swal.fire({
            title: '<span style="font-size:14px">Do you want to Delete <span style="color:#e63339;font-size:14px"> Exception Field : ' + scaExceptionFieldValue + '</span></span><br> Are you sure?',
            text: "You won't be able to revert this!",
            icon: 'question',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Yes, delete it!'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: '/SCAExceptionField/delete?scaExceptionFieldId=' + _scaExceptionFieldId,
                    method: 'POST',
                    cache: false,
                    contentType: 'application/json',
                    success: function (response) {
                        Swal.fire(
                            'Deleted!',
                            'Exception field has been deleted.',
                            'success'
                        )
                        getSCAExceptionFields();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $('#addupdateModal').modal('hide');
                    }
                });
            }
        })
    });
    $(document).on('click', '.closeaddupdateModal', function () {
        $('#addupdateModal').modal('hide');
    });
    $('#cmbaddupdateExceptionFieldType').change(function () {
        $('#txtExpField').val('');
    });
});