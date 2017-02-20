<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="SotnWiki.WebFormsClient.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Search results for "<%# Request.QueryString["q"] %>"</h1>

    <asp:ListView
        ID="ResultsListView" runat="server"
        ItemType="SotnWiki.Models.Page"
        SelectMethod="ResultsListView_GetData"
        DataKeyNames="Id">

        <LayoutTemplate>
            <div class="row">
                <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            </div>

            <asp:DataPager runat="server" PageSize="5" QueryStringField="Id">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>

        <ItemTemplate>
            <div class="result">
                <a href="/page?title=<%#: Item.Title.ToLower().Replace(' ', '-') %>"><h2><%#: Item.Title %></h2></a>
                <p>
                    <%#: Item.Content %>
                </p>
            </div>
        </ItemTemplate>

    </asp:ListView>

</asp:Content>
