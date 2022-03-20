<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            color: #66FF66;
            text-align: center;
            font-weight: 700;
        }
    </style>
    <link href="default.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div style="color: #FFFFFF">
        <h1 class="auto-style3"><strong>Welcome to WorkShop Management Portal</strong></h1>
        <p class="auto-style3">&nbsp;</p>
        <p class="auto-style3">&nbsp;</p>
        <Marquee onMouseOver="stop();" onMouseOut="start();"><a href="Common/Workshop.aspx">Enroll here for upcoming workshop</a></Marquee><br />
        <br />
        <br />
        <br />
        <br />
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
                Loading.....
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" class="auto-style1">
                    <tr>
                        <td style="text-align: right">UserName:</td>
                        <td>
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txtUserName" runat="server"  Width="404px" Height="49px" style="font-size: large"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">Password:</td>
                        <td>
                            <br />
                            &nbsp;&nbsp;
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="404px" Height="49px" style="font-size: large" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <br />
                        </td>
                        <td>
                            &nbsp;&nbsp;
                            <asp:Button ID="btnLogin" runat="server" class="button submit" OnClick="btnLogin_Click" Text="Login" Height="82px" Width="174px" />
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
&nbsp;</div>
    </form>
</body>
</html>
