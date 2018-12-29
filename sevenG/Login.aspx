<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sevenG.Login" %>

<!DOCTYPE html>

<html lang="en">

<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <meta name="description" content="">
  <meta name="author" content="">
  <title>7G System</title>
  <!-- Bootstrap core CSS-->
  <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Custom styles for this template-->
  <link href="css/sb-admin.css" rel="stylesheet">
</head>

<body class="bg-dark">
  <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Login</div>
      <div class="card-body">
        <form  runat="server">
          <div class="form-group">
            <label for="exampleInputEmail1">Email address</label>
            <asp:TextBox class="form-control" id="txtEmail"  aria-describedby="emailHelp" placeholder="البريد الالكتروني" runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="exampleInputPassword1">Password</label>
            <asp:TextBox class="form-control" id="txtPassword" TextMode="Password" placeholder="كلمة السر" runat="server"></asp:TextBox>
          </div>
       <%--   <div class="form-group">
            <div class="form-check">
              <label class="form-check-label">
                <asp:CheckBox class="form-check-input" type="checkbox" runat="server">    </asp:CheckBox> Remember Password</label>
             
            </div>
          </div>--%>
            <asp:Button ID="btnlogin" runat="server" OnClick="btnlogin_Click" class="btn btn-primary btn-block" Text="Login" />
        </form>
      <div class="text-center">
          <a class="d-block small mt-3" href="7Gsetting/Register.aspx">Register an Account</a>
         <a class="d-block small" href="7Gsetting/ForgetPassword.aspx">Forgot Password?</a>
        </div>
               <div class="margin text-center">
                    <span>
                        <asp:Label  ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="red"></asp:Label></span>
                </div>
      </div>
    </div>
  </div>
  <!-- Bootstrap core JavaScript-->
  <script src="vendor/jquery/jquery.min.js"></script>
  <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Core plugin JavaScript-->
  <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
</body>

</html>