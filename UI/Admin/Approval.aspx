<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Approval.aspx.cs" Inherits="Admin_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="grdWorkShopRequest" Width="100%" runat="server" AutoGenerateSelectButton="True" CellPadding="4" DataKeyNames="UserId,WorkShopId" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <br />
    <asp:RadioButtonList ID="rblApproveReject" runat="server" RepeatDirection="Horizontal" style="color: #FFFFFF">
        <asp:ListItem Value="true">Approve</asp:ListItem>
        <asp:ListItem Value="false">Reject</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="btnSubmit" class="button submit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
</asp:Content>

