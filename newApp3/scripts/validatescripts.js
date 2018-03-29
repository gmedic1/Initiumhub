

var isValidFirstName;
function validateFirstName(firstName) {
    //console.log(firstName);
   // console.log(firstName)
    //console.log('button')
    var regex = new RegExp(/^[A-z]+$/);
    if (regex.test(firstName)) {
        isValidFirstName = true;
        $('#txtFirstName').next().removeClass('ion-alert-circled');
        //console.log('true');
        //debugger;
        return true;
    } else {
        isValidFirstName = false;
        $('#txtFirstName').next().addClass('ion-alert-circled');
       // console.log('false')
        return false;
    }
}
function onlyAlphabets(e, t) {
    try {
        if (window.event) {
            var charCode = window.event.keyCode;
        }
        else if (e) {
            var charCode = e.which;
        }
        else { return true; }
        if ((charCode > 64 && charCode < 91) || (charCode > 96 && charCode < 123)) {
            $('#txtFirstName').next().removeClass('ion-alert-circled');
            isValidFirstName = true;
            return true;
        }

        else {


            $('#txtFirstName').next().addClass('ion-alert-circled');
            isValidFirstName = false;
            return false;
        }

    }

    catch (err) {
        alert(err.Description);


    }

}
var isValidLastName;
function validateLastName(e, t) {
    //alert(t);
    //console.log(t.value);
    // console.log(e.key);
    var regex = new RegExp(/^[a-z\-\'\s]+$/i);
    //var k = $(txtLastName).val();
   // console.log(k);
   // console.log('last name button');
    //console.log(e.type)
    if (e.type === 'btn') {
        //console.log('btn verified');
        //console.log(regex.test(t));
        return regex.test(t);
    }
    if (regex.test(e.key)) {
        $('#txtLastName').next().removeClass('ion-alert-circled');
        isValidLastName = true;
        return true;
    }
    else {

        $('#txtLastName').next().addClass('ion-alert-circled');
        isValidLastName = false;
        return false;
    }


}
var isValidEmail;
function validateEmail(email) {
    var regex = /^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$/;
    var email = email;
    //console.log(email);
    //console.log(email);
    if (email.match(regex)) {
        $('#txtEmail').next().removeClass('ion-alert-circled');
       // console.log('true')
        isValidEmail = true;
        return true;
    }
    else {
        $('#txtEmail').next().addClass('ion-alert-circled');
        isValidEmail = false;
        return false;
    }
}
var isValidPhoneNumber;
function validatePhoneNumber(phoneNumber) {
    var regex = /^\d{10}$/;
    if (regex.test(phoneNumber)) {
        //console.log(true);
        isValidPhoneNumber = true;
        $('#txtPhoneNumber').next().removeClass('ion-alert-circled');
        return true;
    }
    else {
        isValidPhoneNumber = false;
        $('#txtPhoneNumber').next().addClass('ion-alert-circled');
        return false;

    }
}
var isValidZipcode;
function validateZipcode(e) {
    var regex = /^\d{5}$/;
    //console.log(e);
    if (regex.test(e)) {
        isValidZipcode = true;
      //  console.log('true');
        $('#txtZipcode').next().removeClass('ion-alert-circled');
        return true;
    }
    else {
        isValidZipcode = false;

        $('#txtZipcode').next().addClass('ion-alert-circled');
        return false;

    }
}

function btnClicked() {
    //alert('button clicked');
    var firstName = $(txtFirstName).val();
   // console.log(firstName);
    var lastName = $(txtLastName).val();
    var lastNameObj = new Object();
    lastNameObj.value = lastName;
    lastNameObj.type = 'btn';
   // console.log(lastName);
    var email = $(txtEmail).val();
   // console.log(email);
    var zipCode = $(txtZipcode).val();
    //console.log(zipCode);
    var phoneNumber = $(txtPhoneNumber).val();
   // console.log(phoneNumber);
    var state = $(ddlState).val();
   // console.log(state);
    //var lastName = document.getElementById('<%= txtLastName.ClientID %>').value;
    //var email = document.getElementById('<%= txtEmail.ClientID %>').value;
    //var zipCode = document.getElementById('<%= txtZipcode.ClientID %>').value;
    //var phoneNumber = document.getElementById('<%= txtPhoneNumber.ClientID %>').value;
    //var state = document.getElementById('<%= ddlState.ClientID %>').value;
    // alert(firstName);
    
    if (firstName === "" || lastName === "" || email === "" || zipCode === "" || phoneNumber === "" || state === "0") {
        
        alert('Check all the fields before submiting the form');
        //$('#btnSubmit').attr('disabled', 'disabled');
        return false;
        //always here;
    }

    else if (validateFirstName(firstName) && validateLastName(lastNameObj, lastName) && validateEmail(email) && validatePhoneNumber(phoneNumber) && validateZipcode(zipCode) && state !=='0') {
        //console.log('fn:' + isValidFirstName);

       // console.log('Checks passed')
        return true;

    }
    else    {
        alert('Check all the fields before submitting');
        return false;

    }



}