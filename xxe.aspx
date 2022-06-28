<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="xxe.aspx.cs" Inherits="xss_form.Web_Vul.WebForm1" validateRequest="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ReadXMLDataUsingXMLReader" />
            <br />
            <br />
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" Height="399px" Width="495px"></asp:ListBox>
            <br />
        </div>
    </form>
</body>
</html>
