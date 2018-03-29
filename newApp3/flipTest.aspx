<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="flipTest.aspx.cs" Inherits="newApp3.flipTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery.min.js"></script>
    <script src="js/flip.js"></script>

</head>
<body>
   <div id="card"> 
  <div class="front"> 
    Front content
  </div> 
  <div class="back">
    Back content
  </div> 
</div>
    <button id="btn" onclick ="flip()"> Flip</button>
    <script type="text/javascript">
        $("#card").flip({
            trigger: "manual"
        });

        function flip() {
            console.log('flipcallled')
            $("#card").flip(true);
        }
    </script>
</body>
    
</html>
