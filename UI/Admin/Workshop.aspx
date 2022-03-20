<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Workshop.aspx.cs" Inherits="Admin_Workshop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table width="100%" style="color: #FFFFFF">
        <tr>
            <td style="text-align: right">Workshop Title:</td>
            <td>
                <asp:TextBox ID="txtWorkShopTitle" runat="server" Width="163px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">Workshop Date:</td>
            <td>
                <asp:TextBox ID="txtWorkShopDate" runat="server" Width="163px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">Workshop Duration:</td>
            <td>
                <asp:TextBox ID="txtWorkShopDuration" runat="server" Width="159px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; color: #FFFFFF;">Workshop Topics:</td>
            <td>
                <asp:TextBox ID="txtWorkShopTopics" runat="server" Height="67px" TextMode="MultiLine" Width="191px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">Trainers:</td>
            <td>
                <asp:CheckBoxList ID="ckbLTrainers" runat="server" style="text-align: left" RepeatColumns="3">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" CssClass="button submit" />
            </td>
            <td>
                <asp:Button ID="btnUpdate" runat="server"  Text="Update" OnClick="btnUpdate_Click" CssClass="button submit" />
                <asp:Button ID="btnDelete" runat="server"  Text="Delete" OnClick="btnDelete_Click" CssClass="button submit" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateSelectButton="True" DataKeyNames="WorkShopId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" >
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
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style1">
               <br /><b> Trainers:</b><br />
                <asp:Button ID="btnAssign" runat="server" OnClick="btnAssign_Click" style="text-align: left" Text="Assign" />
            </td>
        </tr>
    </table>
</asp:Content>

