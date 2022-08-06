<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userprofile.aspx.cs" Inherits="userprofile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link href="https://fonts.googleapis.com/css?family=Poppins:300,400,500,600,700,800,900" rel="stylesheet">
		
		<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
		<link rel="stylesheet" href="css/style.css">
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrapper d-flex align-items-stretch">
			<nav id="sidebar">
				<div class="p-4 pt-5">
		  		<a href="#" class="img logo rounded-circle mb-5" style="background-image: url(images/logo.jpg);"></a>
	        <ul class="list-unstyled components mb-5">
	          <li class="active">
	            <a href="userprofile.aspx" >Home</a>
	            
	          </li>
	          <li>
	              <a href="tranctionhistory.aspx">Tansction history</a>
	          </li>
	          <li>
              <a href="fundstransfer.aspx">Fund transfer</a>
              </li>
                <li>
              <a href="index.aspx">logout</a>
              </li>
	         
	        </ul>


	      </div>
    	</nav>

        <!-- Page Content  -->
      <div id="content" class="p-4 p-md-5">

        <nav class="navbar navbar-expand-lg navbar-light bg-light">
          <div class="container-fluid">

            <button type="button" id="sidebarCollapse" class="btn btn-primary">
              <i class="fa fa-bars"></i>
              <span class="sr-only">Toggle Menu</span>
            </button>
            <button class="btn btn-dark d-inline-block d-lg-none ml-auto" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <i class="fa fa-bars"></i>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="nav navbar-nav ml-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="userprofile.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="tranctionhistory.aspx">transction history</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="fundstransfer.aspx">transfer amount</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="index.aspx">Logout</a>
                </li>
              </ul>
            </div>
          </div>
        </nav>
        <h2 class="mb-4" >Welcome sir</h2>
          <h2 class="mb-4" >&nbsp;Full Name:
              <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
          </h2>
          <h2 class="mb-4" >Account number:<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
          </h2>
          <h2 class="mb-4" >Account type:
              <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
          </h2>
          <h2 class="mb-4" >Total amout in GBP:
              <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
          </h2>
      </div>
		</div>
    <div>
    
    </div>
    </form>
     <script src="js/jquery.min.js"></script>
    <script src="js/popper.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/main.js"></script>
</body>
</html>
