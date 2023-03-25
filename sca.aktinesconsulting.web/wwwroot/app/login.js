$(function () {
    $("#login-form").validate({
        rules: {
            email: {
                required: !0,
                email: !0
            },
            password: {
                required: !0,
                minlength: 6
            }
        },
        messages: {
            email: {
                required: "Please enter your email",
                email: "Your email is not valid"
            },
            password: {
                required: "Please provide your password",
                minlength: $.validator.format("Please enter at least {0} characters")
            }
        },
        highlight: function (e, i, a) {
            $(e).addClass("is-invalid"), $(e).removeClass("is-valid")
        },
        unhighlight: function (e, i, a) {
            $(e).removeClass("is-invalid"), $(e).addClass("is-valid")
        },
        errorPlacement: function (e, i) {
            e.addClass("invalid-feedback"), i.closest(".validation-container").append(e)
        },
        //submitHandler: function (e) {
        //    submitForm();
        //}
    })

    //function submitForm() {
    //    window.location.href = '/scaexception/index';
    //}

});