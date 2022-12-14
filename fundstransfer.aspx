<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fundstransfer.aspx.cs" Inherits="fundstransfer" %>

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
    <style>


body {
  font-family: 'Nunito', sans-serif;
  color: #384047;
}



h1 {
  margin: 0 0 30px 0;
  text-align: center;
}

input[type="text"],
input[type="password"],
input[type="date"],
input[type="datetime"],
input[type="email"],
input[type="number"],
input[type="search"],
input[type="tel"],
input[type="time"],
input[type="url"],
textarea,
select {
  background: rgba(255,255,255,0.1);
  border: none;
  font-size: 16px;
  height: auto;
  margin: 0;
  outline: 0;
  padding: 15px;
  width: 100%;
  background-color: #e8eeef;
  color: #8a97a0;
  box-shadow: 0 1px 0 rgba(0,0,0,0.03) inset;
  margin-bottom: 30px;
}

input[type="radio"],
input[type="checkbox"] {
  margin: 0 4px 8px 0;
}

select {
  padding: 6px;
  height: 32px;
  border-radius: 2px;
}


fieldset {
  margin-bottom: 30px;
  border: none;
}

legend {
  font-size: 1.4em;
  margin-bottom: 10px;
}

label {
  display: block;
  margin-bottom: 8px;
}

label.light {
  font-weight: 300;
  display: inline;
}

.number {
  background-color: #5fcf80;
  color: #fff;
  height: 30px;
  width: 30px;
  display: inline-block;
  font-size: 0.8em;
  margin-right: 4px;
  line-height: 30px;
  text-align: center;
  text-shadow: 0 1px 0 rgba(255,255,255,0.2);
  border-radius: 100%;
}


    </style>
<body>
   <form id="form1" runat="server">
    <div class="wrapper d-flex align-items-stretch">
			<nav id="sidebar">
				<div class="p-4 pt-5">
		  		<a href="#" class="img logo rounded-circle mb-5" style="background-image: url(images/logo.jpg);"></a>
	        <ul class="list-unstyled components mb-5">
	          <li >
	            <a href="userprofile.aspx" >Home</a>
	            
	          </li>
	          <li>
	              <a href="tranctionhistory.aspx">Tansction history</a>
	          </li>
	          <li class="active">
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
                <li class="nav-item ">
                    <a class="nav-link" href="userprofile.aspx">Home</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="tranctionhistory.aspx">transction history</a>
                </li>
                <li class="nav-item active">
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
         
      
        <h1>Transfer money to other accounts</h1>
        
        <fieldset>
            <label for="name">
            <br />
            Enter the account number:</label>
          <input type="num" id="accnum" name="accnum">
          
          <label for="mail">Amount:</label>
          <input type="number" id="num" name="Amount">
                  
          <label>currency:</label>
          <input type="radio" id="under_13" value="GBP" name="user_age"><label for="under_13" class="light">GBP</label><br>
          <input type="radio" id="over_13" value="USdollar" name="user_age"><label for="over_13" class="light">US $</label><br>
            <input type="radio" id="over_13" value="EURO" name="user_age"><label for="over_13" class="light">EURO</label>
        </fieldset>
        
        <asp:Button ID="submit" runat="server" class="login100-form-btn" style="background-color:#583862;" Text="Transfer" OnClick="submit_Click"  />
     
        <asp:Button ID="submit0" runat="server" class="login100-form-btn" style="background-color:#583862;" Text="Transfer" OnClick="submit0_Click"  />
     
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
