<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="sevenG._7Gsetting.ResetPassword" %>

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
      <div class="card-header">Reset Password</div>
      <div class="card-body">
        <form  runat="server">
          <div class="form-group">
            <label for="exampleInputEmail1">New Password</label>
            <asp:TextBox class="form-control" id="txtPassword" type="Password" aria-describedby="emailHelp" placeholder="كلمة السر الجديدة" runat="server"></asp:TextBox>
          </div>
          <div class="form-group">
            <label for="exampleInputPassword1">Confirm New Password</label>
            <asp:TextBox class="form-control" id="txtConfirmPassword" TextMode="Password" placeholder="تأكيد كلمة السر " runat="server"></asp:TextBox>
          </div>
      
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" class="btn btn-primary btn-block" Text="Save" />
            <asp:LinkButton ID="linkBack" class="d-block small" runat="server" OnClick="linkBack_Click">Back</asp:LinkButton>
             <%--<a runat="server" id="linkBack" class="d-block small" href="../login.aspx">Back</a>--%>
        </form>
      
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
