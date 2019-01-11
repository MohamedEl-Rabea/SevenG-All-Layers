<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/SEVENG.Master" AutoEventWireup="true" CodeBehind="load-attachments.aspx.cs" Inherits="sevenG.Design.load_attachments" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header card-header-info">
                    <h4 class="card-title"><strong>Designs</strong></h4>
                    <p class="card-category">Attach your design</p>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="bmd-label-floating">
                                    Attachments
                                </label>
                                <ajaxToolkit:AjaxFileUpload
                                    ID="AttachmentFileUpload1"
                                    align="center"
                                    runat="server"
                                    AllowedFileTypes="jpeg,jpg,zip,png,gif,pdf"
                                    MaximumNumberOfFiles="5"
                                    OnUploadComplete="AttachmentFileUpload1_UploadComplete" />
                            </div>
                        </div>
                    </div>
                    <div class="row" runat="server" id="divErrMsg" visible="false">
                        <div class="col-md-12">
                            <div class="alert alert-danger text-center">
                                <span>
                                    <b>Error - </b>
                                    <asp:Label
                                        ID="LBLError"
                                        runat="server"
                                        class="margin text-center"
                                        Text="Here will be the error details">
                                    </asp:Label>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:Button
                                ID="save"
                                class="btn btn-primary"
                                runat="server"
                                Text="Go to Cart"
                                OnClick="save_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
