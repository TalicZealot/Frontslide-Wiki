<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewPage.aspx.cs" Inherits="SotnWiki.WebFormsClient.NewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>New page</h1>
    <p>
        Please adhere to the <a href="/page?title=sotnwiki-page-conventions">SotnWiki page conventions</a>.
        <div>
            Select character or main site: 
        <asp:DropDownList ID="DropDownCharacter" runat="server" Width="200px">
            <asp:ListItem Text="Site"></asp:ListItem>
            <asp:ListItem Text="Alucard"></asp:ListItem>
            <asp:ListItem Text="Richter"></asp:ListItem>
            <asp:ListItem Text="Maria"></asp:ListItem>
        </asp:DropDownList>
        </div>
        <div>
            Select page type: 
        <asp:DropDownList ID="DropDownType" runat="server" Width="200px" OnSelectedIndexChanged="Unnamed_SelectedIndexChanged">
            <asp:ListItem Text="General"></asp:ListItem>
            <asp:ListItem Text="Category"></asp:ListItem>
            <asp:ListItem Text="Glitch"></asp:ListItem>
        </asp:DropDownList>
        </div>
        <div>
            Title: 
            <asp:TextBox runat="server" ID="TextBoxPageTitle" type="text"></asp:TextBox>
        </div>
    </p>
    <p>This site uses textile markup, for documentation visit <a href="https://txstyle.org/">txstyle.org</a>.</p>
    <asp:TextBox ID="editPageText" ClientIDMode="Static" TextMode="MultiLine" Columns="40" Rows="40" runat="server" />
    <asp:Button ID="submitPage" Text="Submit" runat="server" OnClick="submitPage_Click" />
</asp:Content>
