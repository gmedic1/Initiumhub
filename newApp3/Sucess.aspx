<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sucess.aspx.cs" Inherits="newApp3.Sucess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Thank you for registering
    </title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./css/ionicons.min.css" />
    <style type="text/css">
        #userGrid{
            margin-top:10px;
            font-family:'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-size:medium;
            /*opacity:0;*/
           
        }
        .row {
    /* margin-right: -15px; */
             margin-left: 0;
        }
        #progress{
            margin-top:20px;
            width:inherit;
            
        }
        #sucess{
            padding-top:54px;
        }
        #card{
           // padding-top:52px
        }
	.progress-bar-green {
      	    background-color: green !important;
	}
	
    </style>
  
</head>
<body>
    <nav id="topNav" class="navbar navbar-default navbar-fixed-top navbar-inverse">
          <div class="container-fluid">
              <div class="navbar-header">
                  <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-navbar">
                      <span class="sr-only">Toggle navigation</span>
                      <span class="icon-bar"></span>
                      <span class="icon-bar"></span>
                      <span class="icon-bar"></span>
                  </button>
                  <a class="navbar-brand page-scroll" href="index.html#first"><i class="ion-ios-analytics-outline"></i> Initium</a>
              </div>
              <div class="navbar-collapse collapse" id="bs-navbar">
                  <ul class="nav navbar-nav">
                      <li>
                          <a class="page-scroll" href="index.html#one">Intro</a>
                      </li>
                      <li>
                          <a class="page-scroll" href="index.html#two">Highlights</a>
                      </li>
                      <li>
                          <a class="page-scroll" href="index.html#three">Gallery</a>
                      </li>
                      <li>
                          <a class="page-scroll" href="index.html#four">Features</a>
                      </li>
                      <li>
                          <a class="page-scroll" href="index.html#last">Contact</a>
                      </li>
                      
                  </ul>
                  <ul class="nav navbar-nav navbar-right">
                      
                      <li>
                          <form class="navbar-form" role="search">
        <div class="input-group">
            <input type="text" class="form-control" placeholder="Search" name="srch-term" id="srch-term"/>
            <div class="input-group-btn">
                <button class="btn btn-default" type="submit"><i class="glyphicon glyphicon-search"></i></button>
            </div>
        </div>
        </form>
</li>
                      
                     
                  </ul>
              </div>
          </div>
      </nav>
        <div class="container"id="sucess">
            
            <div class="row" >
                <div class="row" id="card">
                    <div class="front">
                        <p class="lead" id="pLead1">
                            Your details are successfully saved to the database.
                        </p> 
            
                        <p id="pTrail1">
                            To view your details click on the button below
                         </p>
                            </br>
                         <button type="button" class="btn btn-sm btn-info" onclick="getDetails()" > Get my Details</button>
                    </div>
                    <div class="back">
                         <p class="lead" id="pLead">
                           
                        </p> 
            
                        <p id="pTrail">
                            
                         </p>
                            </br>
                         <button type="button" class="btn btn-sm btn-info" onclick="getDetails()" > Register</button>
                    </div>
                    
                </div>
            
            </div>
            
            <div class="row" id="progress" hidden="hidden" >
            
            <div class="progress" >
            <div class="progress-bar progress-bar-warning" id="progressbar" role="progressbar" aria-valuenow="90"aria-valuemin="0" aria-valuemax="100" style="width:100%">
                 
            </div>
            </div>
        
            </div>
          

        </div>
    <div class="container" id="userGrid" >
        <div class="row">
            <div class="col-xs-4 grid-item grid-item-label">
                First Name
            </div>
              <div class="col-xs-4 grid-item grid-item-value" id="firstName">
               
            </div>

        </div>
        <div class="row">
            <div class="col-xs-4 grid-item-label grid-item">
                Last Name
            </div>
              <div class="col-xs-4 grid-item grid-item-value" id ="lastName">
                
            </div>

        </div>
        <div class="row">
            <div class="col-xs-4 grid-item-label grid-item">
                Email
            </div>
              <div class="col-xs-4 grid-item grid-item-value" id="Email">
                
            </div>

        </div>
        <div class="row">
            <div class="col-xs-4 grid-item grid-item-label">
                Phone number
            </div>
              <div class="col-xs-4 grid-item grid-item-value" id="Pnumber">
              
            </div>

        </div>
         <div class="row">
            <div class="col-xs-4 grid-item-label grid-item">
               Zipcode
            </div>
              <div class="col-xs-4 grid-item grid-item-value" id="zipcode">
              
            </div>

        </div>
         <div class="row">
            <div class="col-xs-4 grid-item grid-item-label">
                State
            </div>
              <div class="col-xs-4 grid-item grid-item-value" id="state">

            </div>

        </div>
    </div>
   

</body>
      <script src="scripts/jquery-3.3.1.min.js"></script>
    <script src="js/flip.js"></script>
<script src="scripts/bootstrap.min.js"></script>
<script type="text/javascript">
<%--    $(document).ready(function () {
       // $(".grid-item").hide();// hide it initially

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
        var regex = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/;
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
            url: 'Sucess.aspx/UpperWM',

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

</script>--%>
</html>
