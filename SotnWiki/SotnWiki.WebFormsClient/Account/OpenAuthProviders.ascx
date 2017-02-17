<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="SotnWiki.WebFormsClient.Account.OpenAuthProviders" %>

<asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
    SelectMethod="GetProviderNames" ViewStateMode="Disabled">
    <ItemTemplate>
        <button type="submit" ID="twitter" name="provider" value="<%#: Item %>"
            title="Sign in with <%#: Item %>"> 
        </button>
    </ItemTemplate>
</asp:ListView>
