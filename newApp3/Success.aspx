<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Success.aspx.cs" Inherits="newApp3.Success" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        Thank you for registering
    </title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="./css/ionicons.min.css" />
    <style type="text/css">
       
	.progress-bar-green {
      	    background-color: green !important;
	}
    #one{
        padding-top:54px;
    }
    #three{
        padding-top:10px;
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
                  <a class="navbar-brand page-scroll" href="index.html#first"><i class="ion-gear-a"></i> Initium</a>
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
    <header id="one" style="height:190px">
        <div class="container"id="sucess">
            
           
                <div id="card">
                    <div class="front">
                        <p class="lead" id="pLead1">
                            Your details are successfully saved to the database.
                        </p> 
            
                        <p id="pTrail1">
                            To view your details click on the button below
                         </p>
                           
                         <button type="button" class="btn btn-sm btn-info" onclick="getDetails()" > Get my details</button>
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
    </header>

    <section id="two"> 
        <div class="container">
             <div class="progress-bar progress-bar-warning" id="progressbar" role="progressbar" aria-valuenow="90"aria-valuemin="0" aria-valuemax="100" >                
            </div>  
        </div>
                  
    </section>
        
    
    <aside id="three">
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
    </aside>
           
          

    
   

</body>
      <script src="scripts/jquery-3.3.1.min.js"></script>
    <script src="js/flip.js"></script>
<script src="scripts/bootstrap.min.js"></script>
<script src="scripts/success.js"></script>

</html>
