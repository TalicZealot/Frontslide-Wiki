<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PendingEdits.aspx.cs" Inherits="SotnWiki.WebFormsClient.PendingEdits" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h1>Pending page edits</h1>
        <asp:ListView
            ID="ResultsListView" runat="server"
            ItemType="SotnWiki.Models.PageContentSubmission"
            SelectMethod="ResultsListView_GetData"
            DataKeyNames="Id">

            <LayoutTemplate>
                <div class="row">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
                </div>

                <asp:DataPager runat="server" PageSize="10" QueryStringField="Id">
                    <Fields>
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>

            <ItemTemplate>
                <div class="result">
                    <a href="/editor/publishedit?title=<%# Request.QueryString["title"] %>&id=<%#: Item.Id %>">
                        <h2>Edit with ID: <%#: Item.Id %></h2>
                    </a>
                    <p>
                        <%#: Item.Content.Substring(0, 150) %>
                    </p>
                </div>
            </ItemTemplate>
        </asp:ListView>
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
