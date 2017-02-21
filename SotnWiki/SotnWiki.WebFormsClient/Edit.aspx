<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="SotnWiki.WebFormsClient.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1><%# Model.Title %></h1>
        <p>
            Please adhere to the <a href="/page?title=sotnwiki-page-conventions">SotnWiki page conventions</a>.
        </p>
        <p>This site uses textile markup, for documentation visit <a href="https://txstyle.org/">txstyle.org</a>.</p>
        <asp:TextBox ID="editPageText" ClientIDMode="Static" TextMode="MultiLine" Columns="40" Rows="40" runat="server" Text="<%# Model.Content %>" />
        <asp:Button ID="submitPage" Text="Submit" runat="server" OnClick="submitPage_Click" />
    </div>
    <asp:LoginView runat="server" ViewStateMode="Disabled">
        <LoggedInTemplate>
            <div class="editor-panel">
                <ul>
                    <li><a href="/newpage">New Page</a></li>
                </ul>
            </div>
        </LoggedInTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Admin, Editor">
                <ContentTemplate>
                    <div class="editor-panel">
                        <ul>
                            <li><a href="/newpage">New Page</a></li>
                            <li><a href="/editor/submissions">Manage Submissions</a></li>
                        </ul>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
