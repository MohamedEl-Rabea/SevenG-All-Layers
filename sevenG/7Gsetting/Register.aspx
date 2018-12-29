<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="sevenG._7Gsetting.Register" %>

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
    <div class="card card-register mx-auto mt-5">
      <div class="card-header">Register an Account</div>
      <div class="card-body">
        <form runat="server">
          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputName">First name</label>
                 <asp:TextBox class="form-control" id="txtFirstName" type="text" aria-describedby="fnameHelp" placeholder="الأسم الأول" runat="server"></asp:TextBox>
          </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Last name</label>
                <asp:TextBox class="form-control" id="txtLastName" type="text" aria-describedby="emailHelp" placeholder="أسم العائلة" runat="server"></asp:TextBox>
              </div>
            </div>
          </div>

          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                 <label for="exampleInputEmail1">Email address</label>
                <asp:TextBox class="form-control" id="txtEmail" type="text" aria-describedby="emailHelp" placeholder="البريد الألكتروني" runat="server"></asp:TextBox>
          </div>
              <div class="col-md-6">
                <label for="exampleInputLastName">Mobile number</label>
                <asp:TextBox class="form-control" id="TxtMobile" type="text" aria-describedby="emailHelp" placeholder="رقم الجوال" runat="server"></asp:TextBox>
              </div>
            </div>
          </div>

          <div class="form-group">
            <div class="form-row">
              <div class="col-md-6">
                <label for="exampleInputPassword1">User Name</label>
                 <asp:TextBox class="form-control" id="txtUserName" type="text" aria-describedby="userNameHelp" placeholder="اسم المستخدم" runat="server"></asp:TextBox>
                </div>
              <div class="col-md-6">
                <label for="exampleConfirmPassword">password</label>
                  <asp:TextBox class="form-control" id="txtPassword" type="password" aria-describedby="userPassHelp" placeholder="كلمة السر" runat="server"></asp:TextBox>
              </div>
            </div>
          </div>
          <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" class="btn btn-primary btn-block" Text="Register" />
                 <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
             <%--<asp:Button ID="BtnAddress" runat="server" OnClick="BtnAddress_Click"  CssClass="btn btn-primary btn-block" Text="Set your address" />--%>
               
        </form>
        <div class="text-center">
          <a class="d-block small mt-3" href="../login.aspx">Login</a>
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

