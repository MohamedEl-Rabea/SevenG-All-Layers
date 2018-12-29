<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="sevenG._7Gsetting.ForgetPassword" %>

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
  <link href="../vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
  <!-- Custom fonts for this template-->
  <link href="../vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
  <!-- Custom styles for this template-->
  <link href="../css/sb-admin.css" rel="stylesheet">
</head>

<body class="bg-dark">
  <div class="container">
    <div class="card card-login mx-auto mt-5">
      <div class="card-header">Forget Pssword</div>
      <div class="card-body">
          <div class="text-center mt-4 mb-5">
          <h4>Forgot your password?</h4>
          <p>Enter your email address and we will send you instructions on how to reset your password.</p>
        </div>
        <form  runat="server">
          <div class="form-group">
            <label for="exampleInputEmail1">Email/Username</label>
            <asp:TextBox class="form-control" id="txtUserName"  aria-describedby="emailHelp" placeholder="البريد الألكتروني/اسم المستخدم" runat="server"></asp:TextBox>
          </div>
           
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-primary btn-block" Text="Reset Password" />
           
        </form>
            <div class="text-center">
          <a class="d-block small mt-3" href="Register.aspx">Register an Account</a>
          <a class="d-block small" href="Login.aspx">Login Page</a>
        </div>
      <div class="margin text-center">
                    <span>
                        <asp:Label  ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="red"></asp:Label></span>
                </div>
      </div>
    </div>
  </div>
  <!-- Bootstrap core JavaScript-->
  <script src="../vendor/jquery/jquery.min.js"></script>
  <script src="../vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <!-- Core plugin JavaScript-->
  <script src="../vendor/jquery-easing/jquery.easing.min.js"></script>
</body>

</html>

