<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterExternalLogin.aspx.cs" MasterPageFile="~/Site.Master" Inherits="SotnWiki.WebFormsClient.Account.RegisterExternalLogin" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<h3>Register with your <%: ProviderName %> account</h3>
    <asp:PlaceHolder runat="server">
        <div class="form-horizontal">
            <p class="text-info">
                You've successfully authenticated with <strong><%: ProviderName %></strong>. You can now log in.
            </p>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Log in" CssClass="btn btn-default" OnClick="LogIn_Click" />
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
