<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Page.aspx.cs" Inherits="SotnWiki.WebFormsClient.Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
    <%# Model.PageHtml %>
    </div>
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            <div class="editor-panel">
                <ul>
                    <li><a href="/newpage">New Page</a></li>
                    <li><a href="/edit?title=<%# Request.QueryString["title"] %>">Edit Page</a></li>
                    <li><a href="/edit?title=<%# Request.QueryString["title"] %>">Manage Edits</a></li>
                    <li><a href="/edit?title=<%# Request.QueryString["title"] %>">Manage Submissions</a></li>
                </ul>
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
