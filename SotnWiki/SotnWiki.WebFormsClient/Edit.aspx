<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SotnWiki.WebFormsClient.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1><%# Model.Title %></h1>
    <p>
        Please adhere to the <a href="/page?title=sotnwiki-page-conventions">SotnWiki page conventions</a>.
    </p>
    <p>This site uses textile markup, for documentation visit <a href="https://txstyle.org/">txstyle.org</a>.</p>
    <asp:TextBox ID="editPageText" ClientIDMode="Static" TextMode="MultiLine" Columns="40" Rows="40" runat="server" Text="<%# Model.Content %>" />
    <asp:Button ID="submitPage" Text="Submit" runat="server" OnClick="submitPage_Click" />
</asp:Content>
