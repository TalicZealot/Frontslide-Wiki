<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SotnWiki.WebFormsClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <%# Model.PageHtml %>
    </div>
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
           <div class="editor-panel">
                        <ul>
                            <li><a href="/newpage">New Page</a></li>
                            <li><a href="/edit?title=main-page">Edit Page</a></li>
                        </ul>
                    </div>
        </LoggedInTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Admin, Editor">
                <ContentTemplate>
                    <div class="editor-panel">
                        <ul>
                            <li><a href="/newpage">New Page</a></li>
                            <li><a href="/edit?title=main-page">Edit Page</a></li>
                            <li><a href="/editor/pendingedits?title=main-page">Manage Edits</a></li>
                            <li><a href="/editor/submissions">Manage Submissions</a></li>
                        </ul>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
