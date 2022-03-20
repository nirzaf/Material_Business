<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Common_Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../default.css" rel="stylesheet" type="text/css" />
    <link href="../fonts.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            color: #000000;
        }
        .auto-style2 {
            color: #FFFFFF;
            font-weight: 700;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="../Default.aspx">Back To Home</a><br />
        <span class="auto-style2">Send A Request With your Email Address For Attending Workshop</span><span class="auto-style1"><br />
        </span>
                            <asp:TextBox ID="txtEmail" runat="server"  Width="404px" Height="49px" style="font-size: large" TextMode="Email"></asp:TextBox>
                        <br />
        <asp:Button class="button submit" ID="txtSubmit" runat="server" OnClick="txtSubmit_Click" Text="Submit"  />
         </div>
    </form>
</body>
</html>
