<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Alucard-AnyNSC.aspx.cs" Inherits="SotnWiki.WebFormsClient.CvSpeedrunsArchive.Alucard_AnyNSC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="content">
        <h2 id="archiveHeading">Archive of the CvSpeedruns Leaderboard for the category Alucard Any% NSC</h2>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Runner], [Time], [Url], [Platform] FROM [Runs] WHERE ([Category] = @Category)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="0" Name="Category" Type="Int32" />
                </SelectParameters>
            </asp:SqlDataSource>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:GridView ID="CategoryGridView" ClientIDMode="Static" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:BoundField DataField="Runner" HeaderText="Runner" />
                            <asp:BoundField DataField="Time" HeaderText="Time ▲" SortExpression="Time" />
                            <asp:HyperLinkField HeaderText="Video" DataTextField="Url" DataNavigateUrlFields="Url" />
                            <asp:TemplateField HeaderText="Platform ▲" SortExpression="Platform">
                                <ItemTemplate>
                                    <%# Enum.GetName(typeof(CvSpeedruns.Models.Platform),Convert.ToInt32(Eval("Platform"))) %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
