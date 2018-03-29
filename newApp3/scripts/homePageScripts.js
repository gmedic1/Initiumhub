$("#card").flip({
    trigger: "manual"
});
var isValidName;
function validateName(t) {

    var regex = new RegExp(/^[a-z\-\'\s]+$/i);
    //console.log('name being validated')

    if (regex.test(t)) {
        $('#txtLastName').next().removeClass('ion-alert-circled');
        isValidName = true;
       // console.log('name validated');
        return true;
    }
    else {

        $('#txtLastName').addClass('ion-alert-circled');
        isValidName = false;
        //console.log('name failed');
        return false;
    }



}

var isValidEmail;
function validateEmail(email) {
    var regex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;
    var email = email;
   // console.log(email);
    //console.log(email);
    if (email.match(regex)) {
        $('#txtEmail1').next().removeClass('ion-alert-circled');
        //console.log('true')
        isValidEmail = true;
        return true;
    }
    else {
        $('#txtEmail1').addClass('ion-alert-circled');
        isValidEmail = false;
       // console.log('failed');
        return false;
    }
}
var isValidPhoneNumber;
function validatePhone(phone) {
    var regex = /^\d{10}$/;
   // console.log('Phone being validated')
    if (regex.test(phone)) {
        //console.log(true);
        //console.log('phone okay')
        isValidPhoneNumber = true;
        $('#txtPhoneNumber').removeClass('ion-alert-circled');
        return true;
    }
    else {
        isValidPhoneNumber = false;
        //console.log('phone false')
        $('#txtPhoneNumber').addClass('ion-alert-circled');
        return false;

    }
}
var globalEmail; var globalMessageStamp;
function sendSubscriptions() {

    var name = txtUserName.value;
    var email = txtEmail1.value;
    var phone = txtPhone.value;
    var message = txtMessage.value;
    globalEmail = email;
    var messageStamp = Date.now().toString(); globalMessageStamp = messageStamp;
    //console.log('Date now');
    //console.log(messageStamp);
    //console.log('global:' + globalEmail);
    //alert(name);
    //alert(email);
    //alert(phone);
    //alert(message);
    validateEmail(email); validatePhone(phone); validateName(name);
    //isValidName = true; isValidPhoneNumber = true; isValidEmail = true;
    var message = { Name: name, Email: email, Phone: phone, userMessage: message.replace('"', '&quot'), MessageStamp: messageStamp };
    // var message1 = Name + " " + Email + " " + Phone + " " + Message;
    if (isValidName && isValidEmail && isValidPhoneNumber) {
       // console.log('message being sent from js:' + message);
        //console.log(message);
      //  console.log('message strgingified:2' + JSON.stringify(message))
        $.ajax({
            type: 'POST',
            url: 'services.asmx/sendMessage',
            data: "{Message: '" + JSON.stringify(message) + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnSuccessCall,
            error: OnErrorCall
        });

        function OnSuccessCall(response) {
            // alert(response.d);
            //console.log('getting user')
            getUserMessage(email, messageStamp);
        }


        function OnErrorCall(response) {
            //alert(response.status + " " + response.statusText);
        }

        $("#card").flip('toggle');
        $("#subscribeForm").attr('hidden', 'hidden');


    }
    else {
        alert('Please check your info before submitting.')
    }


}
function getUserMessage(email, messageStamp) {
   // console.log('get message called');
   // console.log(email);
   // messageStamp = '"' + messageStamp + '"';
   // console.log('msgStmp after: ' + messageStamp);
    $.ajax({
        type: 'POST',
        url: 'services.asmx/getMessage',
        data: JSON.stringify({ email: email, MessageStamp: messageStamp }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
           // alert(r);
            //alert('Sucess message');
            //console.log(r);
            var userMessage = { Name: r.d._Name, Email: r.d._Email, Message: r.d._UserMessage };
           // console.log(userMessage);
            fillCard(userMessage);

        },
        error: function (e) {
            console.log(e);
        }
    });
}

function fillCard(userMessage) {
    $("#pLead").text('Thank you! ' + userMessage.Name + '. Your message: ');
    $("#pMessage").text(userMessage.Message);
    $("#pHelper").text('has been received.');
    $("#pTrail").text('To add your email \'' + userMessage.Email + ' \'' + 'to our mailing list, please click on the button below.');

}

function sendEmail() {
    console.log('send email called');
   // $('.back').text('Email sent to ' + globalEmail + '.');
    $('.back').css('font-size', '42px');
    $.ajax({
        type: 'POST',
        url: 'services.asmx/SendEmail',
        data: JSON.stringify({ email: globalEmail, MessageStamp: globalMessageStamp }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (r) {
            // alert(r);
            // console.log(r);
            var userMessage = { Name: r.d.Name, Email: r.d.Email, Message: r.d.userMessage };
            $('.back').text('Email sent to ' + globalEmail + '. Please make sure to check your spam folder.');
            $('.back').css('font-size', '42px');
            // console.log(userMessage);
            fillCard(userMessage);

        },
        error: function (e) {
            alert(e);
            console.log('error');
        }
    });
    
    function limitText(limitField, limitNum) {

        if (limitField.value.length > limitNum) {
            limitField.value = limitField.value.substring(0, limitNum);
        }
    }
}