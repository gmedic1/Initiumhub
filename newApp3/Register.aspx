<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="newApp3.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome to Initium Hub-Registration</title>

    <link href="css/bootstrap.min.css" rel="stylesheet" />
     <link rel="stylesheet" href="./css/animate.min.css" />
    <link rel="stylesheet" href="./css/ionicons.min.css" />
   
       <style>
           #one{
               padding-top:70px;
              
               
           }
           #success_message{ display: none;}
           #btnSubmit{
               width:80px;
               height:35px;
               background:seagreen;
               font-size:medium;
               margin-top:4px;
               margin-left:15px;
               border-radius:10px;

           }
           #ddlState{
               margin-left:6px;
           }
           .form-group{
               margin-bottom:0px;
           }
           .ion-alert-circled{
               color:goldenrod;
           }

       </style>
     
</head>
<body>
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
                  <a class="navbar-brand page-scroll" href="index.html#first"><i class="ion-gear-b"></i> Initium</a>
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

      <section id ="one">
          <div class="container">
              <form runat="server" id="userForm">
              <div class="row ">
                   <div class="form-group col-sm-6">
                    <label for="txtFirstName">First Name</label>
                       
                    <input type="text" runat="server" class="form-control" maxlength="50" id="txtFirstName" aria-describedby="fnHelp" onkeypress="return onlyAlphabets(event,this);" placeholder="Enter first name">
                 
                       <small id="fnHelp" class="form-text text-muted">First name can only contain characters.</small>
                   </div>
                   <div class="form-group col-sm-6">
                    <label for="txtLastName">Last Name</label>
                    <input type="text" runat="server" class="form-control" maxlength="50" onkeypress="return validateLastName(event,this)" id="txtLastName" aria-describedby="lnHelp" placeholder="Enter last name">
                    <small id="lnHelp" class="form-text text-muted">Last name can only contain characters or - or '.</small>
                   </div>
                  <div class="form-group col-xs-12">
                    <label for="txtEmail">Email</label>
                    <input type="email" runat="server" class="form-control" maxlength="255" onkeyup="validateEmail(this.value)" id="txtEmail" aria-describedby="emailHelp" placeholder="john@doe.com">
                    <small id="emailHelp" class="form-text text-muted">Enter a valid email</small>
                   </div>
                  <div class="form-group col-sm-6">
                    <label for="txtPhoneNumber">Phone number</label>
                    <input type="text" class="form-control" runat="server" maxlength="10" onkeyup="validatePhoneNumber(this.value)" id="txtPhoneNumber" aria-describedby="pnHelp" placeholder="9999999999">
                    <small id="pnHelp" class="form-text text-muted">Enter a phone number '1234567890'</small>
                   </div>
                   <div class="form-group col-sm-6">
                    <label for="txtZipcode">Zipcode number</label>
                    <input type="text" class="form-control" id="txtZipcode" onkeyup="validateZipcode(this.value)" maxlength="5" runat="server" aria-describedby="zcHelp" placeholder="56982">
                    <small id="pnHelp" class="form-text text-muted">Enter a valid zip code</small>
                   </div>
                  <div class="form-group col-sm-12">
                    <label for="ddlState">Select state</label>
                   <asp:DropDownList id="ddlState" class="form-text text-muted" runat="server">

                   </asp:DropDownList>
                    
                   </div>
                   
                  <asp:Button ID="btnSubmit" runat="server" class="btn input-group-btn btn-success col-sm-12" text="Submit" OnClick="btnSubmit_Click" OnClientClick="return btnClicked();" />
                   

              </div>
                  
          </form>

          </div>
          
      </section>
   

</body>
    <script>

    </script>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
     
    <script src="scripts/validatescripts.js"></script>
    <%--<script src="scripts/validate.min.js"></script>--%>
    
</html>
