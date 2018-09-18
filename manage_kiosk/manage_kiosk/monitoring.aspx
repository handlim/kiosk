<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="monitoring.aspx.cs" Inherits="manage_kiosk.monitoring" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="lblShowMessage" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="btnGetInfo" runat="server" Height="27px" OnClick="btnGetInfo_Click" Text="새로고침" Width="106px" />
            &nbsp;
            <br />
            <br />

            <asp:Label ID="lblPrintStatus" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
