$(document).ready(function () {
    $(".grid-item").hide();// hide it initially

});
$("#card").flip({
    trigger: "manual"
});


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

function isValidEmail(email) {
    var regex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;
    if (email.match(regex)) {

        console.log('true')

        return true;
    }
    else {
        console.log('false');

        return false;
    }
}

function getDetails() {
    $(".grid-item").hide();
    $("#card").flip(false);
    $('#progress').attr('hidden', false);
    $('#progressbar').attr('hidden', false);
    var millisecondsToWait = 500;
    var email = getParameterByName('Email');
    //console.log(email);
    if (email != null && isValidEmail(email)) {
        setTimeout(function () {
            $("#progressbar").removeClass("progress-bar-green");
            $("#progressbar").css("width", "30%");
            $("#progressbar").text("30%..finished gathering email");
        }, 400);
        setTimeout(function () {
            $("#progressbar").css("width", "40%");
            $("#progressbar").text("40%. Building AJAX request");
        }, 900);
        setTimeout(function () {
            $("#progressbar").css("width", "50%");
            $("#progressbar").text("50%..SENDING AJAX Request");
            sendRequest(email);
        }, 1300);
    }
    else {
        setTimeout(function () {
            $("#progressbar").css("width", "30%");
            $("#progressbar").text("30%.. gathering email..");
        }, 400);
        setTimeout(function () {
            $("#progressbar").css("width", "34%");
            $("#progressbar").text("34%..still working on getting email");
        }, 800);
        setTimeout(function () {
            $("#progressbar").css("width", "35%");
            $("#progressbar").text("35%..unable to fetch email");
        }, 1200);
        setTimeout(function () {
            $("#progressbar").css("width", "100%");
            $("#progressbar").text("Sorry an unexpected error has occurred");
            $("#progressbar").addClass("progress-bar-danger");
        }, 1600);
        setTimeout(function () {
            $("#pLead").text("Your email is: " + email + ".");
            $("#pTrail").text("Unable to find records with " + email);
            $("#card").flip(true);
        }, 1900);


    }



    // sendRequest(email);
}

function sendRequest(email) {

    $.ajax({
        type: 'POST',
        url: 'Success.aspx/findUser',

        contentType: "application/json; charset=utf-8", dataType: "json",
        type: "POST",
        data: "{email: '" + (email) + "'}",
        success: function (r) {

            setTimeout(function () {
                $("#progressbar").css("width", "60%");
                $("#progressbar").text("60%..Reading data");
                readDetails(r);
                $('.grid-item-label').fadeIn(1000);
            }, 1800);
            setTimeout(function () {
                $("#progressbar").css("width", "90%");
                $("#progressbar").text("90%..Building Grid");
            }, 2400);
            setTimeout(function () {
                $("#progressbar").css("width", "95%");
                $("#progressbar").text("95%..Populating the Grid");
            }, 3400);
            setTimeout(function () {
                $("#progressbar").css("width", "98%");
                $("#progressbar").text("98%..Completed");
            }, 4000);
            setTimeout(function () {
                $("#firstName").fadeIn(2000);

            }, 4800);
            setTimeout(function () {
                $("#lastName").fadeIn(2000);
            }, 6800);
            setTimeout(function () {

                $("#Email").fadeIn(2000);
            }, 8800);
            setTimeout(function () {

                $("#Pnumber").fadeIn(2000);
            }, 9800);
            setTimeout(function () {
                $("#zipcode").fadeIn(2000);
            }, 10800);
            setTimeout(function () {
                $("#progressbar").css("width", "100%");
                $("#progressbar").addClass("progress-bar-green");
                $("#progressbar").text("100%..Complete");
                $("#state").fadeIn(1000);
            }, 12800);
            setTimeout(function () {
                $("#pLead").text("Congratulations! " + r.d.FirstName);
                $("#pTrail").text("Your email address is " + email);
                $("#card").flip('toggle');
                $("#card").flip(true);
            }, 12900);

            ;
        },
        error: function (e) {
            alert(e);
        }

    });

}

function readDetails(r) {
    var record = r.d;
    var firstName = record.FirstName;
    var lastName = record.LastName;
    var email = record.Email;
    var phoneNumber = record.Pnumber;
    var zipcode = record.zipcode;
    var state = record.State;

    document.getElementById('firstName').innerHTML = firstName;
    document.getElementById('lastName').innerText = lastName;
    document.getElementById('Email').innerText = email;
    document.getElementById('Pnumber').innerText = phoneNumber;
    document.getElementById('zipcode').innerText = zipcode;
    document.getElementById('state').innerText = state;


}