<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="sevenG._7Gsetting.Customers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form class="form-horizontal" runat="server">
      <div class="container-fluid">
        <!-- Breadcrumbs-->
        <ol class="breadcrumb">
            <li class="breadcrumb-item">
                <a href="../views/HomePage.aspx">Home Page</a>
            </li>
            <li class="breadcrumb-item active">Products Setting</li>
        </ol>
        
       <div class="card mb-3">
        <div class="card-header">
          <i class="fa fa-table"></i> Customers
           
        </div>
        <div class="card-body">
        
            <div class="form-group" background-color: #CEECF5;>
                <div class="form-row">


                    <div class="col-md-6">
                        <label for="paperNametxt">Customer name</label>
                        <asp:TextBox ID="txtCustomerName" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="Customer name"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtCustomerName"></asp:RequiredFieldValidator>
               
                    </div>
                      <div class="col-md-6">
                        <label for="paperNametxt">اسم العميل</label>
                        <asp:TextBox ID="txtCustAR" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="اسم العميل"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtCustAR"></asp:RequiredFieldValidator>
               
                    </div>
                   
                      <div class="col-md-6">
                        <label for="paperNametxt">Customer job name</label>
                        <asp:TextBox ID="txtJobName" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="المسمى الوظيفي "></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtJobName"></asp:RequiredFieldValidator>
               
                    </div>
                    
                     <div class="col-md-6">
                        <label for="paperNametxt">Company name</label>
                        <asp:TextBox ID="Txtcomp" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="اسم الشركة"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="Txtcomp"></asp:RequiredFieldValidator>
               
                    </div>
                    <div class="col-md-6">
                        <label for="paperNametxt">Company Role</label>
                        <asp:TextBox ID="txtCompRole" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="nameHelp" placeholder="نوع الشركة"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtCompRole"></asp:RequiredFieldValidator>
               
                    </div>

                   
                    <div class="col-md-6">
                        <label for="paperTypetxt">Address 1</label>
                        <asp:TextBox ID="txtCustomerAdd" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="typeHelp" placeholder="عنوان العميل"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtCustomerAdd"></asp:RequiredFieldValidator>
                   
                    </div>
                     <div class="col-md-6">
                        <label for="paperTypetxt">Address 2</label>
                        <asp:TextBox ID="txtAddress2" runat="server" AutoCompleteType="Disabled" Class="form-control" aria-describedby="typeHelp" placeholder="عنوان العميل"></asp:TextBox>
                    
                    </div>
                       <div class="col-md-6">
                <label for="descriptiontxt">E-mail</label>
                <asp:TextBox ID="txtCustomerMail" runat="server" TextMode="Email" AutoCompleteType="Disabled" Class="form-control" aria-describedby="descriptionHelp" placeholder="البريد الألكتروني"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtCustomerMail"></asp:RequiredFieldValidator>
                       
                 </div>
             <div class="col-md-6">
                        <label for="noPaper">Phone number</label>
                        <asp:TextBox ID="txtCustomerPhone" runat="server" TextMode="Phone" AutoCompleteType="Disabled" Class="form-control" aria-describedby="Number of papers" placeholder="رقم الهاتف"></asp:TextBox>
                
                    </div>  
                    <div class="col-md-6">
                        <label for="noPaper">Mobile number</label>
                        <asp:TextBox ID="txtCustomerMobile" runat="server" TextMode="Phone" AutoCompleteType="Disabled" Class="form-control" aria-describedby="Price of paper" placeholder="رقم الجوال"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" SetFocusOnError="True" ErrorMessage="This field is required" ControlToValidate="txtCustomerMobile"></asp:RequiredFieldValidator>
               
                    </div>    
            
           
                      
                </div>
            </div>



            <div class="col-md-40 text-center"> 
                <asp:Button ID="save" class="btn btn-primary" runat="server" Text="Save" OnClick="save_Click" />
             </div>
           
</div>
        
      
       </div>
    
          <div class="form-group text-center">
                                <span>
                                    <asp:Label ID="LBLError" runat="server" Visible="False"  class="margin text-center" ForeColor="#009933"></asp:Label></span>
                            </div>
         
        </div>
             
      

   </form>
</asp:Content>
