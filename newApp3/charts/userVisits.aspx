<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userVisits.aspx.cs" Inherits="newApp3.charts.userVisits" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/bootstrap.min.css" />
    <link rel="stylesheet" href="../css/animate.min.css" />
    <link rel="stylesheet" href="../css/ionicons.min.css" />
    <link href="../css/font-mfizz.css" rel="stylesheet" />

    <%--<link rel="stylesheet" href="../css/styles.css" />--%>
    <style type="text/css">
        #Chart1{
            padding-top:94px;
        }
    </style>
</head>
<body>
    <nav id="topNav" class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-navbar">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>

                <a class="navbar-brand page-scroll" href="../#first"><i class="ion-gear-b" src="favicon.ico"></i> Initium</a>
            </div>
            <div class="navbar-collapse collapse" id="bs-navbar">
                <ul class="nav navbar-nav">
                    <li>
                        <a class="page-scroll" href="#Chart1">User Location</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="#Chart2">Weather</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="../#three">Gallery</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="../#four">Features</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="../#last">Contact</a>
                    </li>
                    <li>
                        <a class="page-scroll" data-toggle="modal" title="About initium hub" href="#aboutModal">About</a>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">

                    <li>
                        <form class="navbar-form" role="search">
                            <div class="input-group">
                                <input type="text" class="form-control" placeholder="Search" name="srch-term" id="srch-term">
                                <div class="input-group-btn">
                                    <button class="btn btn-default" type="submit"><i class="glyphicon glyphicon-search"></i></button>
                                </div>
                            </div>
                        </form>
                    </li>
                    <li>
                        <p class="navbar-btn">
                            <a href="Register.aspx" class="btn btn-default">Contact Us</a>
                        </p>
                    </li>

                </ul>
            </div>
        </div>
    </nav>
    <form runat="server">
        <div id="Chart1" class="container">
        <select id="chartType">
            <option value="bar">Bar</option>
           <option value="line">Line</option>
    <option value="radar">Radar</option>
   
    <option value="polarArea">Polar Area</option>
            <option value="doughnut">Doughnut</option>
              <option value="bubble">Bubble</option>
    <option value="polarArea">Polar Area</option>
            <option value="pie">Pie</option>
            doughnut
    
        </select>
        <canvas id="myChart"></canvas>

    </div>
         <div id="Chart2" class="container">
          <asp:DropDownList ID="ddlWeather" runat="server" ></asp:DropDownList>
         
             <canvas id="myChart2"></canvas>

    </div>

    </form>
    
     
        <script src="../js/jquery.min.js"></script>
   <script src="../js/moment.js"></script>
    <script src="../js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>
    <script type="text/javascript">
      //  var ctx2 = document.getElementById('ddlWeather');
        var colA = Array();
       // console.log('ddl');
       // console.log(ctx2);
        var ctx = document.getElementById('myChart').getContext('2d');
        var labels = Array();
        var Data = Array();
        var colArr1 = Array();
        $.ajax({
            type: 'POST',
            url: 'userVisits.aspx/GetUserVisitsByCity',
            data: "{city: '" + 'test' + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (r) {
          
                //console.log(' obj');
                //console.log(r);
                var m = r.d;
               // console.log(m);
                //Data = (r.d);
               // console.log('After Parse');
                //var k = JSON.parse(m);
                //console.log(k);
                //var keys = Array();
                for (var key in m) {
                    labels.push(key);
                    Data.push(m[key]);
                };
                console.log(labels);
                // console.log(Data);
                console.log('calledr');
                colArr1 = getRandomColor(labels);
                console.log('');


               

            },
            error: function (e) {
                //alert(e);
                console.log(e);
            }






        });


        var chart = new Chart(ctx, {
            // The type of chart we want to create
            type: 'bar',

            // The data for our dataset
            data: {
                labels: labels,
                datasets: [{
                    label: 'No of visitors',
                    backgroundColor: colArr1,
                    borderColor: '#ff6384',
                    data: Data,
                }]
            },

            // Configuration options go here
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                },
                tooltips: {
                    mode: 'nearest'
                }




            }
        });
        setTimeout(function () {
            chart.update();
            //chart2.update();
          //  console.log('chart updated called from time out');
        }, 1000);



        var currentChart;

        function updateChart() {


            setTimeout(function () {
                if (chart) {
                    //console.log('chart present');

                    //chart.destroy();
                }

                var determineChart = $("#chartType").val();
               

                var c1 = '\'#ff6384\',' + '\'#36a2eb\'';
                console.log('col');
                console.log(colArr);
                var chart = new Chart(ctx, {
                    // The type of chart we want to create
                    type: determineChart,

                    // The data for our dataset
                    data: {
                        labels: labels,
                        datasets: [{
                            label: 'No of visitors',
                            backgroundColor: colArr1,
                            borderColor: '#ff6384',
                            data: Data,
                        }]
                    },

                    // Configuration options go here
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        },
                        tooltips: {
                            mode: 'nearest'
                        }




                    }
                });
            }, 2000);


            

           // var params = dataMap[determineChart]
           // currentChart = new Chart(ctx)[params.method](params.data, {});
        }

        $('#chartType').on('change', updateChart)
        // updateChart();
        $('#ddlWeather').on('change', resetCanvas);

        for (var i = 0; i < colArr1.length / 2; i++) {
            colA.push(colArr1[i]);
        }

        console.log('ColArr2');
        console.log(colA);
        function createWeatherChart() {
            console.log('w chart');
            var city = $('#ddlWeather').val();
            var cityChart = document.getElementById('myChart2');
            console.log(city);
            var maxTemp = Array();
            var minTemp = Array();
            var currentTemp = Array();
            var currentDate = Array();
            var colArr = Array();
            var result;
            $.ajax({
                type: 'POST',
                url: 'userVisits.aspx/GetWeatherByCity',
                data: "{city: '" + city + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {

                   // console.log(' obj');
                   // console.log(r);
                   

                   // console.log(r.d.length);
                   // console.log('r.d lenght');
                   // console.log(r.d[0]);
                  
                    for (var i = 0; i < r.d.length;i++) {
                        maxTemp.push(r.d[i].MaxTemp);
                        minTemp.push(r.d[i].MinTemp);
                        currentTemp.push(r.d[i].CurrentTemp);
                        currentDate.push(moment(r.d[i].CreatedDate).format('YYYY/MM/D hh:mm:ss SSS'));
                        //console.log(id);
                       // console.log('Next');
                        //Data.push(m[key]);
                    };
                    //console.log('maxTemp');
                    //console.log(maxTemp);
                    //console.log('c Date');
                    //console.log(currentDate);
                    //console.log('min temp');
                    //console.log(minTemp);
                    //console.log('c temp');
                    //console.log(currentTemp);
                    colArr = getRandomColor(maxTemp);

                  

                    console.log('color');
                    console.log(colArr);

                    drawWeatherChart(colArr, maxTemp, minTemp);



                },
                error: function (e) {
                    
                    console.log(e);
                }






            });

            function drawWeatherChart(colArr, maxTemp,minTemp) {


              

                var chart2 = new Chart(cityChart, {
                    // The type of chart we want to create
                    type: 'line',



                    // The data for our dataset
                    data: {
                        labels: currentDate,
                        datasets: [

                        {
                            label: 'Max Temp',
                            backgroundColor: colArr[0],
                            borderColor: colArr [0],
                            data: maxTemp,
                            fill:false,
                        },
                        {

                            label: 'Min Temp',
                            backgroundColor: colArr[1],
                            borderColor: colArr[2],
                            data: minTemp,
                            fill:false,




                        }

                            




                        ]
                    },

                    // Configuration options go here
                    options: {
                        scales: {
                            yAxes: [{
                                ticks: {
                                    beginAtZero: true
                                }
                            }]
                        },
                        tooltips: {
                            mode: 'nearest'
                        }




                    }


                });


            }

          

            //setTimeout(function () {

            //    //chart2.update();

            //}, 2500);

        }

        // var colArr = Array();
        
        function getRandomColor(fields) {
            console.log('arr length');
            console.log(fields.length);
            var colorArray = Array();
            for (var j = 0; j < fields.length; j++){
                var letters = '0123456789ABCDEF';
                var color = '#';
                for (var i = 0; i < 6; i++) {
                    color += letters[Math.floor(Math.random() * 16)];
                }
                colorArray.push(color);
               // console.log(fields);
              
            }
            return colorArray;

           //// console.log('color arr');
           // console.log(colorArray);
           
        }

        function resetCanvas(chartParentDiv, chartDiv) {
            var div = document.getElementById(chartDiv).remove();
            $('#Chart2').append('<canvas id="myChart2"><canvas>');
            //canvas = document.querySelector('#results-graph');
            //ctx = canvas.getContext('2d');
            //ctx.canvas.width = $('#graph').width(); // resize to parent width
            //ctx.canvas.height = $('#graph').height(); // resize to parent height
            //var x = canvas.width / 2;
            //var y = canvas.height / 2;
            //ctx.font = '10pt Verdana';
            //ctx.textAlign = 'center';
            //ctx.fillText('This text is centered on the canvas', x, y);
            createWeatherChart();




        }

        $(document).ready(function () {
            $("ddlWeather").val('3');
            console.log('ready');
            createWeatherChart();

        });

    </script>
    
</body>

    
</html>
